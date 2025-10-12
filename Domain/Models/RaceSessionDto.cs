namespace Domain.Models
{
    public record RaceSessionDto
    {
        public string TimeRemaining { get; set; } = string.Empty;
        public List<CompetitorDto> Competitors { get; set; } = [];
        public Guid SessionId { get; set; } = Guid.Empty;
        public string Series { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Track { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public DateTimeOffset StartTime { get; set; } = DateTimeOffset.Now;
        public string Duration { get; set; } = string.Empty;
    }
}