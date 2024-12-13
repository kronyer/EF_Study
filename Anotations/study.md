Here is your **Entity Framework Study** document with concise sections split for easier navigation:

---

# Entity Framework Study

## 1. Migrations

### Key Concepts
- **Tracking Migrations:** EF tracks migrations and applies only those not applied yet.
- **Fixing Issues:** Use subsequent migrations to resolve issues.
- **Keep Migrations Small:** Make incremental, focused changes in each migration.
- **Deleting Migrations:**  
  - Avoid deleting migrations unless necessary.
  - If required, delete carefully or start fresh by removing all migrations.
- **Rollback:** Use `Update-Database LastGoodMigration` to revert to a stable migration.

### Commands
- **List Migrations:** `Get-Migration`
- **Delete Database:** `Delete-Database`

---

## 2. Data Seeding on Startup

### Overview
Add initial data during model creation:

```csharp
protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<Book>().HasData(
        new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", ISBN = "9781119449270", Price = 45.00m },
        new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", ISBN = "9781119096603", Price = 45.00m },
        new Book { BookId = 3, Title = "JavaScript for Kids", ISBN = "9781593274085", Price = 32.00m }
    );
}
```

---

## 3. Model Customizations with Fluent API and Annotations

### Precision for Decimal Columns
```csharp
modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10, 5);
```

### Nullable Reference Types
- Disable in project settings:
  ```xml
  <Nullable>disabled</Nullable>
  ```
- This avoids using `?` for nullable properties.

### Table and Column Names
- **Table Name:** `[Table("TableName")]`
- **Column Name:** `[Column("ColumnName")]`

### Column Configurations
- **Not Nullable:** `[Required]`
- **Primary Key:** `[Key]`
- **Max Length:** `[MaxLength(100)]`
- **Excluded Property:** `[NotMapped]`
- **Foreign Key:** `[ForeignKey("AuthorId")]`
- **Unique Column:** `[Index(IsUnique = true)]`
- **Timestamp:** `[Timestamp]`
- **Concurrency Check:** `[ConcurrencyCheck]`
- **Computed Column:** `[DatabaseGenerated(DatabaseGeneratedOption.Computed)]`
- **Identity Column:** `[DatabaseGenerated(DatabaseGeneratedOption.Identity)]`

---

## 4. Relationships

### Many-to-Many Relationships (Pre .NET 5)
Define an intermediary table:

```csharp
public class BookAuthor
{
    public int BookId { get; set; }
    public Book Book { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
}
modelBuilder.Entity<BookAuthor>()
    .HasKey(ba => new { ba.BookId, ba.AuthorId }); // Composite Key

modelBuilder.Entity<BookAuthor>()
    .HasOne(ba => ba.Book)
    .WithMany(b => b.Authors)
    .HasForeignKey(ba => ba.BookId);

modelBuilder.Entity<BookAuthor>()
    .HasOne(ba => ba.Author)
    .WithMany(a => a.Books)
    .HasForeignKey(ba => ba.AuthorId);
```

### Many-to-Many Relationships (Post .NET 5)
No need for intermediary tables; use direct relationships.

---

### SPLIT HERE

---

## 5. Querying with IQueryable

- **IQueryable:** Executes queries on the database.
- **IEnumerable:** Loads data into memory before querying.

---

## 6. Lazy Loading

Enable lazy loading in the context:

```csharp
protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
{
    optionsBuilder.UseLazyLoadingProxies();
}
```

- Mark navigation properties as `virtual`.
- **Lazy loading happens automatically** when accessing navigation properties.

---

## 7. Data Loading Strategies in Entity Framework

Entity Framework provides three primary strategies for loading related data: **Lazy Loading**, **Eager Loading**, and **Explicit Loading**. Each has unique features and suits different use cases.

---

### 7.1 Lazy Loading

#### What Is It?
- Data related to an entity is **loaded on demand**, meaning the query to fetch related data is triggered when you first access the navigation property.

#### How to Enable
1. Mark navigation properties as `virtual`.
2. Enable lazy loading proxies in the `DbContext`:

   ```csharp
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
       optionsBuilder.UseLazyLoadingProxies();
   }
   ```

#### Example

```csharp
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; }
}
```

Accessing `Books` triggers a query to load the related data.

#### Pros
- Simple to implement.
- Automatically loads data when needed.

#### Cons
- May lead to **N+1 query problems**, reducing performance.
- Harder to debug and control.

---

### 7.2 Eager Loading

#### What Is It?
- Data related to an entity is **loaded upfront** with the initial query using `Include`.

#### How to Use
Use the `Include` method in your query:

```csharp
var authors = context.Authors.Include(a => a.Books).ToList();
```

The `.ToList()` method forces immediate execution of the query and materializes the result as a list in memory. This is useful when you need to:

- Perform further in-memory operations on the data.
- Avoid deferred execution, which could result in multiple database calls if the query is enumerated multiple times.

#### Example
```csharp
public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Book> Books { get; set; }
}
```
This query fetches `Authors` along with their `Books`.

#### Pros
- Reduces the number of database calls, avoiding N+1 problems.
- Ensures all required data is fetched in one go.

#### Cons
- May fetch unnecessary data, impacting memory usage and performance.
- Queries can become complex with nested `Include`.

---

### 7.3 Explicit Loading

#### What Is It?
- Data related to an entity is **loaded manually** by calling the `Load` method on the related property.

#### How to Use
Fetch related data explicitly:

```csharp
var author = context.Authors.First();
context.Entry(author).Collection(a => a.Books).Load();
```

#### Example

```csharp
var book = context.Books.First();
context.Entry(book).Reference(b => b.Author).Load();
```

#### Pros
- Provides complete control over what and when to load.
- Useful for specific scenarios where only partial related data is needed.

#### Cons
- Requires additional code.
- More effort compared to eager or lazy loading.

---

## 8. Comparison Table

| **Strategy**      | **When Data Loads**               | **Use Case**                                  | **Drawbacks**                                      |
|--------------------|-----------------------------------|-----------------------------------------------|---------------------------------------------------|
| **Lazy Loading**   | When the navigation property is accessed | Simplifies access to related data             | Can cause N+1 queries and performance issues      |
| **Eager Loading**  | During the initial query          | When you know related data will always be needed | May load unnecessary data, impacting performance |
| **Explicit Loading** | Only when explicitly requested    | When precise control over data loading is required | Requires more code and management                |

---

### Key Recommendations
1. Use **Eager Loading** for scenarios where related data is always needed.
2. Opt for **Explicit Loading** for selective, controlled data fetching.
3. Avoid overusing **Lazy Loading**, especially in performance-sensitive applications.

### Summary
- Use migrations to track and manage schema changes effectively.
- Seed data with `OnModelCreating`.
- Customize models using Fluent API or annotations.
- Handle relationships (many-to-many and others) based on your .NET version.
- Optimize queries using `IQueryable` for database-side execution.
- Enable lazy loading if deferred navigation property loading is needed.

---

