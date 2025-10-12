using Application.Models;
using Application.RaceSession.Abstractions;
using Microsoft.Extensions.Hosting;

namespace Application.RaceSession
{
    public class RaceSessionWorker : BackgroundService
    {
        private const int RequestIntervalMilliseconds = 10000;

        // Injecting so we can unit test the functionality of this class
        private readonly IRaceSessionWorkerService _workerService;

        public RaceSessionWorker(IRaceSessionWorkerService raceStateWorkerService)
        {
            _workerService = raceStateWorkerService ?? throw new ArgumentNullException(nameof(raceStateWorkerService));
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                SessionUpdateDto dto = await _workerService.CheckForChangesAsync("", cancellationToken);

                if (dto.IsUpdated)
                {
                    // TODO: Add broadcast logic here
                }

                await Task.Delay(RequestIntervalMilliseconds, cancellationToken);
            }
        }
    }
}