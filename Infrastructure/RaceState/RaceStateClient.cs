using Domain.Models;
using Infrastructure.RaceState.Abstractions;

namespace Infrastructure.RaceState
{
    public class RaceStateClient : IRaceStateClient
    {
        public Task<RaceStateDTO> GetCurrentStateAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}