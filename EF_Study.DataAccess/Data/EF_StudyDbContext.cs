using EF_Study.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EF_Study.DataAccess;

public class EF_StudyDbContext : DbContext
{
    public EF_StudyDbContext(DbContextOptions<EF_StudyDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors{ get; set; }
    public DbSet<BookDetail> BookDetails{ get; set; }
    public DbSet<BookAuthorMap> BookAuthors{ get; set; }


    public DbSet<FluentBookDetail> BookDetails_Fluent{ get; set; }
    public DbSet<FluentBook> Book_Fluent{ get; set; }
    public DbSet<FluentAuthor> Author_Fluent{ get; set; }
    public DbSet<FluentPublisher> Publisher_Fluent{ get; set; }
    public DbSet<FluentBookAuthorMap> FluentBookAuthors { get; set; }






    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=PEDRO\\SQLEXPRESS;Database=EF_StudyDb;Trusted_Connection=True;TrustServerCertificate=true;")
            //.LogTo(Console.WriteLine, new[] {DbLoggerCategory.Database.Command.Name},LogLevel.Information);
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) // you can set the db here too
    {
        modelBuilder.ApplyConfiguration(new FluentConfig.FluentBookDetailConfig());


        modelBuilder.Entity<FluentBook>().ToTable("Fluent_Book");
        modelBuilder.Entity<FluentBook>().Property(b => b.ISBN).IsRequired();
        modelBuilder.Entity<FluentBook>().Property(b => b.ISBN).HasMaxLength(50);
        modelBuilder.Entity<FluentBook>().HasKey(b => b.BookId);
        modelBuilder.Entity<FluentBook>().HasOne(b => b.Publisher).WithMany(b => b.Books).HasForeignKey(b => b.Publisher_Id);

        modelBuilder.Entity<FluentAuthor>().ToTable("Fluent_Author");
        modelBuilder.Entity<FluentAuthor>().Property(b => b.LastName).IsRequired();
        modelBuilder.Entity<FluentAuthor>().Property(b => b.FirstName).IsRequired();
        modelBuilder.Entity<FluentAuthor>().Property(b => b.FirstName).HasMaxLength(50);
        modelBuilder.Entity<FluentAuthor>().HasKey(b => b.Author_Id);
        modelBuilder.Entity<FluentAuthor>().Ignore(n => n.FullName);

        modelBuilder.Entity<FluentPublisher>().ToTable("Fluent_Publisher");
        modelBuilder.Entity<FluentPublisher>().Property(b => b.Name).IsRequired();
        modelBuilder.Entity<FluentPublisher>().HasKey(b => b.Publisher_Id);

        modelBuilder.Entity<FluentBookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id }); //Composite Key with  API
        modelBuilder.Entity<FluentBookAuthorMap>().HasOne(b => b.Book).WithMany(b => b.BookAuthor).HasForeignKey(b => b.Book_Id);
        modelBuilder.Entity<FluentBookAuthorMap>().HasOne(b => b.Author).WithMany(b => b.BookAuthor).HasForeignKey(b => b.Author_Id);

        modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", ISBN = "9781119449270", Price = 45.00m, Publisher_Id = 1 },
            new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", ISBN = "9781119096603", Price = 45.00m, Publisher_Id = 1 },
            new Book { BookId = 3, Title = "JavaScript for Kids", ISBN = "9781593274085", Price = 32.00m, Publisher_Id=1 }
        );

        modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10,5);

        modelBuilder.Entity<BookAuthorMap>().HasKey(u => new { u.Author_Id, u.Book_Id }); //Composite Key with  API

        modelBuilder.Entity<Author>().HasData(
            new Author { Author_Id = 1, FirstName = "Christian", LastName = "Nagel", BirthDate = new DateTime(1970, 1, 1) },
            new Author { Author_Id = 2, FirstName = "Jay", LastName = "Glynn", BirthDate = new DateTime(1970, 1, 1) },
            new Author { Author_Id = 3, FirstName = "Morgan", LastName = "Skinner", BirthDate = new DateTime(1970, 1, 1) }
        );

        modelBuilder.Entity<Publisher>().HasData(
            new Publisher { Publisher_Id = 1, Name = "Wrox Press" },
            new Publisher { Publisher_Id = 2, Name = "No Starch Press" }
        );

    }
}
