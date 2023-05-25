using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Features.Addition.DTO
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Genre { get; set; }
        public decimal? Price { get; set; }

        public ICollection<Developer> Developers { get; set; } = new List<Developer>();

    }
}
