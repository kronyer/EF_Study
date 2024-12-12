using EF_Study.DataAccess;
using EF_Study.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EF_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly EF_StudyDbContext _context;

        public BookController(EF_StudyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var books = _context.Books
                .Include(u => u.Publisher).Include(u=>u.BookAuthor).ThenInclude(u=> u.Author).ToList(); //Most Efficient way to load data
            //foreach (var book in books)
            //{
            //    //book.Publisher = _context.Publishers.Find(book.Publisher_Id); LEAST EFFICIENT Explicit Loading
            //    //_context.Entry(book).Reference(u => u.Publisher).Load();// Explicit Loading avoids duplicate calls for the same publisher id, not the most efficient way to load data
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

            var book = _context.Books
                .Include(b => b.Publisher) // Eager Loading da entidade Publisher
                .Include(b => b.BookDetail) // Eager Loading da entidade BookDetail
                .FirstOrDefault(b => b.BookId == id);
            //book.Publisher = _context.Publishers.Find(book.Publisher_Id);
            _context.Entry(book).Reference(u => u.Publisher).Load();// Explicit Loading

            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Books.Add(book);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingBook = _context.Books.Find(id);
            if (existingBook == null)
            {
                return NotFound();
            }
            existingBook.BookDetail = book.BookDetail;
            _context.SaveChanges();
            return Ok(existingBook);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("AddAuthor")]
        public IActionResult AddAuthor([FromBody] BookAuthorMap bookAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.BookAuthors.Add(bookAuthor);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPost("RemoveAuthor")]
        public IActionResult RemoveAuthor([FromBody] BookAuthorMap bookAuthor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var bookAuthorExisting = _context.BookAuthors.Find(bookAuthor.Author_Id, bookAuthor.Book_Id);
            _context.BookAuthors.Remove(bookAuthorExisting);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
