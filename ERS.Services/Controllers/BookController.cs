using ERS.Services.Models;
using Microsoft.AspNetCore.Cors;
using ERS.Services.DatabaseContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ERS.Services.ViewModels;

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
        public async Task<ActionResult<IEnumerable<BookDto>>> Get()
        {

            //return Ok(await _context.Books.ToListAsync());

            return Ok(await _context.Books
                   .Include(e => e.BookBorrowHistories)
                   .Select(e => new BookDto
                   {
                       BookId = e.BookId,
                       Title = e.Title,
                       Description = e.Description,
                       ImageUrl = e.ImageUrl,
                       IsAvailable = e.BookBorrowHistories.Count == 0 || e.BookBorrowHistories.All(x => x.BookReturn != null),
                       BookBorrowHistories = e.BookBorrowHistories.Select(x => new BookHistoryDto
                       {
                           BookBorrow = x.BookBorrow.ToString("MM/dd/yyyy hh:mm tt"),
                           BookReturn = x.BookReturn == null ? string.Empty : x.BookReturn.Value.ToString("MM/dd/yyyy hh:mm tt")
                       }).ToList(),
                       Author = e.Author
                   }).ToListAsync());
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailable()
        {

            //return Ok(await _context.Books.ToListAsync());

            return Ok(await _context.Books
                   .Include(e => e.BookBorrowHistories)
                   .Where(e => e.BookBorrowHistories.Count == 0 || e.BookBorrowHistories.All(x => x.BookReturn != null))
                   .Select(e => new BookDto
                   {
                       BookId = e.BookId,
                       Title = e.Title,
                       Description = e.Description,
                       ImageUrl = e.ImageUrl,
                       IsAvailable = true,
                       Author = e.Author,
                       BookBorrowHistories = e.BookBorrowHistories.Select(x => new BookHistoryDto
                       {
                           BookBorrow = x.BookBorrow.ToString("MM/dd/yyyy hh:mm tt"),
                           BookReturn = x.BookReturn == null ? string.Empty : x.BookReturn.Value.ToString("MM/dd/yyyy hh:mm tt")
                       }).ToList(),
                   }).ToListAsync());
        }

        [HttpGet("borrowed")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBorrowed()
        {

            //return Ok(await _context.Books.ToListAsync());

            return Ok(await _context.Books
                   .Include(e => e.BookBorrowHistories)
                   .Where(e => e.BookBorrowHistories.Count > 0 && e.BookBorrowHistories.Any(x => x.BookReturn == null))
                   .Select(e => new BookDto
                   {
                       BookId = e.BookId,
                       Title = e.Title,
                       Description = e.Description,
                       ImageUrl = e.ImageUrl,
                       IsAvailable = e.BookBorrowHistories.Count == 0 || e.BookBorrowHistories.All(x => x.BookReturn != null),
                       Author = e.Author,
                       BookBorrowHistories = e.BookBorrowHistories.Select(x => new BookHistoryDto
                       {
                           BookBorrow = x.BookBorrow.ToString("MM/dd/yyyy hh:mm tt"),
                           BookReturn = x.BookReturn == null ? string.Empty : x.BookReturn.Value.ToString("MM/dd/yyyy hh:mm tt")
                       }).ToList()
                   }).ToListAsync());
        }

        [HttpGet("{bookId}")]
        public async Task<ActionResult<BookDto>> GetBook(int bookId)
        {
            var book = await _context.Books.Where(e => e.BookId == bookId).Include(e => e.BookBorrowHistories).SingleOrDefaultAsync();

            if (book == null)
                return NotFound();

            return Ok(new BookDto
            {
                BookId = book.BookId,
                Title = book.Title,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                IsAvailable = book.BookBorrowHistories.Count == 0 || book.BookBorrowHistories.All(x => x.BookReturn != null),
                BookBorrowHistories = book.BookBorrowHistories.Select(x => new BookHistoryDto
                {
                    BookBorrow = x.BookBorrow.ToString("MM/dd/yyyy hh:mm tt"),
                    BookReturn = x.BookReturn == null ? string.Empty : x.BookReturn.Value.ToString("MM/dd/yyyy hh:mm tt")
                }).ToList(),
                Author = book.Author
            });
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(BookViewModel book)
        {
            var newBookId = _context.Books.Select(x => x.BookId).Max() + 1;
            _context.Books.Add(new Book
            {
                BookId = newBookId,
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                ImageUrl = book.ImageUrl,
            });
            await _context.SaveChangesAsync();
            return Ok();

        }


        [HttpPut("{bookId}")]
        public async Task<ActionResult> ToggleAvailability(int bookId)
        {
            var book = await _context.Books.Where(e => e.BookId == bookId).Include(e => e.BookBorrowHistories).SingleOrDefaultAsync();

            if (book.BookBorrowHistories == null || book.BookBorrowHistories.Count == 0 || book.BookBorrowHistories.All(e => e.BookReturn != null))
            {
                book.BookBorrowHistories?.Add(new BookHistory { BookBorrow = DateTime.Now });
            }
            else
            {
                var currentlyBorrowedEntries = book.BookBorrowHistories.Where(e => e.BookReturn == null).ToList();
                currentlyBorrowedEntries.ForEach(e => e.BookReturn = DateTime.Now);
            }
            await _context.SaveChangesAsync();
            return Ok(book);

        }


        //[HttpPut("{bookId}/{action}")]
        //public async Task<ActionResult> AddBookHistory(int bookId, string action = "Borrow")
        //{
        //    var bookHistory = await _context.BookHistories.FindAsync(bookId);
        //    int rows = 0;

        //    if (bookHistory == null || action.Equals("Borrow", StringComparison.OrdinalIgnoreCase))
        //    {
        //        var bookhistory = new BookHistory { BookId = bookId, BookBorrow = DateTime.Now, BookReturn = null };
        //        _context.BookHistories.Add(bookhistory);
        //        rows = await _context.SaveChangesAsync();
        //    }
        //    else
        //    {
        //        var bookHistories = _context.BookHistories.AsNoTracking().Where(bookHistory => bookHistory.BookId == bookId && bookHistory.BookReturn == null).FirstOrDefault();
        //        bookHistories.BookReturn = DateTime.Now;
        //        _context.BookHistories.Update(bookHistories);
        //        rows = await _context.SaveChangesAsync();

        //    }


        //    //return Ok(await _context.Books.ToListAsync());
        //    return Ok(rows);

        //}

        [HttpDelete("{bookId}")]
        public async Task<ActionResult> DeleteBook(int bookId)
        {
            var book = await _context.Books.FindAsync(bookId);

            if (book == null)
                return NotFound();

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}