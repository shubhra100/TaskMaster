# 🚀 TaskMaster - Full-Stack Task Management System

TaskMaster is a modern, high-performance task management application built using a robust multi-layered architecture. It features a sleek, premium design and provides two different frontend experiences: a high-speed **Angular SPA** and a traditional **.NET MVC** dashboard, both powered by a secure **.NET 10 Web API**.

---

## 📸 Project Showcase

### 1. Home / Landing Page
*The gateway to TaskMaster—a clean and professional entryway that invites users to get started.

<img width="1905" height="933" alt="Screenshot (1033)" src="https://github.com/user-attachments/assets/48093ba8-5717-4230-8c7e-c5a73993a42e" />

### 2. Welcome & Authentication
*Modern, secure login and registration with a premium glassmorphic aesthetic.*

<img width="1920" height="931" alt="Screenshot (1032)" src="https://github.com/user-attachments/assets/abb72c9b-e4af-4bdb-971f-566a0265cb3c" />

### 3. Angular Dashboard
*A lightning-fast, reactive interface for managing tasks in real-time.*

<img width="1902" height="919" alt="Screenshot (1025)" src="https://github.com/user-attachments/assets/0425a953-c6c6-40d0-9ff2-1e847105ae06" />


### 4. MVC View
*Server-side rendered (SSR) dashboard for a different perspective.*

<img width="1905" height="916" alt="Screenshot (1027)" src="https://github.com/user-attachments/assets/80f845a0-e11c-4644-885b-eaaf5190d1e6" />



<img width="1846" height="923" alt="Screenshot (1026)" src="https://github.com/user-attachments/assets/385c97a0-6309-4c3e-8316-1b91dc3814f4" />


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

## 🚀 Getting Started :
 
### 1. Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Node.js & npm](https://nodejs.org/)
- [Angular CLI](https://angular.io/cli)

### 2. Backend Setup (API)
``bash :

> cd TaskManager.Api

> dotnet restore

> dotnet run

The API should be running on https://localhost:xxxx (or your configured port).

### 3. Frontend Setup (Angular)
``bash :

> cd TaskManagerFrontend 

> npm install 

> npm start 

Access the app at http://localhost:xxxx. 

### 4. MVC Setup
``bash:

> cd TaskManager.Mvc

> dotnet run

-------------

### 📂 Project Structure :

TaskMaster_Project/

├── TaskManager.Api/        # .NET 10 Web API (Core Backend)

├── TaskManagerFrontend/    # Angular 21 Application (Modern UI)

├── TaskManager.Mvc/        # .NET MVC Application (SSR UI)

└── screenshots/            # Create this folder for your images!

------------------

### 🛡️ Security Implementation :
Passwords: Hashed using BCrypt.Net before storage.

Authorization: All Task API endpoints are protected by [Authorize] attributes.

Tokens: JWT tokens include user claims for secure identity management.

-----------

### 🤝 Contributing :
Feel free to fork this project and submit a PR. For major changes, please open an issue first to discuss what you would like to change.

Developed with ❤️ using .NET and Angular.

------------

### ✍️ Author :
SHUBHRA DIVYADARSHINI - Full-Stack Developer | .NET & Angular Enthusiast

📧 Email: shubhradivyadarshini1242@gmail.com

