using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class CreateOffice
    {
        public class Command : IRequest<OfficeDto?>
        {
            //public int RegionId { get; set; }
            public OfficeCreateDto Office { get; set; } = new OfficeCreateDto();
        }


        public class Handler : IRequestHandler<Command, OfficeDto?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OfficeDto?> Handle(Command command, CancellationToken cancellationToken)
            {
                //check if the Region exists or if an Office exists in this Region
                if (!await _context.Regions.AnyAsync(r => r.Id == command.Office.RegionId) || await _context.Offices.AnyAsync(o => o.RegionId == command.Office.RegionId))
                {
                    return null;
                }

                var officeEntity = _mapper.Map<Domain.Entity.Office>(command.Office);
                await _context.Offices.AddAsync(officeEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<OfficeDto>(officeEntity);
            }
        }

    }

}