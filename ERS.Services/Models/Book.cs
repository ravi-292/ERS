using System.ComponentModel.DataAnnotations;

namespace ERS.Services.Models;

public class Book
{
    [Key]
    public int id { get; set; }
    public int bookId { get; set; }
    public string title { get; set; } = string.Empty;
    public string author { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public DateTime createdAt { get; set; } = DateTime.Now;
    public bool isReturned { get; set; }
    public string bookImage { get; set; } = string.Empty;
    
}