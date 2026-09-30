# Task4LINQ - Entity Framework Core Solutions

This repository contains the completed assignment answering the requirements in `Part02.pdf`. It includes three separate software systems implemented cleanly using **C# 10.0** and **Entity Framework Core 10.0** inside a single overarching Visual Studio Solution.

## Solution Architecture

The solution `Task4LINQ` contains three separate backend projects demonstrating complex EF Core modeling techniques (especially Navigation Properties, Fluid API mappings, Join Payloads, and relationship definitions):

1. **EcommerceSystem** (Project 1)
2. **LibrarySystem** (Project 2)
3. **HealthCareSystem** (Project 3)

All three projects follow a clean code separation of concerns model:
- `Models/`: Clean POCO Entities with appropriate Navigation Properties for relationships (1:M, M:1, M:M).
- `Configurations/`: Standalone `IEntityTypeConfiguration<T>` class implementing **Fluent API** mappings (table names, constraints, composite keys, exact behaviors like `DeleteBehavior.Restrict` or `Cascade`).
- `DbContexts/`: Centralized `DbContext` setting up the database and dynamically picking up Fluent API definitions using `ApplyConfigurationsFromAssembly`.
- `Program.cs`: The entry point that cleanly initializes the SQL Server Database (`EnsureDeleted`/`EnsureCreated`), seeds robust test data, tests Navigation queries utilizing `.Include()` / `.ThenInclude()`, and processes standard CRUD operations seamlessly.

## Migrations & Database Setup

EF Core Code-First Migrations have been generated and applied for all 3 projects:
- `EcommerceSystem/Migrations/` (`20260930124023_InitialCreate.cs` + ModelSnapshot)
- `LibrarySystem/Migrations/` (`20260930124043_InitialCreate.cs` + ModelSnapshot)
- `HealthCareSystem/Migrations/` (`20260930124048_InitialCreate.cs` + ModelSnapshot)

To run migrations from the Package Manager Console (PMC) in Visual Studio:
```powershell
# E-commerce Project (Default Project: EcommerceSystem)
Add-Migration InitialCreate
Update-Database

# Library Project (Default Project: LibrarySystem)
Add-Migration InitialCreate
Update-Database

# HealthCare Project (Default Project: HealthCareSystem)
Add-Migration InitialCreate
Update-Database
```

Or from the CLI:
```bash
dotnet ef database update --project EcommerceSystem --startup-project EcommerceSystem
dotnet ef database update --project LibrarySystem --startup-project LibrarySystem
dotnet ef database update --project HealthCareSystem --startup-project HealthCareSystem
```

When you run any project (`dotnet run`), `context.Database.Migrate()` automatically applies any pending migrations and seeds initial data if the database is fresh.

## Entity Relationship Details

### 1. E-Commerce System
- **1 : M (Category to Product)**: A single `Category` can have many `Products`.
- **1 : M (Customer to Order)**: A single `Customer` can place multiple `Orders`.
- **M : M (Order to Product via OrderDetail)**: Handled elegantly via the explicit join table `OrderDetail`, taking composite primary keys of `OrderId` and `ProductId`.

### 2. Library System
- **1 : M (Author to Book)**: An `Author` can write multiple `Book` entries.
- **M : M (Book to Borrower via Loan)**: This explicit join table maps Loans, assigning a Book check out session with active `LoanDate` and nullable `ReturnDate`.

### 3. Health Care System
- **M : M (Patient to Doctor via Appointment)**: Because healthcare requires storing when the checkup occurred, the explicit link entity `Appointment` requires standard mapping between `Patient` and `Doctor`, utilizing a compound key covering: `PatientId`, `DoctorId`, and `AppointmentDate`.

## LinkedIn Article
Included in this repository is `LinkedIn_Article_NavigationProperty.md`, a ready-to-post informational article exploring EF Core Navigation Properties and their importance in modeling structured code!
