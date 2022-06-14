using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERS.Services.Models
{
    public class BookHistory
    {
        [Required]
        public int BookId { get; set; }

        public DateTime BookBorrow { get; set; }

        public DateTime? BookReturn { get; set; } = null;

        //[ForeignKey("BookId")]
        //public Book Book { get; set; }
    }
}
