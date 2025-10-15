using Domain.Models;
using Infrastructure.Sessions.Abstractions;
using System.Text.Json;

namespace Infrastructure.Sessions
{
    public class SessionsClient : ISessionsClient
    {
        private const string SessionsEndpointUrl = "sessions";

        private readonly HttpClient _httpClient;

        public SessionsClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<List<SessionDetailDto>> GetCurrentStateAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(SessionsEndpointUrl, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return new List<SessionDetailDto>();
            }

            string? jsonContent = await response.Content.ReadAsStringAsync(cancellationToken);

            return jsonContent != null ? JsonSerializer.Deserialize<List<SessionDetailDto>>(jsonContent) : new List<SessionDetailDto>();
        }
    }
}
