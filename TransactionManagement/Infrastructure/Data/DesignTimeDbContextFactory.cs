using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TransactionDbContext>
    {
        public TransactionDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Transaction.API"))
                .AddJsonFile("appsettings.json")
                .Build();


            var optionsBuilder = new DbContextOptionsBuilder<TransactionDbContext>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new TransactionDbContext(optionsBuilder.Options);
        }
    }
}
