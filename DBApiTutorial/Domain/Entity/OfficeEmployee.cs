using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class OfficeEmployee : BaseEntity
    {        
        public int EmployeeId { get; set; }

        public int OfficeId { get; set; }
    }
}
