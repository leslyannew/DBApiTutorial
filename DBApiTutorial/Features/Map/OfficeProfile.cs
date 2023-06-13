using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Addition.DTO;

namespace DBApiTutorial.Features.Addition.Map
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile() 
        {
            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeDto, Office>();
        }
    }
}
