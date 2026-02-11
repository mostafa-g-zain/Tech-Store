using DAL.Entities;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DAL.Seeders;

public class ApplicationUserSeeder : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var now = DateTimeOffset.UtcNow;

        // Create password hasher
        var hasher = new PasswordHasher<ApplicationUser>();

        // Admin User
        var adminUser = new ApplicationUser
        {
            Id = 1,
            UserName = "admin@techstore.com",
            NormalizedUserName = "ADMIN@TECHSTORE.COM",
            Email = "admin@techstore.com",
            NormalizedEmail = "ADMIN@TECHSTORE.COM",
            EmailConfirmed = true,
            FullName = "System Administrator",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            CreatedAt = now,
            UpdatedAt = now
        };
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin@123");

        // Customer User
        var customerUser = new ApplicationUser
        {
            Id = 2,
            UserName = "customer@example.com",
            NormalizedUserName = "CUSTOMER@EXAMPLE.COM",
            Email = "customer@example.com",
            NormalizedEmail = "CUSTOMER@EXAMPLE.COM",
            EmailConfirmed = true,
            FullName = "Mostafa Zain",
            SecurityStamp = Guid.NewGuid().ToString(),
            ConcurrencyStamp = Guid.NewGuid().ToString(),
            CreatedAt = now,
            UpdatedAt = now
        };
        customerUser.PasswordHash = hasher.HashPassword(customerUser, "Customer@123");

        builder.HasData(adminUser, customerUser);
    }
}
