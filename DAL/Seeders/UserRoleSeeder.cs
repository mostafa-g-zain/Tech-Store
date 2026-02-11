using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DAL.Seeders;

public class UserRoleSeeder : IEntityTypeConfiguration<IdentityUserRole<int>>
{
    public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
    {
        builder.HasData(
            // Admin User (Id: 1) -> Admin Role (Id: 1)
            new IdentityUserRole<int>
            {
                UserId = 1,
                RoleId = 1
            },
            // Customer User (Id: 2) -> Customer Role (Id: 2)
            new IdentityUserRole<int>
            {
                UserId = 2,
                RoleId = 2
            }
        );
    }
}
