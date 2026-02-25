# Student Management System

A comprehensive web-based application built with ASP.NET Core MVC to manage students, instructors, departments, enrollments, and attendance. It features a modern Glassmorphism Dark Mode UI.

## Features

- **Student Management:** Add, edit, remove, and view student details.
- **Instructor Management:** Manage instructor profiles and assignments.
- **Department Management:** Organize courses and students into departments.
- **Course Enrollment:** Handle student course registrations.
- **Attendance Tracking:** Keep track of student attendance records.
- **Modern UI:** Responsive and visually appealing user interface utilizing a Glassmorphism Dark Mode theme with modern CSS.

## Technology Stack

- **Framework:** ASP.NET Core MVC (.NET 10.0)
- **Object-Relational Mapper (ORM):** Entity Framework Core (v9)
- **Front-end:** HTML5, modern CSS3, customized UI components.
- **Database:** SQL Server

## Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Visual Studio / JetBrains Rider / VS Code
- SQL Server (or SQL Server Express)

## Setup and Installation

1. **Clone the repository:**
   ```bash
   git clone <repository-url>
   ```

2. **Navigate to the project directory:**
   ```bash
   cd DotNet-MVC-Students-Management-System
   ```

3. **Configure the Database Connection:**
   Open `StudentManagementSystem/appsettings.json` and update the `DefaultConnection` string to point to your local SQL Server instance if needed. The default is set to `localhost\SQLEXPRESS`:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=localhost\\SQLEXPRESS;Database=UnversityDB;Trusted_Connection=True;Encrypt=False"
   }
   ```

4. **Apply Database Migrations:**
   Using the Package Manager Console (in Visual Studio):
   ```powershell
   Update-Database
   ```
   Or using the .NET CLI (in terminal):
   ```bash
   dotnet ef database update --project StudentManagementSystem
   ```

5. **Run the Application:**
   Using Visual Studio: Press `F5` or `Ctrl+F5`.
   Using .NET CLI:
   ```bash
   dotnet run --project StudentManagementSystem
   ```

## Project Structure

- `StudentManagementSystem/Controllers/`: Handles incoming HTTP requests and responses.
- `StudentManagementSystem/Models/`: Contains domain entities and data transfer objects.
- `StudentManagementSystem/Views/`: Contains Razor views (.cshtml) for rendering the UI.
- `StudentManagementSystem/Data/`: Contains Entity Framework Core DbContext and database configurations.
- `StudentManagementSystem/Migrations/`: Stores database schema migration histories.
- `StudentManagementSystem/wwwroot/`: Hosts static files like CSS, JavaScript, and images.
