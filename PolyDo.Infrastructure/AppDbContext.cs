using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PolyDo.Domain.Entities;
using PolyDo.Infrastructure.Configurations;

namespace PolyDo.Infrastructure {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ParentTask> ParentTasks { get; set; }
        public DbSet<SubTask> SubTasks { get; set; }
        public DbSet<TaskList> TaskLists { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new ParentTaskConfiguration());
            modelBuilder.ApplyConfiguration(new SubTaskConfiguration());
            modelBuilder.ApplyConfiguration(new TaskListConfiguration());
        }
    }
}
