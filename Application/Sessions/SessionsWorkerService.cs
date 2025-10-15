using Application.Models;
using Application.Sessions.Abstractions;
using Domain.Models;
using Infrastructure.Sessions.Abstractions;

namespace Application.Sessions
{
    public class SessionsWorkerService : ISessionsWorkerService
    {
        private const int RequestIntervalMilliseconds = 10000;

        private List<SessionDetailDto> _previousSessions;

        private readonly ISessionsClient _sessionsClient;
        private readonly ISessionsBroadcastService _sessionsBroadcastService;

        public SessionsWorkerService(ISessionsClient sessionsClient, ISessionsBroadcastService sessionsBroadcastService)
        {
            _sessionsClient = sessionsClient ?? throw new ArgumentNullException(nameof(sessionsClient));
            _sessionsBroadcastService = sessionsBroadcastService ?? throw new ArgumentNullException(nameof(sessionsBroadcastService));
        }

        public Task BroadcastUpdateAsync(List<SessionDetailDto> dto, CancellationToken cancellationToken)
            => _sessionsBroadcastService.BroadcastUpdateAsync(dto, cancellationToken);

        public async Task<SessionsUpdateDto> CheckForChangesAsync(CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            List<SessionDetailDto> currentSessions = await _sessionsClient.GetCurrentStateAsync(cancellationToken);

            if (!_previousSessions.SequenceEqual(currentSessions))
            {
                return new SessionsUpdateDto()
                {
                    IsUpdated = false
                };
            }

            _previousSessions = currentSessions;

            return new SessionsUpdateDto()
            {
                IsUpdated = true,
                Sessions = currentSessions
            };
        }
    }
}