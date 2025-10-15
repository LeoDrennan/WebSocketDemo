using Domain.Models;

namespace Application.Models
{
    public class SessionsUpdateDto
    {
        public bool IsUpdated { get; set; }
        public List<SessionDetailDto> Sessions { get; set; } = new List<SessionDetailDto>();
    }
}