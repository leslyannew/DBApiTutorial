using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.GamePublisher
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Genre { get; set; }
        public decimal? Price { get; set; }
        public int? Sales { get; set; }

        public int StudioId { get; set; }
        public Studio Studio { get; set; } //= default!;

        /*
        public int? SoundtrackId { get; set; }
        public Soundtrack? Soundtrack { get; set; } //= default!;
        */

        public ICollection<Developer> Developers { get; set; } = new List<Developer>();

        public Game(string title)
        {
            Title = title;
        }

    }
}
