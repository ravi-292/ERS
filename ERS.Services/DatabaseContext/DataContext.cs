using ERS.Services.Models;
using Microsoft.EntityFrameworkCore;

namespace ERS.Services.DatabaseContext
{

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookHistory>().HasNoKey();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<BookHistory> BookHistories { get; set; }
    }
}