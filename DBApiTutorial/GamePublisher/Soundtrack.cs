using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.GamePublisher
{
    public class Soundtrack
    {
        public int Id { get; set; }
        public string? Composer { get; set; }
        public string? Producer { get; set; }
        public int? Length { get; set; }
        public decimal? Price { get; set; }
        public int? Sales { get; set; }


        public int GameId { get; set; }
        public Game Game { get; set; } //= default!;

    }
}
