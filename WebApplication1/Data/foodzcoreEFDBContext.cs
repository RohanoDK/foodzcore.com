using foodzcore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace foodzcore.Data
{
    public class foodzcoreEFDBContext : DbContext
    {
        //Usikker Connection String Metode

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=foodzcoreDB; Integrated Security=True; Connect Timeout=30; Encrypt=False");
        //}

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

        // DbSet properties for data tables within your SQL Database
        public DbSet<Account> Accounts { get; set; }
    }
}
