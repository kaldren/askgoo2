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
            var defaultUser = new ApplicationUser
            {
                FirstName = "John",
                LastName = "Doe",
                UserName = "drenski666@gmail.com",
                Email = "drenski666@gmail.com"
            };


            var defaultUser2 = new ApplicationUser
            {
                FirstName = "Bill",
                LastName = "Gates",
                UserName = "bill@microsoft.com",
                Email = "bilL@microsoft.com"
            };

            await userManager.CreateAsync(defaultUser, "Parola123-");
            await userManager.AddClaimAsync(defaultUser, new Claim("FullName", $"{defaultUser.FirstName} {defaultUser.LastName}"));

            await userManager.CreateAsync(defaultUser2, "Parola123-");
            await userManager.AddClaimAsync(defaultUser2, new Claim("FullName", $"{defaultUser2.FirstName} {defaultUser2.LastName}"));
        }
    }
}
