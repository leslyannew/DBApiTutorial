using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Features.Addition.DTO
{
    public class StudioDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Developer>? Developers { get; set; } = new List<Developer>();
        public ICollection<Game>? Games { get; set; } = new List<Game>();

    }
}
