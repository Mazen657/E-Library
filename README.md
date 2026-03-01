<div align="center">

<img src="https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white"/>
<img src="https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white"/>
<img src="https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white"/>
<img src="https://img.shields.io/badge/Database-SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white"/>
<img src="https://img.shields.io/badge/License-MIT-green?style=for-the-badge"/>

# 📚 E-Library

**A modern Windows desktop application for managing your personal digital book collection — with category organization, PDF preview, and a clean, intuitive interface.**

<br/>

[![Download v1.0.0](https://img.shields.io/badge/⬇️%20Download%20v1.0.0-E--LibrarySetup.exe-blue?style=for-the-badge)](https://github.com/Mazen657/E-Library/releases/download/v1.0.0/E-LibrarySetup.exe)

</div>

---

## 📖 Table of Contents

- [About](#-about)
- [Screenshots](#-screenshots)
- [Features](#-features)
- [Tech Stack](#-tech-stack)
- [Installation](#-installation)
- [Getting Started](#-getting-started)
- [Database Schema](#-database-schema)
- [Project Structure](#-project-structure)
- [License](#-license)

---

## 🔍 About

**E-Library** is a standalone Windows desktop library management system built with C# and WinForms. It lets you organize your digital book collection locally — no internet required. You can catalog books by category, store PDF files, and preview them directly inside the app.

All data is stored in an embedded **SQLite** database that is automatically created on first launch. The app is lightweight, fast, and designed for personal or small-scale use.

---

## ✨ Features

| Feature | Description |
|---|---|
| 📚 Book Management | Add, edit, and delete book entries with full metadata |
| 🗂️ Category System | Organize books into custom categories |
| 🔍 Search | Instantly search and filter through your entire library |
| 📄 PDF Preview | View PDF book files directly inside the app using PdfiumViewer |
| 🗄️ Local Database | Embedded SQLite database — no server setup needed |
| 🖥️ Splash Screen | Clean startup experience with loading screen |
| 🔒 Single Instance | Prevents duplicate app windows from opening |
| ⚙️ Settings | Customize application preferences |
| 🃏 Card View | Books displayed in a modern card-style UI |

---

## 🛠️ Tech Stack

| Layer | Technology |
|---|---|
| Language | C# |
| Framework | .NET Framework 4.8 |
| UI | Windows Forms (WinForms) |
| Database | SQLite via `Microsoft.Data.Sqlite` |
| PDF Viewer | `PdfiumViewer` |
| Build System | Visual Studio Solution |
| License | MIT |

---

## 💾 Installation

### Option 1 — Download Installer (Recommended)

Click the button below to download the ready-to-run installer for Windows:

[![Download v1.0.0](https://img.shields.io/badge/⬇️%20Download%20v1.0.0-E--LibrarySetup.exe-blue?style=for-the-badge)](https://github.com/Mazen657/E-Library/releases/download/v1.0.0/E-LibrarySetup.exe)

1. Run `E-LibrarySetup.exe`
2. Follow the installation wizard
3. Launch **E-Library** from your desktop or Start Menu

> **Requirements:** Windows 7 / 8 / 10 / 11 (64-bit recommended), .NET Framework 4.8

---

### Option 2 — Build from Source

**Prerequisites:**
- Visual Studio 2019 or 2022
- .NET Framework 4.8 SDK

**Steps:**

```bash
# 1. Clone the repository
git clone https://github.com/Mazen657/E-Library.git

# 2. Open the solution in Visual Studio
#    Double-click: library_app.sln

# 3. Restore NuGet packages
#    Visual Studio will prompt automatically, or run:
#    Tools → NuGet Package Manager → Restore

# 4. Build the solution
#    Build → Build Solution  (or Ctrl+Shift+B)

# 5. Run the application
#    Press F5 or click Start
```

---

## 🚀 Getting Started

Once launched, the app will automatically:
- Initialize the local SQLite database
- Create all required tables if they don't exist
- Show the splash screen, then open the main dashboard

**Typical workflow:**

1. **Create a Category** → Go to the Categories section and add genres (e.g., Science, Fiction, History)
2. **Add a Book** → Click "Add Book", fill in Title, Author, and select a Category. Optionally attach a PDF file
3. **Browse Your Library** → View all books in the Books section, use the Search bar to filter
4. **Read a Book** → Click on any book to open the detail view and preview the PDF inside the app

---

## 🗃️ Database Schema

The SQLite database is automatically created on first launch. Below are the core tables:

### 📘 Books

| Column | Type | Description |
|---|---|---|
| `id` | INTEGER | Primary key (auto-increment) |
| `title` | TEXT | Book title |
| `author` | TEXT | Author name |
| `category_id` | INTEGER | Foreign key → Categories |
| `file_path` | TEXT | Path to PDF file |
| `cover` | TEXT | Optional cover image path |
| `added_date` | DATETIME | Date the book was added |
| `last_opened` | DATETIME | Last time the book was opened |

### 📕 Categories

| Column | Type | Description |
|---|---|---|
| `id` | INTEGER | Primary key (auto-increment) |
| `name` | TEXT | Category name |

---

## 📁 Project Structure

```
E-Library/
├── library_app.sln              # Visual Studio solution file
└── library_app/
    ├── Program.cs               # App entry point, DB init, single-instance guard
    ├── Forms/
    │   ├── SplashForm.cs        # Startup splash screen
    │   ├── Form1.cs             # Main dashboard
    │   ├── BooksForm.cs         # Books list & management
    │   ├── AddBookForm.cs       # Add new book
    │   ├── BookDetailsForm.cs   # Book detail view + PDF preview
    │   ├── CategoriesForm.cs    # Category management
    │   ├── EditCategory.cs      # Edit/rename a category
    │   └── SettingForm.cs       # App settings
    ├── Controls/
    │   ├── SearchBar.cs         # Reusable search bar control
    │   ├── CardBook.cs          # Book card UI component
    │   └── ControlWindow.cs     # Navigation container
    ├── Helpers/
    │   └── DatabaseHelper.cs    # SQLite DB logic & queries
    └── Resources/               # Icons and assets
```

---

## 📜 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for details.

---

<div align="center">

Made with ❤️ by [Mazen Abdallah](https://github.com/Mazen657)

⭐ If you find this project useful, consider giving it a star!

</div>
