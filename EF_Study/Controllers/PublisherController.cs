using EF_Study.DataAccess;
using EF_Study.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EF_Study.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly EF_StudyDbContext _context;

        public PublisherController(EF_StudyDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Publishers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Publishers.Add(publisher);
            _context.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Publisher publisher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingPublisher = _context.Publishers.Find(id);
            if (existingPublisher == null)
            {
                return NotFound();
            }
            existingPublisher.Name = publisher.Name;
            _context.SaveChanges();
            return Ok(existingPublisher);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var publisher = _context.Publishers.Find(id);
            if (publisher == null)
            {
                return NotFound();
            }
            _context.Publishers.Remove(publisher);
            _context.SaveChanges();
            return Ok();
        }
    }
}
