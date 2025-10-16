using Application.RaceSession.Abstractions;
using Domain.Models;
using Infrastructure.RaceSession.Abstractions;
using Microsoft.AspNetCore.SignalR;
using Shared.RaceSession.Abstractions;

namespace Presentation.Hubs
{
    public class RaceSessionHub : Hub
    {
        private readonly IRaceSessionService _raceSessionService;
        private readonly IRaceSessionClient _raceSessionClient;
        private readonly IRaceSessionBroadcastService _raceSessionBroadcastService;

        public RaceSessionHub(IRaceSessionService raceSessionService, IRaceSessionClient raceSessionClient,
            IRaceSessionBroadcastService raceSessionBroadcastService)
        {
            _raceSessionService = raceSessionService ?? throw new ArgumentNullException(nameof(raceSessionService));
            _raceSessionClient = raceSessionClient ?? throw new ArgumentNullException(nameof(raceSessionClient));
            _raceSessionBroadcastService = raceSessionBroadcastService ?? throw new ArgumentNullException(nameof(raceSessionBroadcastService));
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

            await SendCurrentSessionDetails(sessionId);
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            _raceSessionService.UnsubscribeAsync(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        private async Task SendCurrentSessionDetails(string sessionId)
        {
            RaceSessionDto? dto = await _raceSessionClient.GetCurrentStateAsync(sessionId, Context.ConnectionAborted);

            if (dto == null)
            {
                return;
            }

            await _raceSessionBroadcastService.BroadcastUpdateAsync(sessionId, dto, Context.ConnectionAborted);
        }
    }
}