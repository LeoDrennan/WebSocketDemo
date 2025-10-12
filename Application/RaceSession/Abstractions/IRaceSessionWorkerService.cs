using Application.Models;

namespace Application.RaceSession.Abstractions
{
    public interface IRaceSessionWorkerService
    {
        Task<SessionUpdateDto> CheckForChangesAsync(string sessionId, CancellationToken cancellationToken);
    }
}