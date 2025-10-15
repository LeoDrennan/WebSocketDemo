using Domain.Models;

namespace Infrastructure.Sessions.Abstractions
{
    public interface ISessionsClient
    {
        Task<List<SessionDetailDto>> GetCurrentStateAsync(CancellationToken cancellationToken);
    }
}