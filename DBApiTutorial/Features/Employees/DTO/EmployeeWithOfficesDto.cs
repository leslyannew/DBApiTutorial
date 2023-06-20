using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.OfficeEmployees.DTO;
using DBApiTutorial.Features.Offices.DTO;

namespace DBApiTutorial.Features.Employees.DTO
{
    public class EmployeeWithOfficesDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        //public int OfficeId { get; set; }
        //public IEnumerable<int> OfficeIds { get; set; } = new List<int>();
        public IEnumerable<OfficeDto> Offices { get; set; } = new List<OfficeDto>();

    }
}
