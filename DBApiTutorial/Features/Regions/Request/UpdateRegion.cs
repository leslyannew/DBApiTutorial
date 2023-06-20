using AutoMapper;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace DBApiTutorial.Features.Regions.Request
{
    public class UpdateRegion
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; } 
            public RegionUpdateDto Region { get; set; } = new RegionUpdateDto();
        }

        
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }
            
            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var regionEntity = await _context.Regions.Where(r => r.Id == command.Id).FirstOrDefaultAsync();
                if (regionEntity == null)
                {
                    return -1;
                }
                _mapper.Map(command.Region, regionEntity);
                return await _context.SaveChangesAsync();
            }
        }
        
    }

}