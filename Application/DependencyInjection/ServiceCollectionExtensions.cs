using Application.RaceSession;
using Application.RaceSession.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IRaceSessionWorkerService, RaceSessionWorkerService>();
            services.AddScoped<IRaceSessionService, RaceSessionService>();
            services.AddHostedService<RaceSessionWorker>();

            return services;
        }
    }
}