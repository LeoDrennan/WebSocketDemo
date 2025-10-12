namespace Domain.Models
{
    public record CompetitorDto
    {
        public Dictionary<string, LapTimeDto?> CurrentLapSectorTimes { get; set; }
        public Guid Id { get; set; }
        public string StartNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string TeamName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public ResultDto Result { get; set; }
    }
}