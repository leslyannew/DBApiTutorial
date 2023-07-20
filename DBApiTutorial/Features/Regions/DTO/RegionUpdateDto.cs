using System.ComponentModel.DataAnnotations;

namespace DBApiTutorial.Features.Regions.DTO
{
    public class RegionUpdateDto
    {
        [Required(ErrorMessage = "Please provide a Region Number.")]
        public string RegionNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
