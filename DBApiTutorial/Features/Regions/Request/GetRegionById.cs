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
    public class GetRegionById
    {
        public class Query : IRequest<RegionDto>
        {
            public int Id { get; set; } 
        }

        
        public class Handler : IRequestHandler<Query, RegionDto>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
               _context = context;
               _mapper = mapper;
            }
            
            public async Task<RegionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var region = await _context.Regions.Where(r => r.Id == request.Id).FirstOrDefaultAsync();
                return _mapper.Map<RegionDto>(region);
            }
        }
        
    }

}