using System.ComponentModel.DataAnnotations.Schema;

namespace DBApiTutorial.Domain.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
