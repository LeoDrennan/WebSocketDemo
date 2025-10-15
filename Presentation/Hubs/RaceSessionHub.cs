using Application.RaceSession.Abstractions;
using Microsoft.AspNetCore.SignalR;

namespace Presentation.Hubs
{
    public class RaceSessionHub : Hub
    {
        private readonly IRaceSessionService _raceSessionService;

        public RaceSessionHub(IRaceSessionService raceSessionService)
        {
            _raceSessionService = raceSessionService;
        }

        public async Task SubscribeToSession(string sessionId, CancellationToken cancellationToken)
        {
            await _raceSessionService.SubscribeAsync(Context.ConnectionId, sessionId, cancellationToken);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _raceSessionService.UnsubscribeAsync(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}