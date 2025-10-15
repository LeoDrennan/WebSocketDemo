using Application.RaceSession.Abstractions;
using Application.State.Abstractions;
using Shared.RaceSession.Abstractions;

namespace Application.RaceSession
{
    public class RaceSessionService : IRaceSessionService
    {
        private readonly IRaceSessionBroadcastService _broadcastService;
        private readonly ISessionTrackingService _trackingService;

        public RaceSessionService(IRaceSessionBroadcastService sessionBroadcastService, ISessionTrackingService sessionTrackingService)
        {
            _broadcastService = sessionBroadcastService ?? throw new ArgumentNullException(nameof(sessionBroadcastService));
            _trackingService = sessionTrackingService ?? throw new ArgumentNullException(nameof(sessionTrackingService));
        }

        public async Task SubscribeAsync(string connectionId, string sessionId, CancellationToken cancellationToken)
        {
            _trackingService.AddConnection(connectionId, sessionId);
            await _broadcastService.AddToGroupAsync(connectionId, sessionId, cancellationToken);
        }

        public void UnsubscribeAsync(string connectionId)
        {
            _trackingService.RemoveConnection(connectionId);
        }
    }
}