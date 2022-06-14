using ERS.Services.Models;
using Microsoft.AspNetCore.Cors;
using ERS.Services.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Linq;


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
        public async Task<ActionResult<IEnumerable<Book>>> Get()
        {
           
            //return Ok(await _context.Books.ToListAsync());

            return Ok(await _context.Books
                   .Include(e => e.BookBorrowHistories)
                   .Select(e => new Book
                   {
                    BookId = e.BookId,
                    Title = e.Title,
                    Description = e.Description,                 
                    ImageUrl = e.ImageUrl,
                    BookImage = e.ImageUrl,
                    IsAvailable = e.BookBorrowHistories.Count == 0 || e.BookBorrowHistories.All(x => x.BookReturn != null),
                    BookBorrowHistories = e.BookBorrowHistories
                }).ToListAsync());
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<Book>> GetBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            book.BookId = _context.Books.Select(x => x.BookId).Max() + 1;            
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
            
        }

        [HttpPut("{bookId}/{action}")]
        public async Task<ActionResult> AddBookHistory(int bookId, string action = "Borrow")
        {
            var bookHistory = await _context.BookHistories.FindAsync(bookId);
            int rows = 0;

            if (bookHistory == null || action.Equals("Borrow",StringComparison.OrdinalIgnoreCase))
            {
                var bookhistory = new BookHistory { BookId = bookId, BookBorrow = DateTime.Now , BookReturn = null };
                _context.BookHistories.Add(bookhistory);
                rows = await _context.SaveChangesAsync();
            }
            else
            {
                var bookHistories = _context.BookHistories.AsNoTracking().Where( bookHistory => bookHistory.BookId == bookId &&  bookHistory.BookReturn == null).FirstOrDefault();
                bookHistories.BookReturn = DateTime.Now;
                _context.BookHistories.Update(bookHistories);
                rows = await _context.SaveChangesAsync();
                
            }


            //return Ok(await _context.Books.ToListAsync());
            return Ok(rows);

        }

        [HttpDelete("{bookId}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
            return Ok(await _context.Books.ToListAsync());
            
        }
    }
}