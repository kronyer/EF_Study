using EF_Study.DataAccess;
using EF_Study.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookDetailController : ControllerBase
    {
        private readonly EF_StudyDbContext _context;

        public BookDetailController(EF_StudyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _context.BookDetails.Include(u => u.Book).ToList(); // .ToList() executes the query as soon as it is called, if you don't call .ToList() the query will be executed when the data is accessed

            //foreach (var book in books)
            //{
            //    //book.Publisher = _context.Publishers.Find(book.Publisher_Id); LEAST EFFICIENT Explicit Loading
            //    _context.Entry(book).Reference(u => u.Book).Load();// Explicit Loading avoids duplicate calls for the same publisher id, not the most efficient way to load data
            //}
            return Ok(_context.Books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please provide a valid book id");
            }
            var book = _context.BookDetails.Include(u => u.Book).FirstOrDefault(x => x.BookDetail_Id == id);
            //book.Publisher = _context.Publishers.Find(book.Publisher_Id);
            _context.Entry(book).Reference(u => u.Book).Load();// Explicit Loading

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] BookDetail book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.BookDetails.Add(book);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] BookDetail book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBook = _context.BookDetails.Find(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.Book = book.Book;
            existingBook.NumberOfChapters = book.NumberOfChapters;
            existingBook.NumberOfPages = book.NumberOfPages;

            _context.SaveChanges();
            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.BookDetails.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.BookDetails.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
    }
}
