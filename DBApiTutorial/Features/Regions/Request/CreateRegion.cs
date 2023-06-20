using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;

namespace DBApiTutorial.Features.Regions.Request
{
    public class CreateRegion
    {
        public class Command : IRequest<RegionDto>
        {
            public RegionCreateDto Region { get; set; } = new RegionCreateDto();
        }

        
        public class Handler : IRequestHandler<Command, RegionDto>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }
            
            public async Task<RegionDto> Handle(Command command, CancellationToken cancellationToken)
            {
                var regionEntity = _mapper.Map<Region>(command.Region);
                await _context.Regions.AddAsync(regionEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<RegionDto>(regionEntity);
            }
        }
        
    }

}