using EF_Study.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Study.DataAccess;

public class EF_StudyDbContext : DbContext
{
    public EF_StudyDbContext(DbContextOptions<EF_StudyDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }
    public DbSet<Cateogory> Categories { get; set; }
    public DbSet<SubCategory> SubCategories { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Author> Authors{ get; set; }
    public DbSet<BookDetail> BookDetails{ get; set; }

    


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=PEDRO\\SQLEXPRESS;Database=EF_StudyDb;Trusted_Connection=True;TrustServerCertificate=true;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) // you can set the db here too
    {

        modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", ISBN = "9781119449270", Price = 45.00m, Publisher_Id = 1 },
            new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", ISBN = "9781119096603", Price = 45.00m, Publisher_Id = 1 },
            new Book { BookId = 3, Title = "JavaScript for Kids", ISBN = "9781593274085", Price = 32.00m, Publisher_Id=1 }
        );

        modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10,5);

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
