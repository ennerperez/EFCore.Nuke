using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Project.Contexts;
namespace Project
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var config = new ConfigurationBuilder()
                .AddJsonFile(path: "appsettings.json", false, true)
                .AddJsonFile($"appsettings.{environmentName}.json", true, true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();

            var services = new ServiceCollection();
            services.AddDbContext<DefaultContext>(options => options.UseSqlite(config.GetConnectionString(nameof(DefaultContext))));
            Services = services.BuildServiceProvider();

        }
        public static ServiceProvider Services { get; private set; }
    }
}
