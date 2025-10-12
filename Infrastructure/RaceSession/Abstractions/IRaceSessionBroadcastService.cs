using Domain.Models;

namespace Infrastructure.RaceSession.Abstractions
{
    public interface IRaceSessionBroadcastService
    {
        Task BroadcastUpdateAsync(string sessionId, RaceSessionDto session);
    }
}
