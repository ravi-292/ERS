using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERS.Services.Models;


namespace ERS.Services.DatabaseContext
{
    public class DataGenerator
    {

        public static void SeedDefaultData(DataContext context)
        {
           
                // Look for any books already in database.
                if (context.Books.Any())
                {
                    return;   // Database has been seeded
                }

           context.Books.AddRange(

            new Book
             {
                 bookId = 1,
                 title = "SPARRING PARTNERS",
                 description = "Three novellas: “Homecoming,” “Strawberry Moon” and “Sparring Partners.”",
                 author = "John Grisham",
                 isReturned = false,
                 bookImage = "https://storage.googleapis.com/du-prd/books/images/9780385549325.jpg"
            },
            new Book
            {
                bookId = 2,
                title = "MEANT TO BE",
                description =
                    "Joe, the disappointing scion of a family considered American royalty, and Cate, a budding model seeking to escape her surroundings, find each other.",
                author = "Emily Giffin",
                isReturned = true,
                bookImage = "https://storage.googleapis.com/du-prd/books/images/9780425286647.jpg"
            },
            new Book
            {
                bookId = 3,
                title = "NIGHTWORK",
                description =
                    "Harry Booth, a master thief, breaks things off with Miranda when a dangerous contact might harm her.",
                author = "Nora Roberts",
                isReturned = false,
                bookImage = "https://storage.googleapis.com/du-prd/books/images/9781250278197.jpg"
            },
            new Book
            {
                bookId = 4,
                title = "22 SECONDS",
                description =
                    "The 22nd book in the Women’s Murder Club series. Lindsay Boxer returns as word gets around about a shipment of drugs and weapons.",
                author = "James Patterson and Maxine Paetro",
                isReturned = false,
                bookImage = "https://storage.googleapis.com/du-prd/books/images/9780316499378.jpg"
            },
            new Book
            {
                bookId = 5,
                title = "THE SUMMER PLACE",
                description =
                    "A wedding between Ruby Danhauser and her pandemic boyfriend at a family beach house in Cape Cod brings to light family secrets.",
                author = "Jennifer Weiner",
                isReturned = true,
                bookImage = "https://storage.googleapis.com/du-prd/books/images/9781501133572.jpg"
            },
            new Book
            {
                bookId = 6,
                title = "THE MIDNIGHT LIBRARY",
                description =
                    "Nora Seed finds a library beyond the edge of the universe that contains books with multiple possibilities of the lives one could have lived.",
                author = "Matt Haig",
                isReturned = true,
                bookImage = "https://storage.googleapis.com/du-prd/books/images/9780525559474.jpg"
            });

            context.SaveChanges();
            
        }
    }
}
