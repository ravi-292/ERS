namespace ERS.Services.Models
{
    public class BookHistory
    {
        public int bookId { get; set; }
        public DateTime bookBorrow { get; set; }
        public DateTime bookReturn {get;set;}
    }
}
