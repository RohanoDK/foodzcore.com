using foodzcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace foodzcore.Data
{
    public class foodzcoreEFDBContext : DbContext
    {

        public foodzcoreEFDBContext(DbContextOptions<foodzcoreEFDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Get the User Secrets configuration
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .AddUserSecrets<foodzcoreEFDBContext>(); // Adds the User Secrets

                var configuration = builder.Build();

                // Uses the connection string from User Secrets
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));

                // Log SQL queries to the console
                optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            }
        }

        // DbSet properties data tables within Database
        public DbSet<Account> Accounts { get; set; }

        public DbSet<Recipe> Recipes { get; set; }
    }
}
