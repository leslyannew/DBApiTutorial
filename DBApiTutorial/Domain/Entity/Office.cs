using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Office
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = "LA";
        public string? Phone { get; set; }
    }
}
