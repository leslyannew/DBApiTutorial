using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Regions.DTO;

namespace DBApiTutorial.Features.Regions
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>();
            CreateMap<RegionCreateDto, Region>();
            CreateMap<RegionUpdateDto, Region>();
        }
    }
}
