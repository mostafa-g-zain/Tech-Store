using System;
using System.Collections.Generic;
using System.Text;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class SpecificationConfig : IEntityTypeConfiguration<Specification>
    {
        public void Configure(EntityTypeBuilder<Specification> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.SpecKey)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(s => s.SpecValue)
                .IsRequired()
                .HasMaxLength(128);

            builder.Property(s => s.SortOrder)
                .IsRequired(false)
                .HasColumnName("SortOrder");

            builder.HasOne(s => s.Product)
                .WithMany(s => s.Specifications)
                .HasForeignKey(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
