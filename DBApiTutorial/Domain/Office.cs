using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain
{
    public class Office : BaseEntity
    {
        public int RegionId { get; set; }

        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        [MaxLength(15)]
        public string State { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Phone { get; set; }
    }
}
