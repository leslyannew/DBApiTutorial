using System.ComponentModel.DataAnnotations;

namespace DBApiTutorial.Features.Regions.DTO
{
    public class RegionUpdateDto
    {
        [Required(ErrorMessage = "Please provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
