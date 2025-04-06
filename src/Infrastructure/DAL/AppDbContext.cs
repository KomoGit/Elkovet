using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedKernel.Domain.Seedwork;

namespace Infrastructure.DAL
{
    public sealed class AppDbContext(
         DbContextOptions<AppDbContext> options,
         IConfiguration configuration) : DbContext(options), IUnitOfWork
    {


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment
                .GetEnvironmentVariable("DB_CONNECTION_STRING");

            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString("Default")
                    ?? throw new Exception("Connection string could not be found.");
            }

            optionsBuilder.UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("Infrastructure.Migrations");
            });
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            base.ConfigureConventions(configurationBuilder);
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await SaveChangesAsync(true, cancellationToken);
            return true;
        }
    }
}
