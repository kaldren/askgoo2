using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace AskGoo2.Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            var defaultUsersList = new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "john@example.com",
                    Email = "john@example.com"
                }
                , new ApplicationUser
                {
                    FirstName = "Bill",
                    LastName = "Gates",
                    UserName = "bill@microsoft.com",
                    Email = "bill@microsoft.com"
                }
            };

            foreach (var defaultUser in defaultUsersList)
            {
                await userManager.CreateAsync(defaultUser, "FakePwd123-");
                await userManager.AddClaimAsync(defaultUser, new Claim("FullName", $"{defaultUser.FirstName} {defaultUser.LastName}"));
            }
        }
    }
}
