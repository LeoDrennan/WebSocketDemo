using Application.Models;
using Domain.Models;

namespace Application.RaceSession.Abstractions
{
    public interface IRaceSessionWorkerService
    {
        Task BroadcastUpdateAsync(string sessionId, RaceSessionDto dto);
        Task<SessionUpdateDto> CheckForChangesAsync(string sessionId, CancellationToken cancellationToken);
    }
}