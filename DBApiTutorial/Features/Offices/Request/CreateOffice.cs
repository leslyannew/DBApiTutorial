using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class CreateOffice
    {
        public class Command : IRequest<ActionResult<OfficeDto>>
        {
            public OfficeCreateDto Office { get; set; } = new OfficeCreateDto();
        }


        public class Handler : IRequestHandler<Command, ActionResult<OfficeDto>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ActionResult<OfficeDto>> Handle(Command command, CancellationToken cancellationToken)
            {
                //check if the Region exists or if an Office exists in this Region
                if (!await _context.Regions.AnyAsync(r => r.Id == command.Office.RegionId) || await _context.Offices.AnyAsync(o => o.RegionId == command.Office.RegionId))
                {
                    throw new ArgumentNullException();
                }

                var officeEntity = _mapper.Map<Office>(command.Office);
                await _context.Offices.AddAsync(officeEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<OfficeDto>(officeEntity);
            }
        }

    }

}