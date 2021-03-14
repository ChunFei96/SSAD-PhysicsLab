using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Students> Students { get; set; }
        public DbSet<Leaderboard> Leaderboard { get; set; }
        public DbSet<GameTopic> GameTopic { get; set; }
        public DbSet<Level> Level { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}