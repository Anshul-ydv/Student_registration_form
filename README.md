# Student Registration Web Application

A simple ASP.NET Web Forms application for managing student registrations using SQL Server. The app allows users to add, update, delete, and view student records.

## Features

- Register new students with name, gender, mobile number, and email.
- View a list of all registered students.
- Edit and delete student information.
- Data stored in SQL Server using ADO.NET.
- Basic form validation and user feedback.

## Technologies Used

- ASP.NET Web Forms (C#)
- ADO.NET
- SQL Server (LocalDB)
- HTML/CSS (via ASP.NET controls)
- Visual Studio (recommended IDE)

## Project Structure

```

StudentRegistrationWeb/
├── Default.aspx                # Frontend UI for student registration
├── Default.aspx.cs             # Backend logic (code-behind)
├── Default.aspx.designer.cs    # Auto-generated designer file
├── Web.config                  # Configuration file
├── packages.config             # NuGet package references
├── StudentRegistrationWeb.csproj         # Project file
├── StudentRegistrationWeb.csproj.user    # User-specific project settings
├── Web.Debug.config            # Debug environment config
├── Web.Release.config          # Release environment config
└── StudentRegistrationWeb.sln # Solution file

````

## Database Schema

The application uses a SQL Server database named `regisdb` with a single table:

```sql
CREATE TABLE student (
    StudentId INT PRIMARY KEY IDENTITY(1,1),
    StudentName NVARCHAR(100),
    Gender NVARCHAR(10),
    Mobile NVARCHAR(15),
    Email NVARCHAR(100)
);
````

> ⚠️ Make sure your SQL Server LocalDB instance is running and the `regisdb` database is created with the `student` table before running the application.

## Getting Started

1. **Clone the repository:**

```bash
git clone https://github.com/your-username/student-registration-web.git
```

2. **Open the solution in Visual Studio.**

3. **Configure your database:**

* Update the connection string in `Default.aspx.cs` if necessary:

  ```csharp
  SqlConnection con = new SqlConnection(@"server=(localdb)\localDB; database=regisdb; Integrated Security=True;");
  ```

4. **Run the application (F5).**

5. **Use the form to add, update, or delete student records.**

## Screenshots

*(Add screenshots of the application UI here if available.)*

## License

This project is open-source and available under the [MIT License](LICENSE).

```
