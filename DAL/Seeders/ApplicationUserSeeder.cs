using DAL.Entities;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders;

public class ApplicationUserSeeder : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var seedDate = new DateTimeOffset(2026, 1, 1, 0, 0, 0, TimeSpan.Zero);

        builder.HasData(
            new ApplicationUser
            {
                Id = 1,
                UserName = "admin@techstore.com",
                NormalizedUserName = "ADMIN@TECHSTORE.COM",
                Email = "admin@techstore.com",
                NormalizedEmail = "ADMIN@TECHSTORE.COM",
                EmailConfirmed = true,
                FullName = "System Administrator",
                SecurityStamp = "ADMIN-SECURITY-STAMP-STATIC-001",
                ConcurrencyStamp = "ADMIN-CONCURRENCY-STAMP-STATIC-001",
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            },
            new ApplicationUser
            {
                Id = 2,
                UserName = "customer@techstore.com",
                NormalizedUserName = "CUSTOMER@TECHSTORE.COM",
                Email = "customer@techstore.com",
                NormalizedEmail = "CUSTOMER@TECHSTORE.COM",
                EmailConfirmed = true,
                FullName = "Mostafa Zain",
                SecurityStamp = "CUSTOMER-SECURITY-STAMP-STATIC-002",
                ConcurrencyStamp = "CUSTOMER-CONCURRENCY-STAMP-STATIC-002",
                CreatedAt = seedDate,
                UpdatedAt = seedDate
            }
        );
    }
}
