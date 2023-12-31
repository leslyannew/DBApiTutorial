﻿namespace DBApiTutorial.Features.Offices.DTO
{
    public class OfficeCreateDto
    {
        public int RegionId { get; set; }
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string? Phone { get; set; }
    }
}
