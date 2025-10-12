using Infrastructure.RaceSession;
using Infrastructure.RaceSession.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private const string RaceStateBaseUrl = "http://dev-sample-api.tsl-timing.com/";
        private const int TimeoutThresholdSeconds = 100;

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddHttpClient<IRaceSessionClient, RaceSessionClient>(client =>
            {
                client.BaseAddress = new Uri(RaceStateBaseUrl);
                client.Timeout = TimeSpan.FromSeconds(TimeoutThresholdSeconds);
            });

            return services;
        }
    }
}