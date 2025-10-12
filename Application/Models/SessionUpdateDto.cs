using Domain.Models;

namespace Application.Models
{
    public class SessionUpdateDto
    {
        public bool IsUpdated { get; set; }
        public RaceSessionDto? RaceSession { get; set; }
    }
}