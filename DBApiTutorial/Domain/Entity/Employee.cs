using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<OfficeEmployee> Offices { get; set; } = new List<OfficeEmployee>();

        //public Employee(int id, int officeId, string? firstName, string? lastName)
        //{
        //    Id = id;
        //    OfficeId = officeId;
        //}
    }
}
