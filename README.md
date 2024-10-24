# Fullstack Demo Project - ASP.NET Core Backend

## Overview

The Fullstack Demo Project is an ASP.NET Core backend application that follows the Domain-Driven Design (DDD) pattern. It utilizes SQL Server for database management and employs Dapper for querying and Entity Framework Core (EF Core) for command handling using the Command Query Responsibility Segregation (CQRS) approach.

## Technologies Used

- ASP.NET Core: Web framework for building the backend services.
- SQL Server: Database management system for data storage.
- Dapper: Micro ORM for efficient data access and querying.
- Entity Framework Core: Object-relational mapper for command handling using CQRS.
- Visual Studio: Integrated development environment (IDE) for development and publishing.
- SQL Server Data Tools (SSDT): Tools for developing, building, testing, and publishing SQL Server databases.

## Features

- **Domain-Driven Design (DDD):** Organized codebase into domains for better maintainability and scalability.
- **Database Management:** Integrated with SQL Server for robust data storage.
- **Data Access:** Utilizes Dapper for efficient querying and EF Core for commands.
- **CQRS:** Implements CQRS pattern for separating read and write operations.

## Getting Started

### Prerequisites

- .NET 8.0
- SQL Server
- SQL Server Management Studio (SSMS)

### Installation

1. Clone the repository:
   ```bash
       git clone https://github.com/yourusername/FullStackDemo.Backend.git
   ```

2.  After cloning the project, publish the SQL project using Visual Studio:
    - Right-click on your SQL project(FullStackDemo.SQLGundamDb) in Solution Explorer.
    - Select Publish.
    - Configure the target database connection in the Publish Database dialog.
    - Click Publish to deploy the database.

3. After publising the database, update the SQL connection string to connect to your deployed database.
    - Open the `appsettings.json` file located in the root of your ASP.NET Core project.
    - Find the `ConnectionStrings` section and update the `GundamDb` string:

   ```json
      "ConnectionStrings": {
           "GundamDb": "Server=your_server_name;Database=your_database_name;User Id=your_username;Password=your_password;TrustServerCertificate=True;"
      },
   ```

### API Documentation
  
  After running the application, you can access the Swagger UI at the following URL:
   ```bash
       https://localhost:44319/swagger/index.html
   ```
  This interface provides a comprehensive overview of the available API endpoints, including request/response models and interactive testing capabilities.