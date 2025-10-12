using Microsoft.Extensions.Hosting;

namespace Infrastructure.Workers
{
    internal class RaceStateWorker : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}