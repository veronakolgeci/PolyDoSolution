using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PolyDo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolyDo.Infrastructure.Configurations {
    public class SubTaskConfiguration : IEntityTypeConfiguration<SubTask> {
        public void Configure(EntityTypeBuilder<SubTask> builder) {
            builder.HasKey(st => st.Id);

            builder.Property(st => st.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(st => st.Description)
                .HasMaxLength(1000);

            builder.Property(st => st.DueDate)
                .IsRequired();

            builder.Property(st => st.IsComplete)
                .HasDefaultValue(false);
        }
    }
}
