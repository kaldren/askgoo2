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
            var logger = host.Services.GetRequiredService<ILogger<Program>>();

            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Seed InMemory when in Development
            if (environment == EnvironmentName.Development)
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;

                    try
                    {
                        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                        AppIdentityDbContextSeed.SeedAsync(userManager).Wait();
                        logger.LogInformation("Log Message: Seeding AppIdentityDbContext");

                        var dbContext = services.GetRequiredService<ApplicationDbContext>();
                        ApplicationDbContextSeed.SeedAsync(dbContext).Wait();
                        logger.LogInformation("Log Message: Seeding ApplicationDbContextSeed");

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
