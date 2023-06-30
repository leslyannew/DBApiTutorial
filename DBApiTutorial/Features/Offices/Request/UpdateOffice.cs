using AutoMapper;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class UpdateOffice
    {
        public class Command : IRequest<ActionResult<OfficeDto>>
        {
            public int Id { get; set; }
            public OfficeUpdateDto Office { get; set; } = new OfficeUpdateDto();
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
                var officeEntity = await _context.Offices.Where(o => o.Id == command.Id).FirstOrDefaultAsync();
                if (officeEntity == null)
                {
                    throw new ArgumentNullException();
                }
                var updatedOffice = _mapper.Map(command.Office, officeEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<OfficeDto>(updatedOffice);
            }
        }
    }
}
