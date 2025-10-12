using Infrastructure.RaceState;
using Infrastructure.RaceState.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        private const string RACE_STATE_URL = "";

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            // TODO: Add client factory DI

            return services;
        }
    }
}