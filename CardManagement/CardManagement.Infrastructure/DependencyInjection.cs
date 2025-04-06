using CardManagement.Application.Abstractions;
using CardManagement.Infrastructure.Data;
using CardManagement.Infrastructure.EventBus;
using CardManagement.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CardManagement.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CardManagementDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICardRepository, CardRepository>();
            
            services.AddCap(x =>
            {
                x.UseEntityFramework<CardManagementDbContext>(); 
                x.UseKafka("localhost:9092");
                x.UseDashboard();
            });
            services.AddSingleton<IEventDispatcher, EventDispatcher>();

            return services;
        }
    }
}
