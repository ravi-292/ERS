using System.ComponentModel.DataAnnotations;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERS.Services.Models
{
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

        public string ImageUrl { get; set; } = string.Empty;

        public virtual ICollection<BookHistory> BookBorrowHistories { get; set; }

    }
}