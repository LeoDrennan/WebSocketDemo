using Application.RaceState.Abstractions;
using Microsoft.Extensions.Hosting;

namespace Application.RaceState
{
    public class RaceStateWorker : BackgroundService
    {
        // Injecting so we can unit test the functionality of this class
        private readonly IRaceStateWorkerService _workerService;

        public RaceStateWorker(IRaceStateWorkerService raceStateWorkerService)
        {
            _workerService = raceStateWorkerService ?? throw new ArgumentNullException(nameof(raceStateWorkerService));
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                await _workerService.CheckForChangesAsync(cancellationToken);
            }
        }
    }
}