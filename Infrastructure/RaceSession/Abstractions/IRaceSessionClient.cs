using Domain.Models;

namespace Infrastructure.RaceSession.Abstractions
{
    public interface IRaceSessionClient
    {
        Task<RaceSessionDto?> GetCurrentStateAsync(CancellationToken cancellationToken);
    }
}
