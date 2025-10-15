using System.Text.Json;

namespace Infrastructure.JSON
{
    internal static class JsonDefaults
    {
        internal static readonly JsonSerializerOptions CaseInsensitive = new()
        {
            PropertyNameCaseInsensitive = true
        };
    }
}