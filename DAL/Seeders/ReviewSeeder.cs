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

            // NOTE:
            // - `UserId` must match a real Identity user id in your database.
            // - If you don't seed users via HasData, this seeder will fail on FK constraints.
            // Consider seeding reviews only after you have a deterministic user seeding approach.
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
                    UserId = "REPLACE_WITH_REAL_USER_ID"
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
                    UserId = "REPLACE_WITH_REAL_USER_ID"
                }
            );
        }
    }
}