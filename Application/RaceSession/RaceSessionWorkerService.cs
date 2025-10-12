using Application.RaceSession.Abstractions;
using Application.Models;
using Domain.Models;
using Infrastructure.RaceSession.Abstractions;

namespace Application.RaceSession
{
    public class RaceSessionWorkerService : IRaceSessionWorkerService
    {
        private readonly IRaceSessionClient _raceStateClient;
        private RaceSessionDto? _previousRaceSession;

        public RaceSessionWorkerService(IRaceSessionClient raceStatePoller)
        {
            _raceStateClient = raceStatePoller ?? throw new ArgumentNullException(nameof(raceStatePoller));
        }

        public async Task<SessionUpdateDto> CheckForChangesAsync(string sessionId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            RaceSessionDto? currentRaceSession = await _raceStateClient.GetCurrentStateAsync(sessionId, cancellationToken);

            // Using records value based equality here
            if (currentRaceSession == _previousRaceSession)
            {
                return new SessionUpdateDto()
                {
                    IsUpdated = false
                };
            }

            _previousRaceSession = currentRaceSession;

            return new SessionUpdateDto()
            {
                IsUpdated = true,
                RaceSession = currentRaceSession
            };
        }
    }
}