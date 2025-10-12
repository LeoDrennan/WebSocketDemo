using Application.Models;
using Application.RaceSession.Abstractions;
using Application.State.Abstractions;
using Microsoft.Extensions.Hosting;

namespace Application.RaceSession
{
    public class RaceSessionWorker : BackgroundService
    {
        private const int RequestIntervalMilliseconds = 10000;

        // Injecting so we can unit test the functionality of this class
        private readonly IRaceSessionWorkerService _workerService;
        private readonly ISessionTrackingService _sessionTrackingService;

        public RaceSessionWorker(IRaceSessionWorkerService raceStateWorkerService, ISessionTrackingService sessionTrackingService)
        {
            _sessionTrackingService = sessionTrackingService ?? throw new ArgumentNullException(nameof(sessionTrackingService));
            _workerService = raceStateWorkerService ?? throw new ArgumentNullException(nameof(raceStateWorkerService));
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                // I'm assuming there is a better way to execute this in batch - would be a next step
                foreach (string sessionId in _sessionTrackingService.GetActiveSessions())
                {
                    SessionUpdateDto dto = await _workerService.CheckForChangesAsync("", cancellationToken);

                    if (dto.IsUpdated)
                    {
                        await _workerService.BroadcastUpdateAsync(sessionId, dto.RaceSession!);
                    }
                }

                await Task.Delay(RequestIntervalMilliseconds, cancellationToken);
            }
        }
    }
}