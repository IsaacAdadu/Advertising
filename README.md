# Advertising API
A clean-architecture ASP.NET Core Web API for managing advertising campaigns, users, locations, and statuses — 
built with C# .NET, CQRS + MediatR, and Entity Framework Core.

---

## Project Overview

This project implements the following key features:

1. **Authentication & Authorization**
   - User registration (sign-up)
   - Login (JWT-based)
   - Password recovery & OTP resend
   - Profile update and middleware for completion checks

2. **Campaign Management**
   - Create, edit, list campaigns
   - Extend campaign to new locations
   - Upload banners (mocked for now)

3. **Location Management**
   - Create, update, list all and single locations

4. **Status Management**
   - Dynamic DB-backed statuses (Create, Update, List, Get)

5. **Security**
   - ASP.NET Identity + JWT Authentication
   - Role-based authorization (supports admin/user)

---

## Technologies Used

- .NET 8 / ASP.NET Core Web API
-  Entity Framework Core (Code-First)
-  MediatR (CQRS pattern)**
-  FluentValidation**
-  SQL Server
-  Swagger / OpenAPI
-  Clean Architecture (Domain → Application → Infrastructure → API)

---

## ⚙️ Setup Instructions

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or VS Code
- [Postman](https://www.postman.com/) (for API testing)
