using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;

namespace PolyDo.Infrastructure.Configurations {
    public class ParentTaskConfiguration : IEntityTypeConfiguration<ParentTask> {
        public void Configure(EntityTypeBuilder<ParentTask> builder) {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(t => t.Description)
                .HasMaxLength(1000);

            builder.Property(t => t.DueDate)
                .IsRequired();

            builder.Property(t => t.IsComplete)
                .HasDefaultValue(false);

            // Relationships
            builder.HasOne<TaskList>()
                .WithMany(l => l.Tasks)
                .HasForeignKey(t => t.ListId);

            builder.HasMany(t => t.SubTasks)
                .WithOne()
                .HasForeignKey(st => st.TaskId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
