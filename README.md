# 📚 E-Library Management System

A full-stack web application for managing an online library, built with **ASP.NET Core Web API** and a **Vanilla JS / Bootstrap** frontend. This project follows a clean **3-layer architecture** (UI/API → BLL → DAL) and currently includes a fully functional **Category Management** module.

---

## 🏗️ Project Structure

```
E-library/
├── E-library.BLL/               # Business Logic Layer
│   ├── DTOs/
│   │   ├── AuthorDto.cs
│   │   ├── BaseDto.cs
│   │   ├── BookDto.cs
│   │   ├── CategoryDto.cs
│   │   ├── OrderDto.cs
│   │   └── OrderItemDto.cs
│   ├── Mapper/
│   │   └── CustomProfile.cs     # AutoMapper profiles
│   └── Services/
│       ├── Implementation/
│       │   ├── AuthorService.cs
│       │   ├── BookService.cs
│       │   ├── CategoryService.cs
│       │   └── OrderService.cs
│       └── Interface/
│           ├── IAuthorService.cs
│           ├── IBookService.cs
│           ├── ICategoryService.cs
│           ├── IOrderItemService.cs
│           └── IOrderService.cs
│
├── E-library.DAL/               # Data Access Layer
│   ├── Data/
│   │   └── AppDbContext.cs
│   ├── Entities/
│   │   ├── Author.cs
│   │   ├── BaseEntity.cs
│   │   ├── Book.cs
│   │   ├── Category.cs
│   │   ├── Order.cs
│   │   └── OrderItem.cs
│   ├── Migrations/
│   └── Repository/
│       ├── GenericRepository.cs
│       └── IGenericRepository.cs
│
└── E-library.UI_API/            # Presentation Layer (ASP.NET Core Web API)
    ├── Connected Services
    ├── Dependencies
    └── Properties
```

---

## ✅ Features (Current)

### Category Management (MVP)
- **View** all categories in a responsive table
- **Add** a new category (name + description)
- **Edit** an existing category inline via the same form
- **Delete** a category with a confirmation prompt
- **Auto-refresh** on load and after every CUD operation

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Backend API | ASP.NET Core Web API (.NET 8) |
| ORM | Entity Framework Core |
| Database | SQL Server |
| Object Mapping | AutoMapper |
| Architecture | Repository Pattern + Generic Repository |
| Frontend | HTML5, Bootstrap 5.3, Vanilla JavaScript (Fetch API) |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download)
- SQL Server (LocalDB or full instance)
- A modern browser

### 1. Clone the repository

```bash
git clone https://github.com/your-username/e-library.git
cd e-library
```

### 2. Configure the database connection

In `E-library.UI_API/appsettings.json`, update the connection string:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=ELibraryDb;Trusted_Connection=True;"
}
```

### 3. Apply migrations

```bash
cd E-library.DAL
dotnet ef database update --startup-project ../E-library.UI_API
```

### 4. Run the API

```bash
cd E-library.UI_API
dotnet run
```

The API will be available at `https://localhost:7297` by default.

### 5. Open the frontend

Open `index.html` (the Category Management page) in your browser. Make sure the `API_URL` constant in the script matches your running API port:

```javascript
const API_URL = "https://localhost:7297/api/Categories";
```

---

## 🔌 API Endpoints

### Categories

| Method | Endpoint | Description |
|---|---|---|
| `GET` | `/api/Categories` | Get all categories |
| `POST` | `/api/Categories` | Create a new category |
| `PUT` | `/api/Categories` | Update an existing category |
| `DELETE` | `/api/Categories/{id}` | Delete a category by ID |

### Request Body (POST / PUT)

```json
{
  "id": 1,
  "name": "Science Fiction",
  "description": "Books detailing futuristic technology and space exploration."
}
```
> `id` is only required for PUT requests.

---

## 🗺️ Roadmap

- [x] Project architecture setup (BLL, DAL, UI_API)
- [x] Generic Repository pattern
- [x] Category CRUD (API + Frontend)
- [ ] Author management
- [ ] Book management
- [ ] Order management
- [ ] Authentication & Authorization (JWT)
- [ ] Search & filtering
- [ ] Pagination

---

## 🤝 Contributing

This project is a personal learning project. Feel free to fork it and build on top of it!
