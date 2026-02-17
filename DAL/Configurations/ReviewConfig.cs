using System;
using System.Collections.Generic;
using System.Text;

using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Configurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        private const int MinRating = 1;
        private const int MaxRating = 5;
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(r => r.Id);

            builder.Property(r => r.Rating)
                .IsRequired();

            builder.ToTable(t => t.HasCheckConstraint("CK_Review_Rating_Range",
                $"{nameof(Review.Rating)} >= {MinRating} AND {nameof(Review.Rating)} <= {MaxRating}"));

            builder.Property(r => r.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            // Enforce one review per user per product
            builder.HasIndex(r => new { r.UserId, r.ProductId })
                .IsUnique();

            builder.HasOne(r => r.Product)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(r => r.User)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.SetNull);
            //restrict: will prevent deleting any user has reviews... LOL, that doesn't make sense.
            //SetNull: keeps the reviews, on deleting the user account.
        }
    }
}