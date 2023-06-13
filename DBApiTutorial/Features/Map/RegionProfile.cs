using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Addition.DTO;

namespace DBApiTutorial.Features.Addition.Map
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<RegionCreateDto, Region>();
        }
    }
}
