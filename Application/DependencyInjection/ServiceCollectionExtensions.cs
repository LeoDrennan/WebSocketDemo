using Application.Services;
using Domain.Abstractions.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRaceStateService, RaceStateService>();

            return services;
        }
    }
}