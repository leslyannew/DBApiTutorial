using DBApiTutorial.Domain.Entity;

namespace DBApiTutorial.Features.Addition.DTO
{
    public class SoundtrackDto
    {
        public int Id { get; set; }
        public string Composer { get; set; } 
        public string? Producer { get; set; } 
        public int? Length { get; set; }

    }
}
