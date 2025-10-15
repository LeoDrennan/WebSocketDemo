using Domain.Models;
using Infrastructure.JSON;
using Infrastructure.RaceSession.Abstractions;
using System.Text.Json;

namespace Infrastructure.RaceSession
{
    public class RaceSessionClient : IRaceSessionClient
    {
        private const string SessionsEndpointUrl = "sessions/";

        private readonly HttpClient _httpClient;

        public RaceSessionClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RaceSessionDto?> GetCurrentStateAsync(string sessionId, CancellationToken cancellationToken)
        {
            string url = GetUrl(sessionId);

            var response = await _httpClient.GetAsync(url, cancellationToken);

            // Should implement a backoff policy for 429 responses here
            if (!response.IsSuccessStatusCode)
            {
                return new RaceSessionDto();
            }

            string? jsonContent = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<RaceSessionDto?>(jsonContent, JsonDefaults.CaseInsensitive);
        }

        private static string GetUrl(string sessionId) => $"{SessionsEndpointUrl}/{sessionId}";
    }
}