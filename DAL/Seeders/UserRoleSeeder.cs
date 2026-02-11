using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders;

public class RoleSeeder : IEntityTypeConfiguration<IdentityRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityRole<int>> builder)
    {
        builder.HasData(
            new IdentityRole<int>
            {
                Id = 1,
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "ROLE-ADMIN-CONCURRENCY-STAMP-001"
            },
            new IdentityRole<int>
            {
                Id = 2,
                Name = "Customer",
                NormalizedName = "CUSTOMER",
                ConcurrencyStamp = "ROLE-CUSTOMER-CONCURRENCY-STAMP-002"
            }
        );
    }
}
