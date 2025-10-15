using Domain.Models;

namespace Shared.Sessions.Abstractions
{
    public interface ISessionsBroadcastService
    {
        Task BroadcastUpdateAsync(List<SessionDetailDto> sessions, CancellationToken cancellationToken);
    }
}