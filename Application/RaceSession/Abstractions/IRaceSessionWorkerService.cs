namespace Application.RaceSession.Abstractions
{
    public interface IRaceSessionWorkerService
    {
        Task CheckForChangesAsync(CancellationToken cancellationToken);
    }
}