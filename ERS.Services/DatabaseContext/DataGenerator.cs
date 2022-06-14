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
                 BookId = 1,
                 Title = "SPARRING PARTNERS",
                 Description = "Three novellas: “Homecoming,” “Strawberry Moon” and “Sparring Partners.”",
                 Author = "John Grisham",
                 IsReturned = false,
                 IsAvailable = true,
                 BookImage = "https://storage.googleapis.com/du-prd/books/images/9780385549325.jpg",
                 ImageUrl = "https://storage.googleapis.com/du-prd/books/images/9780385549325.jpg"
            },
            new Book
            {
                BookId = 2,
                Title = "MEANT TO BE",
                Description =
                    "Joe, the disappointing scion of a family considered American royalty, and Cate, a budding model seeking to escape her surroundings, find each other.",
                Author = "Emily Giffin",
                IsReturned = true,
                BookImage = "https://storage.googleapis.com/du-prd/books/images/9780425286647.jpg",
                ImageUrl = "https://storage.googleapis.com/du-prd/books/images/9780425286647.jpg"
            },
            new Book
            {
                BookId = 3,
                Title = "NIGHTWORK",
                Description =
                    "Harry Booth, a master thief, breaks things off with Miranda when a dangerous contact might harm her.",
                Author = "Nora Roberts",
                IsReturned = false,
                IsAvailable = true,
                BookImage = "https://storage.googleapis.com/du-prd/books/images/9781250278197.jpg",
                ImageUrl = "https://storage.googleapis.com/du-prd/books/images/9781250278197.jpg"
            },
            new Book
            {
                BookId = 4,
                Title = "22 SECONDS",
                Description =
                    "The 22nd book in the Women’s Murder Club series. Lindsay Boxer returns as word gets around about a shipment of drugs and weapons.",
                Author = "James Patterson and Maxine Paetro",
                IsReturned = false,
                IsAvailable = true,
                BookImage = "https://storage.googleapis.com/du-prd/books/images/9780316499378.jpg",
                ImageUrl = "https://storage.googleapis.com/du-prd/books/images/9780316499378.jpg"
            },
            new Book
            {
                BookId = 5,
                Title = "THE SUMMER PLACE",
                Description =
                    "A wedding between Ruby Danhauser and her pandemic boyfriend at a family beach house in Cape Cod brings to light family secrets.",
                Author = "Jennifer Weiner",
                IsReturned = true,
                IsAvailable = true,
                BookImage = "https://storage.googleapis.com/du-prd/books/images/9781501133572.jpg",
                ImageUrl = "https://storage.googleapis.com/du-prd/books/images/9781501133572.jpg"
            },
            new Book
            {
                BookId = 6,
                Title = "THE MIDNIGHT LIBRARY",
                Description = "Nora Seed finds a library beyond the edge of the universe that contains books with multiple possibilities of the lives one could have lived.",
                Author = "Matt Haig",
                IsReturned = true,
                IsAvailable = true,
                BookImage = "https://storage.googleapis.com/du-prd/books/images/9780525559474.jpg",
                ImageUrl = "https://storage.googleapis.com/du-prd/books/images/9780525559474.jpg"
            });

            context.SaveChanges();
            
        }
    }
}
