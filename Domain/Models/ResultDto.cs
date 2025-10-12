namespace Domain.Models
{
    public record ResultDto
    {
        public int Position { get; set; }
        public bool Finished { get; set; }
        public int Laps { get; set; }
        public LapTimeDto? FastestLapTime { get; set; }
        public LapTimeDto? LastLapTime { get; set; }
    }
}
