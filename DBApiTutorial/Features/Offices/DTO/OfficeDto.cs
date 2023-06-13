namespace DBApiTutorial.Features.Offices.DTO
{
    public class OfficeDto
    {
        public int Id { get; set; }
        public string Building { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public int RegionId { get; set; }
    }
}
