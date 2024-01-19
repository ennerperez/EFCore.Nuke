using System.IO;
using Project.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Project.Contexts
{
    public class DefaultContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableDetailedErrors();
            optionsBuilder.EnableSensitiveDataLogging();

            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();
                var connectionString = configuration.GetConnectionString(nameof(DefaultContext));
                optionsBuilder.UseSqlite(connectionString);
            }
        }

        #region DbSet

        public DbSet<Person> Persons { get; set; }

        #endregion DbSet
    }
}
