using Application.RaceState.Abstractions;
using Domain.Models;
using Infrastructure.RaceState.Abstractions;

namespace Application.RaceState
{
    public class RaceStateWorkerService : IRaceStateWorkerService
    {
        private readonly IRaceStateClient _raceStateClient;
        private RaceStateDTO? _previousRaceState;

        public RaceStateWorkerService(IRaceStateClient raceStatePoller)
        {
            _raceStateClient = raceStatePoller ?? throw new ArgumentNullException(nameof(raceStatePoller));
        }

        public async Task CheckForChangesAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            RaceStateDTO currentRaceState = await _raceStateClient.GetCurrentStateAsync(cancellationToken);

            // Using records value based equality here
            if (currentRaceState == _previousRaceState)
            {
                return;
            }

            // TODO: Broadcast data change

            _previousRaceState = currentRaceState;
        }
    }
}