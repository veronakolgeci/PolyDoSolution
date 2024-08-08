using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PolyDo.Domain.Entities;

namespace PolyDo.Infrastructure.Configurations {
    internal class TaskListConfiguration : IEntityTypeConfiguration<TaskList> {

        public void Configure(EntityTypeBuilder<TaskList> builder) {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(l => l.Description)
                .HasMaxLength(500);

            builder.HasMany(l => l.Tasks)
                .WithOne()
                .HasForeignKey(t => t.ListId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
