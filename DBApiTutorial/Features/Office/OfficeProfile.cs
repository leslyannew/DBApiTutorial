using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Addition.DTO;

namespace DBApiTutorial.Features.Office
{
    public class OfficeProfile : Profile
    {
        public OfficeProfile()
        {
            CreateMap<Office, OfficeDto>();
            CreateMap<OfficeCreateDto, Office>();
        }
    }
}
