using Domain.Models;

namespace Application.RaceState.Abstractions
{
    public interface IRaceStateWorkerService
    {
        Task CheckForChangesAsync(CancellationToken cancellationToken);
    }
}