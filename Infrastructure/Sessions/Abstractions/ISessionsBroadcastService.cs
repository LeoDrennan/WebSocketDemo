using Domain.Models;

namespace Infrastructure.Sessions.Abstractions
{
    public interface ISessionsBroadcastService
    {
        Task BroadcastUpdateAsync(List<SessionDetailDto> sessions, CancellationToken cancellationToken);
    }
}