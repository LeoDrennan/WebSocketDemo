using Domain.Models;

namespace Infrastructure.RaceSession.Abstractions
{
    public interface IRaceSessionBroadcastService
    {
        Task AddToGroupAsync(string connectionId, string sessionId);
        Task BroadcastUpdateAsync(string sessionId, RaceSessionDto session);
    }
}
