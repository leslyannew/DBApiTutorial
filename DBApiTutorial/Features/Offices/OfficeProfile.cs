using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Offices.DTO;

namespace DBApiTutorial.Features.Offices
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeCreateDto, Office>();
            CreateMap<OfficeUpdateDto, Office>();
        }
    }
}
