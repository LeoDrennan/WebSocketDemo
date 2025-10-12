using Domain.Models;

namespace Infrastructure.RaceState.Abstractions
{
    public interface IRaceStateClient
    {
        Task<RaceStateDTO> GetCurrentStateAsync(CancellationToken cancellationToken);
    }
}
