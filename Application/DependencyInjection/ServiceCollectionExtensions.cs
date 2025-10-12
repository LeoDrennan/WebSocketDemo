using Application.RaceSession;
using Application.RaceSession.Abstractions;
using Application.State;
using Application.State.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<IRaceSessionWorkerService, RaceSessionWorkerService>();
            services.AddSingleton<ISessionTrackingService, SessionTrackingService>();

            services.AddScoped<IRaceSessionService, RaceSessionService>();

            services.AddHostedService<RaceSessionWorker>();

            return services;
        }
    }
}