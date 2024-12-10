using EF_Study.Model;
using Microsoft.EntityFrameworkCore;

namespace EF_Study.DataAccess;

public class EF_StudyDbContext : DbContext
{
    public EF_StudyDbContext(DbContextOptions<EF_StudyDbContext> options) : base(options)
    {
    }
    public DbSet<Book> Books { get; set; }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder) // you can set the db here too
    {

        modelBuilder.Entity<Book>().HasData(
            new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", ISBN = "9781119449270", Price = 45.00 },
            new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", ISBN = "9781119096603", Price = 45.00 },
            new Book { BookId = 3, Title = "JavaScript for Kids", ISBN = "9781593274085", Price = 32.00 }
        );
    }
}
