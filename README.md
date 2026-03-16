# Office Eagle

> **Learning Project** — This project was built as a hands-on effort to learn **.NET** and **C#**.

## Overview

**Office Eagle** is a RESTful API for an **HR Management System**. The pseudo users in the system represent employees of any given company. It covers core HR workflows such as employee management, authentication, leave tracking, and holiday management.

## Domain

The application models a typical company workforce with three roles:

| Role | Description |
|------|-------------|
| **Employee** | A regular staff member who can view their profile, apply for leave, and check holidays. |
| **Manager** | Oversees a team of employees, can approve or reject leave requests, and manage their team. |
| **Admin** | Has full access to all system resources, including user management and configuration. |

Each user (employee) has a profile that includes their name, department, designation, contact details, employee ID, leave balance, and their reporting manager.

## Features

- **Authentication** — JWT-based login and registration
- **Employee Management** — Create, read, update, and delete employee records
- **Role-based Access Control** — Separate policies for Admin, Manager, and Employee roles
- **Leave Management** — Track leave requests with approval workflow (full-day and half-day)
- **Holiday Management** — Manage company holidays (regular and optional)
- **Swagger UI** — Interactive API documentation available in the development environment

## Tech Stack

| Technology | Purpose |
|------------|---------|
| .NET (ASP.NET Core) | Web API framework |
| C# | Primary language |
| Entity Framework Core | ORM / database access |
| SQL Server | Relational database |
| JWT (JSON Web Tokens) | Stateless authentication |
| AutoMapper | Object-to-object mapping |
| Swagger / OpenAPI | API documentation |

## Getting Started

### Prerequisites

- [.NET 7.0 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
- SQL Server instance (local or remote)

### Configuration

Update the connection string and JWT settings in `appsettings.json` (or `appsettings.Development.json` for local development):

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=<your-server>;Database=OfficeEagle;..."
  },
  "Authentication": {
    "Key": "<strong-random-secret-key>",  // Use a long, random value — never commit real secrets
    "Issuer": "<issuer>",
    "Audience": "<audience>"
  }
}
```

### Run the API

```bash
dotnet restore
dotnet ef database update
dotnet run
```

Once running, open your browser and navigate to `https://localhost:<port>/swagger` to explore the API via Swagger UI.

## Project Structure

```
Office Eagle/
├── Controllers/        # API endpoints (Auth, Employees)
├── DTOs/               # Data Transfer Objects for requests and responses
├── Models/             # Domain models (User, Leave, Holiday)
├── Data/               # EF Core DbContext
├── Migrations/         # EF Core database migrations
├── Repositories/       # Data access layer (interfaces + implementations)
├── Services/           # Business logic helpers (e.g., password hashing)
├── AutoMapper/         # AutoMapper profile for DTO ↔ Model mappings
└── Program.cs          # Application entry point and service registration
```

## License

This project is intended for **learning purposes** and is provided as-is.