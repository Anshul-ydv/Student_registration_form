using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace StudentRegistrationWeb
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindGridView();
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"server=(localdb)\localDB; database=regisdb; Integrated Security=True; MultipleActiveResultSets=True; ");

                string query = "insert into student(StudentName, Gender, Mobile, Email) values (@name, @gender, @mobile, @email)";

                SqlCommand cmd = new SqlCommand(query, con);
                //SqlCommand cmd = con.CreateCommand();
                //cmd.CommandText = query;

                cmd.Parameters.AddWithValue("@name", txtStudentName.Text);
                cmd.Parameters.AddWithValue("@gender", ddlGender.SelectedValue);
                cmd.Parameters.AddWithValue("@mobile", txtMobileNo.Text);
                cmd.Parameters.AddWithValue("@email", txtEmail.Text);

                con.Open();

                int i = cmd.ExecuteNonQuery();

                if (i != 0)
                {
                    lblMessage.Text = "Student registered Successfully.";
                    BindGridView();
                } else
                {
                    lblMessage.Text = "Student registration failed.";
                }

                con.Close();
            } 
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        private void BindGridView()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"server=(localdb)\localDB; database=regisdb; Integrated Security=True; MultipleActiveResultSets=True; ");

                string query = "select StudentId, StudentName, Gender, Mobile, Email from student";

                SqlCommand cmd = new SqlCommand(query, con);
                //SqlCommand cmd = con.CreateCommand();
                //cmd.CommandText = query;


                con.Open();
                DataTable dt = new DataTable();

                SqlDataReader sdr = cmd.ExecuteReader();

                dt.Load(sdr);

                grdStudent.DataSource = dt;
                grdStudent.DataBind();
                
                con.Close();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void grdStudent_RowEditing(object sender, GridViewEditEventArgs e)
        {
            int idx = e.NewEditIndex;
            grdStudent.EditIndex = idx;
            BindGridView();
        }

        protected void grdStudent_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdStudent.EditIndex = -1;
            BindGridView();
        }

        protected void grdStudent_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = grdStudent.Rows[e.RowIndex];
                int studentid = Convert.ToInt32(((Label)row.FindControl("lblStudentID")).Text);

                string studentName = ((TextBox)row.FindControl("txtStudentName")).Text;
                string gender = ((DropDownList)row.FindControl("drpGender")).SelectedValue;
                string mobile = ((TextBox)row.FindControl("txtMobile")).Text;
                string email = ((TextBox)row.FindControl("txtEmail")).Text;

                SqlConnection con = new SqlConnection(@"server=(localdb)\localDB; database=regisdb; Integrated Security=True; MultipleActiveResultSets=True; ");

                string query = "update student set StudentName=@studentName, gender=@gender, mobile=@mobile, email=@email where studentid=@studentid;";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentid", studentid);
                cmd.Parameters.AddWithValue("@studentName", studentName);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.Parameters.AddWithValue("@email", email);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                grdStudent.EditIndex = -1;

                BindGridView();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }

        protected void grdStudent_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = grdStudent.Rows[e.RowIndex];
                int studentid = Convert.ToInt32(((Label)row.FindControl("lblStudentID")).Text);


                SqlConnection con = new SqlConnection(@"server=(localdb)\localDB; database=regisdb; Integrated Security=True; MultipleActiveResultSets=True; ");

                string query = "delete from student where studentid=@studentid;";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@studentid", studentid);
                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                BindGridView();
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
    }
}