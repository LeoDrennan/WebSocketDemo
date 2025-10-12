using Application.RaceSession.Abstractions;
using Application.Models;
using Domain.Models;
using Infrastructure.RaceSession.Abstractions;

namespace Application.RaceSession
{
    public class RaceSessionWorkerService : IRaceSessionWorkerService
    {
        private readonly IRaceSessionBroadcastService _raceSessionBroadcastService;
        private readonly IRaceSessionClient _raceSessionClient;

        private RaceSessionDto? _previousRaceSession;

        public RaceSessionWorkerService(IRaceSessionBroadcastService raceSessionBroadcastService, IRaceSessionClient raceSessionClient)
        {
            _raceSessionBroadcastService = raceSessionBroadcastService ?? throw new ArgumentNullException(nameof(raceSessionBroadcastService));
            _raceSessionClient = raceSessionClient ?? throw new ArgumentNullException(nameof(raceSessionClient));
        }

        public async Task<SessionUpdateDto> CheckForChangesAsync(string sessionId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            RaceSessionDto? currentRaceSession = await _raceSessionClient.GetCurrentStateAsync(sessionId, cancellationToken);

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

        public async Task BroadcastUpdateAsync(string sessionId, RaceSessionDto dto, CancellationToken cancellationToken)
            => await _raceSessionBroadcastService.BroadcastUpdateAsync(sessionId, dto, cancellationToken);
    }
}