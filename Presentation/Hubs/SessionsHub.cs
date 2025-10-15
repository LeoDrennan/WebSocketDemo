using Domain.Models;
using Infrastructure.Sessions.Abstractions;
using Microsoft.AspNetCore.SignalR;
using Shared.Sessions.Abstractions;

namespace Presentation.Hubs
{
    public class SessionsHub : Hub
    {
        private readonly ISessionsClient _sessionsClient;
        private readonly ISessionsBroadcastService _sessionsBroadcastService;

        public SessionsHub(ISessionsClient sessionsClient, ISessionsBroadcastService sessionsBroadcastService)
        {
            _sessionsClient = sessionsClient ?? throw new ArgumentNullException(nameof(sessionsClient));
            _sessionsBroadcastService = sessionsBroadcastService ?? throw new ArgumentNullException(nameof(sessionsBroadcastService));
        }

        public override async Task OnConnectedAsync()
        {
            List<SessionDetailDto> sessionDetails = await _sessionsClient.GetCurrentStateAsync(Context.ConnectionAborted);
            await _sessionsBroadcastService.BroadcastUpdateAsync(sessionDetails, Context.ConnectionAborted);

            await base.OnConnectedAsync();
        }
    }
}