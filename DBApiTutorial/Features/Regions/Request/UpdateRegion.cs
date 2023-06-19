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
    public class UpdateRegion
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; } 
            public RegionUpdateDto Region { get; set; } = new RegionUpdateDto();
        }

        
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly CompanyDBContext _context;
            private readonly IMapper _mapper;

            public Handler(CompanyDBContext context, IMapper mapper)
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