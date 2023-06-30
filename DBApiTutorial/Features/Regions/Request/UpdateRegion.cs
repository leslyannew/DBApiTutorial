using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace DBApiTutorial.Features.Regions.Request
{
    public class UpdateRegion
    {
        public class Command : IRequest<ActionResult<RegionDto>>
        {
            public int Id { get; set; } 
            public RegionUpdateDto Region { get; set; } = new RegionUpdateDto();
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
                var regionEntity = await _context.Regions
                    .Where(r => r.Id == command.Id)
                    .FirstOrDefaultAsync();
                if (regionEntity == null)
                {
                    throw new ArgumentNullException();
                }
                var updatedEntity = _mapper.Map(command.Region, regionEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<RegionDto>(updatedEntity);
            }
        }
        
    }

}