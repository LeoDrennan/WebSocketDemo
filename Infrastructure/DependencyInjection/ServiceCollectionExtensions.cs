using Infrastructure.RaceSession;
using Infrastructure.RaceSession.Abstractions;
using Infrastructure.Sessions;
using Infrastructure.Sessions.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private const string RaceStateBaseUrl = "http://dev-sample-api.tsl-timing.com/";
        private const int TimeoutThresholdSeconds = 100;

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddSingleton<IRaceSessionBroadcastService, RaceSessionBroadcastService>();
            services.AddSingleton<ISessionsBroadcastService, SessionsBroadcastService>();

            services.AddHttpClient<IRaceSessionClient, RaceSessionClient>(client =>
            {
                client.BaseAddress = new Uri(RaceStateBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(TimeoutThresholdSeconds);
            });

            services.AddHttpClient<ISessionsClient, SessionsClient>(client =>
            {
                client.BaseAddress = new Uri(RaceStateBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(TimeoutThresholdSeconds);
            });

            return services;
        }
    }
}