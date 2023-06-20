using DBApiTutorial.Features.Employees.DTO;

namespace DBApiTutorial.Features.Offices.DTO
{
    public class OfficeDto
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string? Phone { get; set; }
        //public IEnumerable<EmployeeWithOfficesDto> Employees { get; set; } = new List<EmployeeWithOfficesDto>();
    }
}
