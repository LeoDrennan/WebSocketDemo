using Application.RaceSession.Abstractions;
using Domain.Models;
using Infrastructure.RaceSession.Abstractions;

namespace Application.RaceSession
{
    public class RaceSessionWorkerService : IRaceSessionWorkerService
    {
        private readonly IRaceSessionClient _raceStateClient;
        private RaceSessionDto? _previousRaceState;

        public RaceSessionWorkerService(IRaceSessionClient raceStatePoller)
        {
            _raceStateClient = raceStatePoller ?? throw new ArgumentNullException(nameof(raceStatePoller));
        }

        public async Task CheckForChangesAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            RaceSessionDto? currentRaceState = await _raceStateClient.GetCurrentStateAsync(cancellationToken);

            // Using records value based equality here
            if (currentRaceState == _previousRaceState)
            {
                return;
            }

            // TODO: Broadcast data change
            Console.WriteLine("Change detected");

            _previousRaceState = currentRaceState;
        }
    }
}