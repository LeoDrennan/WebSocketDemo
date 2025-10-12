using Application.RaceSession.Abstractions;
using Shared.SignalR;

namespace Presentation.Hubs
{
    public class RaceSessionHub : RaceSessionHubBase
    {
        private readonly IRaceSessionService _raceSessionService;

        public RaceSessionHub(IRaceSessionService raceSessionService)
        {
            _raceSessionService = raceSessionService;
        }

        public async Task SubscribeToSession(string sessionId)
        {
            await _raceSessionService.SubscribeAsync(Context.ConnectionId, sessionId);
        }
    }
}