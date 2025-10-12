namespace Application.State.Abstractions
{
    public interface ISessionTrackingService
    {
        void AddConnection(string connectionId, string sessionId);
        void RemoveConnection(string connectionId);
        IEnumerable<string> GetActiveSessions();
    }
}
