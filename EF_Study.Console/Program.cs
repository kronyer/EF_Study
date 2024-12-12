// See https://aka.ms/new-console-template for more information
using EF_Study.DataAccess;
using EF_Study.Model;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var optionsBuilder = new DbContextOptionsBuilder<EF_StudyDbContext>();

//GetAllBooks();
GetBook();

void GetAllBooks()
{
    using var context = new EF_StudyDbContext(optionsBuilder.Options);
    AddBook();
    var books = context.Books.ToList();
        foreach (var book in books) //Just execute the query when you enumerate the result == 
        Console.WriteLine(book.Title);
};

void AddBook()
{
    using var context = new EF_StudyDbContext(optionsBuilder.Options);
    var book = new Book
    {
        Title = "New Book",
        ISBN = "1234567890",
        Price = 9.99m,
        Publisher_Id = 1
    };
    context.Books.Add(book);
    context.SaveChanges();
}

void GetBook()
{
    using var context = new EF_StudyDbContext(optionsBuilder.Options);
    //var book = context.Books.FirstOrDefault(); //First or default does not throw an exception if there is no data
    //var book = context.Books.FirstOrDefault(u => u.Title.Contains("C#")); //First or default does not throw an exception if there is no data
    //var book = context.Books.Find(2); //Use Find to get by primary key
    //var book = context.Books.Single(); //Select top 2, if find more than one throws an exception
    //var book = context.Books.SingleOrDefault(); //Single or default does not throw an exception if there is no data
    var book = context.Books.Where(u=>EF.Functions.Like(u.ISBN, "12")); //You can use EF.Functions.Like to use SQL Like
    //Console.WriteLine(book.Title);
}
