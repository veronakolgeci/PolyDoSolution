using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;

namespace PolyDo.Infrastructure {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
