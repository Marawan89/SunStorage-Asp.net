using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace SunStorage.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // Esegui il seeding del database con dati di test
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<SunStorageDbContext>();
                SeedDatabase(context);
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(kestrel =>
                    {
                        kestrel.AddServerHeader = false; // OWASP: Remove Kestrel response header 
                    });

                    webBuilder.UseStartup<SunStorage.Web.Startup>();
                });

        private static void SeedDatabase(SunStorageDbContext context)
        {
            // Seed dati nel database in memoria (opzionale, puoi popolare le tabelle con dati di test)
            context.Departments.Add(new Department { Name = "IT" });
            context.Departments.Add(new Department { Name = "Marketing" });
            context.Departments.Add(new Department { Name = "Amministrazione" });

            // Aggiungi ulteriori dati di test...
            context.SaveChanges();
        }
    }
}
