using System.Collections.Generic;

namespace ERS.Services.Models
{
    public class BookDto
    {
        public int BookId { get; set; }

        public string? Title { get; set; }

        public string? Author { get; set; }

        public string? Description { get; set; }

        public string? ImageUrl { get; set; }

        public bool? IsAvailable { get; set; }

        public virtual ICollection<BookHistoryDto>? BookBorrowHistories { get; set; }

    }
}