using Application.Models;
using Domain.Models;

namespace Application.Sessions.Abstractions
{
    public interface ISessionsWorkerService
    {
        Task BroadcastUpdateAsync(List<SessionDetailDto> dto, CancellationToken cancellationToken);
        Task<SessionsUpdateDto> CheckForChangesAsync(CancellationToken cancellationToken);
    }
}
