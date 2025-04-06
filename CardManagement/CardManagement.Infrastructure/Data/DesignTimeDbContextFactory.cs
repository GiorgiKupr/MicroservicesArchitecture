using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace CardManagement.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<CardManagementDbContext>
    {
        public CardManagementDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../CardManagement.API")) 
                .AddJsonFile("appsettings.json")
                .Build();


            var optionsBuilder = new DbContextOptionsBuilder<CardManagementDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new CardManagementDbContext(optionsBuilder.Options);
        }
    }
}
