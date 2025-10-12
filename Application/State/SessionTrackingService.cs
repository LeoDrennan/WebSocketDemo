using Application.State.Abstractions;
using System.Collections.Concurrent;

namespace Application.State
{
    // This implementation does not scale, but keeping things simple for the demo app
    public class SessionTrackingService : ISessionTrackingService
    {
        private readonly ConcurrentDictionary<string, byte> _sessions = new();

        public void AddSession(string sessionId)
        {
            _sessions.TryAdd(sessionId, 0);
        }

        public void RemoveSession(string sessionId)
        {
            _sessions.TryRemove(sessionId, out _);
        }

        public IEnumerable<string> GetActiveSessions()
        {
            return _sessions.Keys;
        }
    }
}