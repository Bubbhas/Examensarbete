using Microsoft.EntityFrameworkCore;
using GameOfDojan.Models;

namespace GameOfDojan.Data
{
    public class GameOfDojanDbContext : DbContext
    {
        public GameOfDojanDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<ShoePic> ShoePics { get; set; }

    }
}
