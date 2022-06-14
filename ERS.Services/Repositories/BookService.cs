using ERS.Services.DatabaseContext;
using ERS.Services.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ERS.Services.Repositories
{
    public interface IBook
    {
        List<Book> Get();
        Book GetBook(string bookId);
        List<Book> AddBook(Book book);
        Book UpdateBook(Book _book);
        List<Book> DeleteBook(string bookId);
    }
    public class BookService
    {
        private readonly DataContext context;

        public BookService(DataContext context)
        {
            this.context = context;
        }

    }
}
