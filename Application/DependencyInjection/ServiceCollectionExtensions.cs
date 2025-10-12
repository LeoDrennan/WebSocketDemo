using Application.RaceState;
using Application.RaceState.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IRaceStateWorkerService, RaceStateWorkerService>();
            services.AddHostedService<RaceStateWorker>();

            return services;
        }
    }
}