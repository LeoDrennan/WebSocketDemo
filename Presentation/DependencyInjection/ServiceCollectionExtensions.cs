using Infrastructure.RaceSession;
using Presentation.Sessions;
using Shared.RaceSession.Abstractions;
using Shared.Sessions.Abstractions;

namespace Presentation.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPresentationServices(this IServiceCollection services)
        {
            services.AddSingleton<IRaceSessionBroadcastService, RaceSessionBroadcastService>();
            services.AddSingleton<ISessionsBroadcastService, SessionsBroadcastService>();

            return services;
        }
    }
}