using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HomeKnits.Data;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HomeKnits.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceprovider)
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
                    roleStore.CreateAsync(new IdentityRole(role));
                }
            }

            var passwordHasher = new PasswordHasher<IdentityUser>();

            // Default users
            IdentityUser adminUser = new()
            {
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

            IdentityUser reviewerUser = new()
            {
                Email = "reviewer@test.com",
                EmailConfirmed = true,
                NormalizedEmail = "REVIEWER@TEST.COM",
                UserName = "reviewer@test.com",
                NormalizedUserName = "REVIEWER@TEST.COM",
                SecurityStamp = Guid.NewGuid().ToString("D")
            };
            string reviewerPassword = "Reviewer123!";
            var hashedReviewerPassword = passwordHasher.HashPassword(reviewerUser, reviewerPassword);
            reviewerUser.PasswordHash = hashedReviewerPassword;

            // Create the users
            foreach (IdentityUser user in new IdentityUser[] { adminUser, reviewerUser })
            {
                if (!context.Users.Any(u => u.UserName == user.UserName))
                {
                    var userStore = new UserStore<IdentityUser>(context);
                    userStore.CreateAsync(user);
                }
            }

            // Assign them roles
            AssignRole(serviceprovider, adminUser.Email, roles[0]);
            AssignRole(serviceprovider, reviewerUser.Email, roles[1]);
        }

        public static async void AssignRole(IServiceProvider serviceProvider, string email, string role)
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
