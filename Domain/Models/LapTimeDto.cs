namespace Domain.Models
{
    public record LapTimeDto
    {
        public string Display { get; set; } = string.Empty;
        public long RawMs { get; set; }
    }
}