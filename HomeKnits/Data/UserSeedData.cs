using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HomeKnits.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeKnits.Data
{
    public static class UserSeedData
    {
        public static async Task Initialize(IServiceProvider serviceprovider)
        {
            using var context = serviceprovider.GetService<HomeKnitsContext>();

            if (context == null || context.Users.Any())
            {
                return; // DB has been seeded.
            }

            // Roles
            string[] roles = new string[] { "Admin", "Reviewer" };

            // Add the roles to the db
            foreach (string role in roles)
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                if(!context.Roles.Any(r => r.Name == role))
                {
                    await roleStore.CreateAsync(new IdentityRole { Name = role, NormalizedName = role.ToUpper(), ConcurrencyStamp = new Guid().ToString()});
                }
            }

            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Default users
            IdentityUser adminUser = new()
            {
                Id = "305c54b3-b67b-4b08-a355-fa1ba5c9053b",
                Email = "admin@homeknits.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@HOMEKNITS.COM",
                UserName = "admin@homeknits.com",
                NormalizedUserName = "ADMIN@HOMEKNITS.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            string adminPassword = "Admin123!";
            var hashedAdminPassword = passwordHasher.HashPassword(adminUser, adminPassword);
            adminUser.PasswordHash = hashedAdminPassword;

            IdentityUser reviewerUser1 = new()
            {
                Id = "ce9c18ef-72d2-46f7-8652-1d10189259b7",
                Email = "reviewer1@test.com",
                EmailConfirmed = true,
                NormalizedEmail = "REVIEWER1@TEST.COM",
                UserName = "reviewer1@test.com",
                NormalizedUserName = "REVIEWER1@TEST.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            string reviewer1Password = "Reviewer1123!";
            var hashedReviewer1Password = passwordHasher.HashPassword(reviewerUser1, reviewer1Password);
            reviewerUser1.PasswordHash = hashedReviewer1Password;

            IdentityUser reviewerUser2 = new()
            {
                Id = "65b43bef-5a5e-412a-86dd-da417d71fdd7",
                Email = "reviewer2@test.com",
                EmailConfirmed = true,
                NormalizedEmail = "REVIEWER2@TEST.COM",
                UserName = "reviewer2@test.com",
                NormalizedUserName = "REVIEWER2@TEST.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            string reviewer2Password = "Reviewer2123!";
            var hashedReviewer2Password = passwordHasher.HashPassword(reviewerUser1, reviewer2Password);
            reviewerUser2.PasswordHash = hashedReviewer2Password;

            // Create the users
            foreach (IdentityUser user in new IdentityUser[] { adminUser, reviewerUser1, reviewerUser2 })
            {
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var userStore = new UserStore<IdentityUser>(context);
                    await userStore.CreateAsync(user);
                }
            }

            // Assign them roles
            await AssignRole(serviceprovider, adminUser.Email, roles[0]);
            await AssignRole(serviceprovider, reviewerUser1.Email, roles[1]);
            await AssignRole(serviceprovider, reviewerUser2.Email, roles[1]);
        }

        public static async Task AssignRole(IServiceProvider serviceProvider, string email, string role)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            if (userManager != null)
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user != null)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
            
        }
    }
}
