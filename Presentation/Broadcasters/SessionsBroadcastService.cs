using Domain.Models;
using Microsoft.AspNetCore.SignalR;
using Presentation.Hubs;
using Shared.Sessions.Abstractions;

namespace Presentation.Sessions
{
    public class SessionsBroadcastService : ISessionsBroadcastService
    {
        private readonly IHubContext<SessionsHub> _hubContext;

        public SessionsBroadcastService(IHubContext<SessionsHub> hubContext)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
        }

        public async Task BroadcastUpdateAsync(List<SessionDetailDto> sessions, CancellationToken cancellationToken)
        {
            await _hubContext.Clients.All.SendAsync("SessionsUpdate", sessions, cancellationToken);
        }
    }
}