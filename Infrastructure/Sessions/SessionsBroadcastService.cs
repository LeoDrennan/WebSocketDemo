using Domain.Models;
using Infrastructure.Sessions.Abstractions;
using Microsoft.AspNetCore.SignalR;
using Shared.SignalR;

namespace Infrastructure.Sessions
{
    public class SessionsBroadcastService : ISessionsBroadcastService
    {
        private readonly IHubContext<SessionsHubBase> _hubContext;

        public SessionsBroadcastService(IHubContext<SessionsHubBase> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public async Task BroadcastUpdateAsync(List<SessionDetailDto> sessions, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("SessionsUpdate", sessions, cancellationToken);
        }
    }
}