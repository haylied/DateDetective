using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace DDetective.Data
{
    public static class DbInitializer
    {
        public static async Task SeedRolesAndAdminAsync(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();

            // Add roles
            var roles = new[] { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            // Create admin user
            var adminEmail = "admin@example.com";
            var adminPassword = "Admin@123";

            if (await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var admin = new IdentityUser { UserName = adminEmail, Email = adminEmail };
                await userManager.CreateAsync(admin, adminPassword);
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
