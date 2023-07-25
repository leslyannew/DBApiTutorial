using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Regions.Request
{
    public class GetRegionById
    {
        public class Query : IRequest<ActionResult<RegionDto>>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, ActionResult<RegionDto>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ActionResult<RegionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var region = await _context.Regions
                    .Where(r => r.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<RegionDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
                if (region == null)
                {
                    throw new ArgumentNullException();
                }
                return region;
            }
        }

    }

}