using DSS_Assignment_Islam.Models;
using Microsoft.EntityFrameworkCore;
namespace DSS_Assignment_Islam.Repository
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {

        }
        public DbSet<Circus> Circuses { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Act> Acts { get; set; }
        public DbSet<Trick> Tricks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
