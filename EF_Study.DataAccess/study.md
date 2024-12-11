# Entity Framework Study

## Migrations
EF track the migrations and apply just the ones that are not applied yet.

You need to fix things with the next migration


## 


#### To create data on startup
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Title = "Professional C# 7 and .NET Core 2.0", ISBN = "9781119449270", Price = 45.00m },
                new Book { BookId = 2, Title = "Professional C# 6 and .NET Core 1.0", ISBN = "9781119096603", Price = 45.00m },
                new Book { BookId = 3, Title = "JavaScript for Kids", ISBN = "9781593274085", Price = 32.00m }
            );
        }
 

#### To change the precision of a decimal column
        modelBuilder.Entity<Book>().Property(b => b.Price).HasPrecision(10,5);


## Remove Nullable from the project or change to false
        <Nullable>enabled</Nullable>
and then you won't need to use the ? in the properties