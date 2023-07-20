using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace DBApiTutorial.Features.Regions.DTO
{
    public class RegionCreateDto
    {
        [Required(ErrorMessage = "Please provide a Region Number.")]
        public string RegionNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please provide a Name value.")]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
    }
}
