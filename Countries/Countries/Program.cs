using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Countries.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Countries
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            RunMigrations(host);
            host.Run();
        }

        private static void RunMigrations(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //Migrate() se asegura que la DB haya sido creada y que se les hayan corrido todaslas migrations 
                context.Database.Migrate();
                //Genera datos estaticos en la bd - en este caso popula la tabla Currency
                context.EnsureSeedDataForContext();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
