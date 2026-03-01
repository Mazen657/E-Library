using library_app;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public static class DatabaseHelper
{
    #region Connection

    private static readonly string _dbPath =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "library.db");

    private static readonly string _connectionString =
        $"Data Source={_dbPath}";

    public static SqliteConnection GetConnection() =>
        new SqliteConnection(_connectionString);

    /// <summary>
    /// Returns the full path to the SQLite database file.
    /// </summary>
    public static string GetDatabasePath() => _dbPath;

    #endregion

    #region Schema Setup

    public static void CreateDatabaseAndTables()
    {
        const string sql = @"
            CREATE TABLE IF NOT EXISTS Books (
                Id          INTEGER PRIMARY KEY AUTOINCREMENT,
                Title       TEXT    NOT NULL,
                Author      TEXT,
                Category    TEXT,
                Notes       TEXT,
                PdfPath     TEXT    NOT NULL UNIQUE,
                LastOpened  TEXT
            );";

        ExecuteNonQuery(sql);
    }

    public static void CreateCategoriesTable()
    {
        const string sql = @"
            CREATE TABLE IF NOT EXISTS Categories (
                Id   INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT    NOT NULL UNIQUE
            );";

        ExecuteNonQuery(sql);
    }

    public static void AddLastOpenedColumnIfNotExists()
    {
        bool hasColumn = false;

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand("PRAGMA table_info(Books);", connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (reader.GetString(1) == "LastOpened")
                    {
                        hasColumn = true;
                        break;
                    }
                }
            }

            if (!hasColumn)
                ExecuteNonQuery("ALTER TABLE Books ADD COLUMN LastOpened TEXT");
        }
    }

    public static List<string> GetExistingTables()
    {
        var tables = new List<string>();

        using (var connection = GetConnection())
        {
            connection.Open();

            const string sql = "SELECT name FROM sqlite_master WHERE type='table' AND name NOT LIKE 'sqlite_%';";

            using (var command = new SqliteCommand(sql, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    tables.Add(reader.GetString(0));
            }
        }

        return tables;
    }

    #endregion

    #region Database Reset

    public static void ResetDatabase()
    {
        ExecuteNonQuery("DROP TABLE IF EXISTS Books;");
        ExecuteNonQuery("DROP TABLE IF EXISTS Categories;");

        CreateDatabaseAndTables();
        CreateCategoriesTable();
    }

    #endregion

    #region Book CRUD

    public static void InsertBook(Book book)
    {
        const string sql = @"
            INSERT INTO Books (Title, Author, Category, Notes, PdfPath, LastOpened)
            VALUES (@Title, @Author, @Category, @Notes, @PdfPath, @LastOpened)";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Category", NormalizeCategories(book.Category));
                command.Parameters.AddWithValue("@Notes", book.Notes);
                command.Parameters.AddWithValue("@PdfPath", book.PdfPath);
                command.Parameters.AddWithValue("@LastOpened", DateTime.MinValue.ToString("yyyy-MM-dd HH:mm:ss"));

                command.ExecuteNonQuery();
            }
        }
    }

    public static void UpdateBook(Book book)
    {
        const string sql = @"
            UPDATE Books
            SET Title    = @Title,
                Author   = @Author,
                Notes    = @Notes,
                Category = @Category
            WHERE Id = @Id;";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@Title", book.Title);
                command.Parameters.AddWithValue("@Author", book.Author);
                command.Parameters.AddWithValue("@Notes", book.Notes);
                command.Parameters.AddWithValue("@Category", NormalizeCategories(book.Category));
                command.Parameters.AddWithValue("@Id", book.Id);

                command.ExecuteNonQuery();
            }
        }
    }

    public static void DeleteBookById(int id)
    {
        const string sql = "DELETE FROM Books WHERE Id = @id";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }
    }

    public static bool BookExists(string pdfPath)
    {
        const string sql = "SELECT COUNT(*) FROM Books WHERE PdfPath = @path";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@path", pdfPath);
                return (long)command.ExecuteScalar() > 0;
            }
        }
    }

    public static void UpdateBookLastOpened(int bookId, DateTime lastOpened)
    {
        const string sql = "UPDATE Books SET LastOpened = @lastOpened WHERE Id = @id";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@lastOpened", lastOpened.ToString("yyyy-MM-dd HH:mm:ss"));
                command.Parameters.AddWithValue("@id", bookId);
                command.ExecuteNonQuery();
            }
        }
    }

    public static List<Book> GetAllBooks()
    {
        var books = new List<Book>();

        const string sql = @"
            SELECT Id, Title, Author, Category, Notes, PdfPath, LastOpened
            FROM Books";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    books.Add(ReadBook(reader));
            }
        }

        return books;
    }

    public static List<Book> GetBooksByCategory(string category)
    {
        string normalizedTarget = NormalizeTag(category);

        return GetAllBooks()
            .Where(b => !string.IsNullOrWhiteSpace(b.Category) && BookHasCategory(b, normalizedTarget))
            .ToList();
    }

    private static bool BookHasCategory(Book book, string normalizedTarget)
    {
        return book.Category
            .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(NormalizeTag)
            .Any(tag => tag == normalizedTarget);
    }

    #endregion

    #region Category Table CRUD

    public static void AddCategory(string name)
    {
        const string sql = "INSERT OR IGNORE INTO Categories (Name) VALUES (@name);";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
        }
    }

    public static List<string> GetAllCategories()
    {
        var categories = new List<string>();

        const string sql = "SELECT Name FROM Categories ORDER BY Name;";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            using (var reader = command.ExecuteReader())
            {
                while (reader.Read())
                    categories.Add(reader.GetString(0));
            }
        }

        return categories;
    }

    public static void DeleteCategory(string name)
    {
        const string sql = "DELETE FROM Categories WHERE Name = @name;";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@name", name);
                command.ExecuteNonQuery();
            }
        }
    }

    public static void RenameCategoryInTable(string oldName, string newName)
    {
        const string sql = "UPDATE Categories SET Name = @newName WHERE Name = @oldName;";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
            {
                command.Parameters.AddWithValue("@newName", newName);
                command.Parameters.AddWithValue("@oldName", oldName);
                command.ExecuteNonQuery();
            }
        }
    }

    #endregion

    #region Category Operations on Books

    /// <summary>
    /// Appends a category tag to a book's existing category list.
    /// Spaces in the category name are replaced with underscores before storing
    /// so that "New Folder" is saved as #New_Folder — not split into #New and #Folder.
    /// </summary>
    public static void AddCategoryToBook(int bookId, string category)
    {
        const string selectSql = "SELECT Category FROM Books WHERE Id = @id";
        const string updateSql = "UPDATE Books SET Category = @cat WHERE Id = @id";

        // ── KEY FIX: replace spaces with underscores so a multi-word category
        //    name is treated as ONE tag, not split by NormalizeCategories ──────
        string safeTag = category.Replace(" ", "_");

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            string existingCategory;

            using (var command = new SqliteCommand(selectSql, connection))
            {
                command.Parameters.AddWithValue("@id", bookId);
                existingCategory = command.ExecuteScalar()?.ToString() ?? string.Empty;
            }

            string updatedCategory = NormalizeCategories(existingCategory + " #" + safeTag);

            using (var command = new SqliteCommand(updateSql, connection))
            {
                command.Parameters.AddWithValue("@cat", updatedCategory);
                command.Parameters.AddWithValue("@id", bookId);
                command.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Removes a single category tag from a book without affecting its other categories.
    /// </summary>
    public static void RemoveCategoryFromBook(int bookId, string categoryToRemove)
    {
        const string selectSql = "SELECT Category FROM Books WHERE Id = @id";
        const string updateSql = "UPDATE Books SET Category = @cat WHERE Id = @id";

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            string currentCategory;

            using (var command = new SqliteCommand(selectSql, connection))
            {
                command.Parameters.AddWithValue("@id", bookId);
                currentCategory = command.ExecuteScalar()?.ToString() ?? string.Empty;
            }

            string updatedCategory = currentCategory
                .Split(' ')
                .Where(tag => !NormalizeTag(tag).Equals(NormalizeTag(categoryToRemove)))
                .Aggregate(string.Empty, (acc, tag) => acc + " " + tag)
                .Trim();

            using (var command = new SqliteCommand(updateSql, connection))
            {
                command.Parameters.AddWithValue("@cat", updatedCategory);
                command.Parameters.AddWithValue("@id", bookId);
                command.ExecuteNonQuery();
            }
        }
    }

    /// <summary>
    /// Renames a category tag across all books that reference it.
    /// </summary>
    public static void RenameCategory(string oldName, string newName)
    {
        const string updateSql = "UPDATE Books SET Category = @cat WHERE Id = @id";

        var affectedBooks = GetBooksByCategory(oldName);

        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            foreach (var book in affectedBooks)
            {
                string updatedCategory = ReplaceTagInCategory(book.Category, oldName, newName);

                using (var command = new SqliteCommand(updateSql, connection))
                {
                    command.Parameters.AddWithValue("@cat", updatedCategory);
                    command.Parameters.AddWithValue("@id", book.Id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }

    private static string ReplaceTagInCategory(string categoryField, string oldName, string newName)
    {
        var updatedTags = ParseCategoryTags(categoryField)
            .Select(tag =>
            {
                string clean = tag.TrimStart('#');

                if (!clean.Equals(oldName.Replace(" ", "_"), StringComparison.OrdinalIgnoreCase)
                    && !NormalizeTag(clean).Equals(NormalizeTag(oldName)))
                    return tag;

                string normalized = newName.Replace(" ", "_");
                return tag.StartsWith("#") ? "#" + normalized : normalized;
            })
            .Distinct();

        return string.Join(" ", updatedTags);
    }

    #endregion

    #region Normalization Helpers

    /// <summary>
    /// Normalizes a category string into a deduplicated, hash-prefixed, space-joined
    /// tag list. Each token is taken as-is (no space-splitting within a token) so
    /// callers must pre-replace spaces with underscores for multi-word names.
    /// Example: "#sci_fi #New_Folder" → "#sci_fi #New_Folder"
    /// </summary>
    public static string NormalizeCategories(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var tags = input
            .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(tag => tag.Trim())
            .Select(tag => tag.StartsWith("#") ? tag : "#" + tag)
            .Distinct(StringComparer.OrdinalIgnoreCase);

        return string.Join(" ", tags);
    }

    public static List<string> ParseCategoryTags(string categoryField)
    {
        if (string.IsNullOrWhiteSpace(categoryField))
            return new List<string>();

        return categoryField
            .Split(new[] { ' ', ',', ';' }, StringSplitOptions.RemoveEmptyEntries)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }

    /// <summary>
    /// Strips all formatting from a tag for case-insensitive comparison.
    /// Example: "#New_Folder" → "newfolder"
    /// </summary>
    private static string NormalizeTag(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        return input
            .Trim()
            .Replace("#", string.Empty)
            .Replace("_", string.Empty)
            .Replace(" ", string.Empty)
            .ToLower();
    }

    #endregion

    #region Private Helpers

    private static Book ReadBook(SqliteDataReader reader)
    {
        return new Book
        {
            Id = reader.GetInt32(reader.GetOrdinal("Id")),
            Title = reader.GetString(reader.GetOrdinal("Title")),
            PdfPath = reader.GetString(reader.GetOrdinal("PdfPath")),
            Author = ReadStringOrEmpty(reader, "Author"),
            Category = ReadStringOrEmpty(reader, "Category"),
            Notes = ReadStringOrEmpty(reader, "Notes"),
            LastOpened = reader.IsDBNull(reader.GetOrdinal("LastOpened"))
                ? DateTime.MinValue
                : DateTime.Parse(reader.GetString(reader.GetOrdinal("LastOpened")))
        };
    }

    private static string ReadStringOrEmpty(SqliteDataReader reader, string column)
    {
        int ordinal = reader.GetOrdinal(column);
        return reader.IsDBNull(ordinal) ? string.Empty : reader.GetString(ordinal);
    }

    private static void ExecuteNonQuery(string sql)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();

            using (var command = new SqliteCommand(sql, connection))
                command.ExecuteNonQuery();
        }
    }

    #endregion
}