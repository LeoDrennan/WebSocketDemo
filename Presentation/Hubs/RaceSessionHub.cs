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

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var sessionId = httpContext?.Request.Query["sessionId"];

            if (string.IsNullOrEmpty(sessionId))
            {
                return;
            }

            await _raceSessionService.SubscribeAsync(Context.ConnectionId, sessionId!, Context.ConnectionAborted);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _raceSessionService.UnsubscribeAsync(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}