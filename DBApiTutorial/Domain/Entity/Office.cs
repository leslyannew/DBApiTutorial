using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Office
    {
        public int Id { get; set; }
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public int RegionId { get; set; }
        
        //public Region Region { get; set; } = null!;

        //public ICollection<OfficeEmployee> Employees { get; set; } = new List<OfficeEmployee>();
    }
}
