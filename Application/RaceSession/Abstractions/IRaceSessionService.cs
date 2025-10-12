namespace Application.RaceSession.Abstractions
{
    public interface IRaceSessionService
    {
        Task SubscribeAsync(string connectionId, string sessionId);
    }
}
