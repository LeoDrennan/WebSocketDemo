namespace Application.State.Abstractions
{
    public interface ISessionTrackingService
    {
        void AddSession(string sessionId);
        void RemoveSession(string sessionId);
        IEnumerable<string> GetActiveSessions();
    }
}
