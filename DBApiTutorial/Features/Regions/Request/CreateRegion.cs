using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Regions.Request
{
    public class CreateRegion
    {
        public class Command : IRequest<ActionResult<RegionDto>>
        {
            public RegionCreateDto Region { get; set; }
        }

        
        public class Handler : IRequestHandler<Command, ActionResult<RegionDto>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }
            
            public async Task<ActionResult<RegionDto>> Handle(Command command, CancellationToken cancellationToken)
            {
                var regionEntity = _mapper.Map<Region>(command.Region);
                await _context.Regions.AddAsync(regionEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<RegionDto>(regionEntity);
            }
        }
        
    }

}