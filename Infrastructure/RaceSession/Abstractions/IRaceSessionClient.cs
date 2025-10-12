using Domain.Models;

namespace Infrastructure.RaceSession.Abstractions
{
    public interface IRaceSessionClient
    {
        Task<RaceSessionDto?> GetCurrentStateAsync(string sessionId, CancellationToken cancellationToken);
    }
}