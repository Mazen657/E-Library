<div align="center">

<img src="Icons/logo1.png" alt="E-Library Logo" width="180"/>

### A modern Windows desktop application for managing your personal digital book collection

Organize books by category · Preview PDFs instantly · Search your library · All stored locally

<br/>

[![Platform](https://img.shields.io/badge/Platform-Windows-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/Mazen657/E-Library)
[![Language](https://img.shields.io/badge/Language-C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)](https://github.com/Mazen657/E-Library)
[![Framework](https://img.shields.io/badge/.NET_Framework-4.8-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://github.com/Mazen657/E-Library)
[![Database](https://img.shields.io/badge/Database-SQLite-003B57?style=for-the-badge&logo=sqlite&logoColor=white)](https://github.com/Mazen657/E-Library)
[![License](https://img.shields.io/badge/License-MIT-22c55e?style=for-the-badge)](LICENSE)
[![Release](https://img.shields.io/badge/Release-v1.0.0-f59e0b?style=for-the-badge)](https://github.com/Mazen657/E-Library/releases/tag/v1.0.0)

<br/>

[![Download Installer](https://img.shields.io/badge/⬇️%20Download%20for%20Windows-E--LibrarySetup.exe%20v1.0.0-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/Mazen657/E-Library/releases/download/v1.0.0/E-LibrarySetup.exe)

</div>

---

## 📖 Table of Contents

- [About](#-about)
- [Screenshots](#-screenshots)
- [Features](#-features)
- [Tech Stack](#tech-stack)
- [System Requirements](#-system-requirements)
- [Installation](#-installation)
- [Getting Started](#-getting-started)
- [Database Schema](#database-schema)
- [Project Structure](#-project-structure)
- [Contributing](#-contributing)
- [License](#-license)

---

## 🔍 About

**E-Library** is a lightweight, fully offline Windows desktop application for managing your personal digital book collection. Built with **C# and WinForms**, it gives you a clean interface to catalog books, organize them into categories, and read them directly inside the app — no internet or server required.

All your data is stored in an embedded **SQLite** database that is created automatically on first launch. Whether you're a student, researcher, or book enthusiast, E-Library makes it easy to keep your digital shelf organized.

> 🏷️ **Standalone · Offline · No server setup · Instant launch**

---

## 📸 Screenshots

<div align="center">

| Splash Screen | Home Screen |
|:-:|:-:|
| ![Home](Screenshot/Screenshot%202026-03-01%20235254.png) | ![Books](Screenshot/Screenshot%202026-03-02%20000828.png) |

| Add Book | Book Details |
|:-:|:-:|
| ![Add Book](Screenshot/Screenshot%202026-03-02%20000530.png) | ![PDF Preview](Screenshot/Screenshot%202026-03-02%20000940.png) |

| Categories | Search |
|:-:|:-:|
| ![Categories](Screenshot/Screenshot%202026-03-02%20000856.png) | ![Search](Screenshot/Screenshot%202026-03-02%20001019.png) |

| Folder | Setting Apearance |
|:-:|:-:|
| ![Settings](Screenshot/Screenshot%202026-03-02%20000917.png) | ![Splash](Screenshot/Screenshot%202026-03-02%20000057.png) |

| Setting Library | Setting Data |
|:-:|:-:|
| ![Settings](Screenshot/Screenshot%202026-03-02%20000141.png) | ![Splash](Screenshot/Screenshot%202026-03-02%20000244.png) |

| Setting About | 
|:-:|
| ![Settings](Screenshot/Screenshot%202026-03-02%20000313.png) | 

</div>

---

## ✨ Features

| Feature | Description |
|---|---|
| 📚 **Book Management** | Add, edit, view, and delete books with full metadata |
| 🗂️ **Category System** | Organize your collection into custom categories |
| 🔍 **Instant Search** | Real-time search and filter across your entire library |
| 📄 **PDF Preview** | Open and read PDF files directly inside the app via PdfiumViewer |
| 🃏 **Card View** | Beautiful card-style UI for browsing your collection |
| 🗄️ **Local SQLite Database** | Embedded, file-based database — no external server needed |
| 🖼️ **Book Covers** | Auto-extract or manually assign cover images for each book |
| 🖥️ **Splash Screen** | Polished startup experience with loading animation |
| 🔒 **Single Instance Guard** | Prevents duplicate app windows from opening |
| ⚙️ **Settings Panel** | Customize app appearance and PDF viewer preferences |
| 🎨 **Theme Support** | Configurable UI color themes |
| 🔄 **Auto Schema Updates** | Database schema updates automatically on new versions |

---

<a id="tech-stack"></a>
## 🛠️ Tech Stack

| Layer | Technology | Details |
|---|---|---|
| **Language** | C# | Primary programming language |
| **Framework** | .NET Framework 4.8 | Windows desktop target |
| **UI** | Windows Forms (WinForms) | Native Windows desktop UI |
| **Database** | SQLite | Via `Microsoft.Data.Sqlite.Core` |
| **PDF Viewer** | PdfiumViewer | In-app PDF rendering |
| **SQLite Bindings** | SQLitePCLRaw | Native SQLite runtime |
| **Build System** | Visual Studio (.sln) | VS 2019 / 2022 compatible |
| **License** | MIT | Free and open source |

---

## 💻 System Requirements

| Requirement | Minimum |
|---|---|
| **Operating System** | Windows 7 / 8 / 10 / 11 |
| **Architecture** | x86 or x64 |
| **Runtime** | .NET Framework 4.8 |
| **Disk Space** | ~50 MB (app) + your book files |
| **RAM** | 256 MB minimum |

---

## 💾 Installation

### ✅ Option 1 — Download Installer *(Recommended)*

<div align="center">

[![Download v1.0.0](https://img.shields.io/badge/⬇️%20Download%20E--LibrarySetup.exe%20—%20v1.0.0-0078D4?style=for-the-badge&logo=windows&logoColor=white)](https://github.com/Mazen657/E-Library/releases/download/v1.0.0/E-LibrarySetup.exe)

</div>

1. Click the button above to download `E-LibrarySetup.exe`
2. Run the installer and follow the on-screen wizard
3. Launch **E-Library** from your Desktop or Start Menu
4. The app automatically sets up the database on first run ✅

---

### 🛠️ Option 2 — Build from Source

**Prerequisites:**
- [Visual Studio 2019 or 2022](https://visualstudio.microsoft.com/) with `.NET desktop development` workload
- .NET Framework 4.8 SDK

```bash
# 1. Clone the repository
git clone https://github.com/Mazen657/E-Library.git
cd E-Library

# 2. Open the solution
#    Double-click: library_app.sln

# 3. Restore NuGet packages
#    Build → Restore NuGet Packages
#    (Microsoft.Data.Sqlite, PdfiumViewer, SQLitePCLRaw)

# 4. Build the solution
#    Build → Build Solution   (Ctrl + Shift + B)

# 5. Run the application
#    Press F5 or click ▶ Start
```

---

## 🚀 Getting Started

On first launch, E-Library will automatically:
- Create a local SQLite database file
- Initialize all required tables
- Display the splash screen and open the home dashboard

**Recommended workflow:**

```
1. Create Categories  →  Sidebar → Categories → Add Category
                          e.g., Fiction, Science, History, Programming

2. Add Books          →  Books → Add Book
                          Enter: Title, Author, Category
                          Attach a PDF file (optional)

3. Browse Library     →  View books in card layout
                          Use the Search bar to filter instantly

4. Read a Book        →  Click any card → Book Details
                          PDF opens directly inside the app
```

---

<a id="database-schema"></a>
## 🗃️ Database Schema

The SQLite database is created and maintained automatically on startup — no manual SQL required.

### 📘 `Books`

| Column | Type | Description |
|---|---|---|
| `id` | `INTEGER` | Primary key, auto-increment |
| `title` | `TEXT` | Book title |
| `author` | `TEXT` | Author name |
| `category_id` | `INTEGER` | Foreign key → `Categories.id` |
| `file_path` | `TEXT` | Absolute path to PDF file |
| `cover` | `TEXT` | Path to cover image (optional) |
| `added_date` | `DATETIME` | When the book was added |
| `last_opened` | `DATETIME` | Last time the book was viewed |

### 📕 `Categories`

| Column | Type | Description |
|---|---|---|
| `id` | `INTEGER` | Primary key, auto-increment |
| `name` | `TEXT` | Category label |

> 📌 Schema migrations run automatically at startup — missing columns are added without data loss.

---

## 📁 Project Structure

```
E-Library/
│
├── 📄 library_app.sln                    # Visual Studio solution
├── 📄 library_app.csproj                 # Project build configuration
├── 📄 App.config                         # Application configuration
├── 📄 Program.cs                         # Entry point: DB init, mutex guard, splash
├── 📄 packages.config                    # NuGet package references
├── 🖼️  ICON.ico                           # Application icon
│
├── 📁 Form/                              # All UI screens
│   ├── SplashForm.cs                     # Startup loading screen
│   ├── Form1.cs                          # Root shell window
│   ├── HomeForm.cs                       # Home dashboard
│   ├── BooksForm.cs                      # Books list and card grid
│   ├── AddBookForm.cs                    # Add new book form
│   ├── BookDetailsForm.cs                # Book info + in-app PDF viewer
│   ├── CategoriesForm.cs                 # Category list management
│   ├── EditCategory.cs                   # Edit/rename category
│   └── SettingForm.cs                    # App settings screen
│
├── 📁 Controls/                          # Reusable UI components
│   ├── CardBook.cs                       # Book card UI component
│   ├── CloseButton.cs                    # Custom window close button
│   ├── ControlWindow.cs                  # Navigation shell container
│   ├── Folders.cs                        # Folder/category navigation
│   └── SearchBar.cs                      # Live search input control
│
├── 📁 Helpers/                           # Business logic & data access
│   ├── DatabaseHelper.cs                 # All SQLite CRUD operations
│   ├── PdfCoverHelper.cs                 # Extract PDF cover thumbnail
│   └── SettingsManager.cs               # App settings read/write
│
├── 📁 Models/                            # Domain entities
│   └── Book.cs                           # Book data model
│
├── 📁 Theme/                             # UI theming
│   └── ThemeColor.cs                     # Color palette definitions
│
├── 📁 Icons/                             # Static image & icon assets
│
├── 📁 Screenshot/                        # App screenshots for README
│
└── 📁 Properties/                        # .NET auto-generated files
    ├── AssemblyInfo.cs
    ├── Resources.Designer.cs
    ├── Resources.resx
    ├── Settings.Designer.cs
    └── Settings.settings
```

---

## 🤝 Contributing

Contributions, bug reports, and feature requests are all welcome!

1. **Fork** the repository
2. **Create** a feature branch: `git checkout -b feature/your-feature`
3. **Commit** your changes: `git commit -m "Add your feature"`
4. **Push** to the branch: `git push origin feature/your-feature`
5. **Open a Pull Request**

> 💡 For major changes, please [open an issue](https://github.com/Mazen657/E-Library/issues) first to discuss your idea.

---

## 📜 License

This project is licensed under the **MIT License** — see the [LICENSE](LICENSE) file for full details.

---

<div align="center">

**Built with ❤️ by [Mazen Abdallah](https://github.com/Mazen657)**

<br/>

If you find E-Library useful, please give it a ⭐ — it means a lot!

[![GitHub Stars](https://img.shields.io/github/stars/Mazen657/E-Library?style=social)](https://github.com/Mazen657/E-Library/stargazers)
&nbsp;&nbsp;
[![GitHub Forks](https://img.shields.io/github/forks/Mazen657/E-Library?style=social)](https://github.com/Mazen657/E-Library/network/members)

</div>
