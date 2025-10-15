using Domain.Models;

namespace Shared.RaceSession.Abstractions
{
    public interface IRaceSessionBroadcastService
    {
        Task AddToGroupAsync(string connectionId, string sessionId, CancellationToken cancellationToken);
        Task BroadcastUpdateAsync(string sessionId, RaceSessionDto session, CancellationToken cancellationToken);
    }
}