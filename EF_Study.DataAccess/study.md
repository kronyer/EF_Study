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


## Keep small migrations with small changes

## Never delete the migrations from the project, just change things in model => You can delete if you know exactly what you are doing
## You can delete all and start over!

## You can rollback the migrations
        Update-Database LastGoodMigration


## commands
    get-migration
    delete-database


## To change names:
    Table name => [Table("TableName")]
    Column name => [Column("ColumnName")]

## To set the column as not nullable
    [Required]

## To set as a primary key
    [Key]

## To set lenght of the column
    [MaxLength(100)]

## to set just computed props
    [NotMapped]

## To set as a foreign key
    [ForeignKey("AuthorId")]

## To set the column as unique
    [Index(IsUnique = true)]

## To set the column as a timestamp
    [Timestamp]
    timestamp is used to check if the record was changed by another user

## To set the column as a concurrency check
    [ConcurrencyCheck]

## To set the column as a row version
    [Timestamp]

## To set the column as a computed column
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]

## To set the column as a identity column
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]]



## After .net 5 you don't need to create an intermediary table

## To create a many to many relationship
    public class BookAuthor
    {
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
    modelBuilder.Entity<BookAuthor>()
        .HasKey(ba => new { ba.BookId, ba.AuthorId }); This is a composite key with FluentAPI


    modelBuilder.Entity<BookAuthor>()
        .HasOne(ba => ba.Book)
        .WithMany(b => b.Authors)
        .HasForeignKey(ba => ba.BookId);
    modelBuilder.Entity<BookAuthor>()
        .HasOne(ba => ba.Author)
        .WithMany(a => a.Books)
        .HasForeignKey(ba => ba.AuthorId);


## IQueryable
    IQueryable does the query on the database, IEnumerable does the query on the memory

## lazy loading
    Lazy loading is not enabled by default, you need to enable it in the context
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
    }
    and then set all the navigation properties to virtual
