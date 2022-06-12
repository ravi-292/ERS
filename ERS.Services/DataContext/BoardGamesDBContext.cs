using Microsoft.EntityFrameworkCore;

namespace ERS.Services.DataContext
{
    public class BoardGamesDBContext : DbContext
    {
        public BoardGamesDBContext(DbContextOptions<BoardGamesDBContext> options)
            : base(options)
        {
        }

        public DbSet<Models.BoardGame> BoardGames { get; set; }
    }
}
