using Domain.Models;
using Infrastructure.RaceSession.Abstractions;
using System.Text.Json;

namespace Infrastructure.RaceSession
{
    public class RaceSessionClient : IRaceSessionClient
    {
        private const string SessionsEndpointUrl = "sessions";

        private readonly HttpClient _httpClient;

        public RaceSessionClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<RaceSessionDto?> GetCurrentStateAsync(CancellationToken cancellationToken)
        {
            var response = await _httpClient.GetAsync(SessionsEndpointUrl, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                return new RaceSessionDto();
            }

            string? jsonContent = await response.Content.ReadAsStringAsync(cancellationToken);

            return JsonSerializer.Deserialize<RaceSessionDto?>(jsonContent);
        }
    }
}