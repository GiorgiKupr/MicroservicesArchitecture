using CardManagement.Application.Abstractions;
using CardManagement.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CardManagement.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            return services;
        }
    }
}
