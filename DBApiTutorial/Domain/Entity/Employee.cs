using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Employee : BaseEntity
    {
        [MaxLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(50)] 
        public string LastName { get; set; } = string.Empty;
    }
}
