using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Other
{
    public class OfficeEmployee
    {
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        public int EmployeeId { get; set; }

        [ForeignKey("OfficeId")]
        public int OfficeId { get; set; }
    }
}
