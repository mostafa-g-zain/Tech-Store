using BLL.Common;

using DAL.Entities;

using Microsoft.AspNetCore.Identity;

namespace TechStore.Data;

public static class DbInitializer
{
    public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

        string[] roles = { AppRoles.Admin, AppRoles.Customer };

        foreach (var role in roles)
        {
            if (!await roleManager.RoleExistsAsync(role))
            {
                await roleManager.CreateAsync(new IdentityRole<int> { Name = role });
            }
        }

        // Seed Admin user
        const string adminEmail = "admin@techstore.com";
        const string adminPassword = "Admin@123";

        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser is null)
        {
            adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                FullName = "System Administrator",
                EmailConfirmed = true,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };
            await userManager.CreateAsync(adminUser, adminPassword);
        }

        if (!await userManager.IsInRoleAsync(adminUser, "Admin"))
        {
            await userManager.AddToRoleAsync(adminUser, "Admin");
        }

        // Seed Customer user
        const string customerEmail = "customer@techstore.com";
        const string customerPassword = "Customer@123";

        var customerUser = await userManager.FindByEmailAsync(customerEmail);
        if (customerUser is null)
        {
            customerUser = new ApplicationUser
            {
                UserName = customerEmail,
                Email = customerEmail,
                FullName = "Mostafa Zain",
                EmailConfirmed = true,
                CreatedAt = DateTimeOffset.UtcNow,
                UpdatedAt = DateTimeOffset.UtcNow
            };
            await userManager.CreateAsync(customerUser, customerPassword);
        }

        if (!await userManager.IsInRoleAsync(customerUser, "Customer"))
        {
            await userManager.AddToRoleAsync(customerUser, "Customer");
        }
    }
}
