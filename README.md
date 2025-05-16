# TempLaboClini

**TempLaboClini** is a laboratory management system built with ASP.NET Core (.NET 8) using Razor Pages. The solution is designed to manage clinical laboratory operations, including patient records, exam requests, results, billing, and more.

## Features

- **Entity Management:** Manage areas, exams, patients, doctors, laboratory staff, insurances, addresses, and more.
- **Exam Workflow:** Register, request, and process laboratory exams, including result management.
- **Billing:** Handle invoices and insurance information.
- **Repository Pattern:** Clean separation of data access logic using generic and specific repositories.
- **Entity Framework Core:** Uses EF Core for database access and migrations.
- **Auditing:** Common entity base with creation/modification timestamps and soft delete support.

## Project Structure

- **TempLaboClini.Domain.Entities:** Entity classes representing the domain model (e.g., `Area`, `Aseguradora`, `Examen`, `Paciente`, etc.).
- **TempLaboClini.Infrastructure.Data:** Database context (`ApplicationDbContext`) and EF Core configurations.
- **TempLaboClini.Infrastructure.Repositories:** Generic and specific repositories for data access.
- **TempLaboClini.Web:** Razor Pages UI for interacting with the system (not shown in code above, but typically present).

## Key Technologies

- **.NET 8**
- **C# 12**
- **Entity Framework Core**
- **Razor Pages**
- **Repository Pattern**

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (or compatible database)

### Setup

1. **Clone the repository:**
   
