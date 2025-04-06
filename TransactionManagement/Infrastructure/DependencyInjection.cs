using Application.Abstraction;
using Infrastructure.Consumer;
using Infrastructure.Data;
using Infrastructure.EventBus;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<TransactionDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ITransactionRepository, TransactionRepository>();

            services.AddCap(x =>
            {
                x.UseEntityFramework<TransactionDbContext>();
                x.UseKafka("localhost:9092");
                x.UseDashboard();
            });
            services.AddScoped<CardStatusUpdatedConsumer>();
            services.AddSingleton<IEventDispatcher, EventDispatcher>();

            return services;
        }
    }
}
