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
    public class CreateRegion
    {
        public class Command : IRequest<RegionDto>
        {
            public RegionCreateDto Region { get; set; } = new RegionCreateDto();
        }

        
        public class Handler : IRequestHandler<Command, RegionDto>
        {
            private readonly CompanyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(CompanyDBContext context, IMapper mapper)
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