using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SaM.BookShelves.DataProvider;
using SaM.BookShelves.DataProvider.Initializers;
using SaM.BookShelves.Models.Entities;

namespace SaM.BookShelves.WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BookShelvesContext>();
                    var userManager = services.GetRequiredService<UserManager<AppUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await Initializer.SeedAsync(context, userManager, rolesManager);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while application starts!");
                }
            }

            host.Run();
        }

        //public static IWebHost BuildWebHost(string[] args) => WebHost.CreateDefaultBuilder(args).UseStartup<Startup>().Build();

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureLogging(logBuilder =>
            {
                logBuilder.ClearProviders(); // removes all providers from LoggerFactory
                logBuilder.AddConsole();
                logBuilder.AddDebug();
                logBuilder.AddTraceSource("Information, ActivityTracing"); // Add Trace listener provider
            })
            .UseStartup<Startup>();
    }
}
