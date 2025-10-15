namespace Domain.Models
{
    public record SessionDetailDto
    {
        public Guid SessionId { get; set; }
        public string Series { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Track { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTimeOffset? StartTime { get; set; }
        public string Duration { get; set; } = string.Empty;
    }
}