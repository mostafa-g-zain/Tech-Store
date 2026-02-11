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
            var seedDate = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

            builder.HasData(
                new
                {
                    Id = 1,
                    Rating = 5,
                    Title = "Excellent performance",
                    Comment = "Runs everything smoothly. Great build quality.",
                    IsApproved = true,
                    CreatedAt = seedDate,
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
                    CreatedAt = seedDate,
                    ProductId = 7,
                    UserId = 2 // Customer user
                }
            );
        }
    }
}