using Application.Models;
using Application.Sessions.Abstractions;
using Microsoft.Extensions.Hosting;

namespace Application.Sessions
{
    public class SessionsWorker : BackgroundService
    {
        private const int RequestIntervalMilliseconds = 10000;

        private readonly ISessionsWorkerService _workerService;

        public SessionsWorker(ISessionsWorkerService sessionsWorkerService)
        {
            _workerService = sessionsWorkerService ?? throw new ArgumentNullException(nameof(_workerService));
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                SessionsUpdateDto dto = await _workerService.CheckForChangesAsync(cancellationToken);

                if (dto.IsUpdated)
                {
                    await _workerService.BroadcastUpdateAsync(dto.Sessions, cancellationToken);
                }

                await Task.Delay(RequestIntervalMilliseconds, cancellationToken);
            }
        }
    }
}