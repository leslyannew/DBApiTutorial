using System.ComponentModel.DataAnnotations;

namespace DBApiTutorial.Domain.Entity
{
    public class Region : BaseEntity
    {
        [MaxLength(50)]
        public string RegionNumber { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;

    }
}
