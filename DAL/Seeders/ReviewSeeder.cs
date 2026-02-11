using System;

using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders
{
    public class ReviewSeeder : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            var now = DateTimeOffset.UtcNow;

            builder.HasData(
                new
                {
                    Id = 1,
                    Rating = 5,
                    Title = "Excellent performance",
                    Comment = "Runs everything smoothly. Great build quality.",
                    IsApproved = true,
                    CreatedAt = now,
                    ProductId = 1,
                    UserId = 2 // Customer user
                },
                new
                {
                    Id = 2,
                    Rating = 4,
                    Title = "Great phone",
                    Comment = "Camera is fantastic, battery life is solid.",
                    IsApproved = true,
                    CreatedAt = now,
                    ProductId = 7,
                    UserId = 2 // Customer user
                }
            );
        }
    }
}