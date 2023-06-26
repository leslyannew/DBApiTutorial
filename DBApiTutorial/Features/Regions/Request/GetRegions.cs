using AutoMapper;
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
        public class Query : IRequest<IEnumerable<RegionDto>?>
        {

        }

        
        public class Handler : IRequestHandler<Query, IEnumerable<RegionDto>?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }
            

            public async Task<IEnumerable<RegionDto>?> Handle(Query request, CancellationToken cancellationToken)
            {
                var regions = await _context.Regions.OrderBy(r => r.Id).ToListAsync();
                return _mapper.Map<IEnumerable<RegionDto>>(regions);
            }
        }
        
    }

}