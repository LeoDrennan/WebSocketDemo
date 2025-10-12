using Application.State.Abstractions;
using System.Collections.Concurrent;

namespace Application.State
{
    // This implementation does not scale, but keeping things simple for the demo app
    public class SessionTrackingService : ISessionTrackingService
    {
        private readonly ConcurrentDictionary<string, string> _sessionIdByConnectionId = new();

        public void AddConnection(string connectionId, string sessionId)
        {
            _sessionIdByConnectionId.TryAdd(connectionId, sessionId);
        }

        public void RemoveConnection(string connectionId)
        {
            _sessionIdByConnectionId.TryRemove(connectionId, out _);
        }

        public IEnumerable<string> GetActiveSessions()
        {
            return _sessionIdByConnectionId.Values.Distinct();
        }
    }
}