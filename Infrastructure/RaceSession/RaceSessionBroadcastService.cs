using Domain.Models;
using Infrastructure.RaceSession.Abstractions;
using Microsoft.AspNetCore.SignalR;
using Shared.SignalR;

namespace Infrastructure.RaceSession
{
    public class RaceSessionBroadcastService : IRaceSessionBroadcastService
    {
        private readonly IHubContext<RaceSessionHubBase> _hubContext;

        public RaceSessionBroadcastService(IHubContext<RaceSessionHubBase> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task AddToGroupAsync(string connectionId, string sessionId, CancellationToken cancellationToken)
        {
            await _hubContext.Groups.AddToGroupAsync(connectionId, sessionId, cancellationToken);
        }

        public async Task BroadcastUpdateAsync(string sessionId, RaceSessionDto session, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.Group(sessionId).SendAsync("ReceiveSessionUpdate", session, cancellationToken);
        }
    }
}