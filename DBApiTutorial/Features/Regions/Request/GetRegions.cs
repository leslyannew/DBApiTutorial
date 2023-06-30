using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DBApiTutorial.Features.Regions.Request
{
    public class GetRegions
    {
        public class Query : IRequest<ActionResult<IEnumerable<RegionDto>>>
        {

        }

        
        public class Handler : IRequestHandler<Query, ActionResult<IEnumerable<RegionDto>>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }
            

            public async Task<ActionResult<IEnumerable<RegionDto>>> Handle(Query request, CancellationToken cancellationToken)
            { 
                return await _context.Regions
                    .AsNoTracking()
                    .ProjectTo<RegionDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }
        
    }

}