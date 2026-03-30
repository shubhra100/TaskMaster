# 🚀 TaskMaster - Full-Stack Task Management System

TaskMaster is a modern, high-performance task management application built using a robust multi-layered architecture. It features a sleek, premium design and provides two different frontend experiences: a high-speed **Angular SPA** and a traditional **.NET MVC** dashboard, both powered by a secure **.NET 10 Web API**.

---

## 📸 Project Showcase

### 1. Welcome & Authentication
*Modern, secure login and registration with a premium glassmorphic aesthetic.*

> [!TIP]
> **[ MARK: INSERT LOGIN PAGE SCREENSHOT HERE ]**
> *Example: `![Login Page](./screenshots/login.png)`*

### 2. Angular Dashboard
*A lightning-fast, reactive interface for managing tasks in real-time.*

> [!TIP]
> **[ MARK: INSERT ANGULAR DASHBOARD SCREENSHOT HERE ]**
> *Example: `![Angular Dashboard](./screenshots/dashboard_angular.png)`*

### 3. MVC View
*Server-side rendered (SSR) dashboard for a different perspective.*

> [!TIP]
> **[ MARK: INSERT MVC DASHBOARD SCREENSHOT HERE ]**
> *Example: `![MVC Dashboard](./screenshots/dashboard_mvc.png)`*

---

## 🛠️ Technology Stack

| Layer | Technology |
| :--- | :--- |
| **Backend** | .NET 10 Web API |
| **Database** | Entity Framework Core (In-Memory / SQL Server) |
| **Frontend 1** | Angular 21 (vNext) |
| **Frontend 2** | ASP.NET Core MVC |
| **Security** | JWT (JSON Web Tokens) & BCrypt Password Hashing |
| **API Docs** | Swagger / OpenAPI |

---

## ✨ Key Features

- **🔐 Secure Authentication**: JWT-based auth flow with protected routes and persistent login sessions.
- **⚡ Reactive Dashboard**: Real-time task updates using Angular's state-of-the-art signals/components.
- **🔄 CRUD Operations**: Create, Read, Update, and Delete tasks with ease.
- **✅ Status Toggling**: Mark tasks as completed or pending with a single click.
- **🎨 Premium UI/UX**: minimalist "Light Glass" theme with smooth animations and responsive layouts.
- **🏗️ Layered Architecture**: Follows Repository and Service patterns for clean, maintainable code.

---

## 🚀 Getting Started
 
### 1. Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

### 2. Backend Setup (API)
``bash :

cd TaskManager.Api

dotnet restore

dotnet run

The API should be running on https://localhost:xxxx (or your configured port).

IMPORTANT

[ MARK: INSERT SWAGGER UI SCREENSHOT HERE ] Screenshot of the API endpoints in Swagger.

### 3. Frontend Setup (Angular)
``bash :

cd TaskManagerFrontend 

npm install 

npm start 

Access the app at http://localhost:xxxx. 

### 4. MVC Setup
``bash:

cd TaskManager.Mvc

dotnet run

-------------

📂 Project Structure :

TaskMaster_Project/
├── TaskManager.Api/        # .NET 10 Web API (Core Backend)
├── TaskManagerFrontend/    # Angular 21 Application (Modern UI)
├── TaskManager.Mvc/        # .NET MVC Application (SSR UI)
└── screenshots/            # Create this folder for your images!

------------------

🛡️ Security Implementation
Passwords: Hashed using BCrypt.Net before storage.
Authorization: All Task API endpoints are protected by [Authorize] attributes.
Tokens: JWT tokens include user claims for secure identity management.

-----------

🤝 Contributing
Feel free to fork this project and submit a PR. For major changes, please open an issue first to discuss what you would like to change.

Developed with ❤️ using .NET and Angular.

------------

✍️ Author
SHUBHRA DIVYADARSHINI - Full-Stack Developer | .NET & Angular Enthusiast

💼 LinkedIn: linkedin.com/in/yourprofile
🐙 GitHub: @yourusername
📧 Email: shubhradivyadarshini1242@gmail.com

