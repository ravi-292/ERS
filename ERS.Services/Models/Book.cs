using System.ComponentModel.DataAnnotations;

namespace ERS.Services.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Book
{

    public Book()
    {

        BookBorrowHistories = new HashSet<BookHistory>();
    }

    [Key]
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;   
    public bool IsReturned { get; set; }
    public bool IsAvailable { get; set; }
    public string BookImage { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
   
    public virtual ICollection<BookHistory> BookBorrowHistories { get; set; }

}