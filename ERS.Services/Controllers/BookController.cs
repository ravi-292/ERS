using ERS.Services.Models;
using Microsoft.AspNetCore.Cors;
using ERS.Services.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ERS.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        

        private readonly DataContext _context;

        public BookController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get()
        {
           
            return Ok(await _context.Books.ToListAsync());
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                return BadRequest("Book not found");

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
            
        }

        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(Book _book)
        {
            var book = await _context.Books.FindAsync(_book.id);

            if (book == null)
                return BadRequest("Book not found");

            book.bookId = _book.bookId;
            book.title = _book.title;
            book.author = _book.author;
            book.description = _book.description;
            book.bookImage = _book.bookImage;
            book.isReturned = _book.isReturned;
            book.createdAt = new DateTime();

            await _context.SaveChangesAsync();

            return Ok(await _context.Books.ToListAsync());
            
        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                return BadRequest("Book not found");

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
            
        }
    }
}