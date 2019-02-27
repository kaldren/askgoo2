using System;
using AskGoo2.Infrastructure.Data;
using AskGoo2.Infrastructure.Identity;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AskGoo2.Web
{
    public class Program
    {
        private IHostingEnvironment CurrentEnvironment { get; set; }

        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (environment == EnvironmentName.Development)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        AppIdentityDbContextSeed.SeedAsync(userManager).Wait();

                        var dbContext = services.GetRequiredService<ApplicationDbContext>();
                        ApplicationDbContextSeed.SeedAsync(dbContext).Wait();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }
                }
            }

            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
