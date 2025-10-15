using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Presentation.Hubs;
using Shared.RaceSession.Abstractions;

namespace Infrastructure.RaceSession
{
    public class RaceSessionBroadcastService : IRaceSessionBroadcastService
    {
        private readonly IHubContext<RaceSessionHub> _hubContext;

        public RaceSessionBroadcastService(IHubContext<RaceSessionHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task AddToGroupAsync(string connectionId, string sessionId, CancellationToken cancellationToken)
        {
            await _hubContext.Groups.AddToGroupAsync(connectionId, sessionId, cancellationToken);
        }

        public async Task BroadcastUpdateAsync(string sessionId, RaceSessionDto session, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.Group(sessionId).SendAsync("SessionDetailUpdate", session, cancellationToken);
        }
    }
}