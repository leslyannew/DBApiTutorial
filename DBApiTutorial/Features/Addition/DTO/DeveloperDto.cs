using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Features.Addition.DTO
{
    public class DeveloperDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? Role { get; set; } 

        public ICollection<Game>? Games { get; set; } = new List<Game>();
    }
}
