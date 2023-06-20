using AutoMapper;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class UpdateOffice
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
            public OfficeUpdateDto Office { get; set; } = new OfficeUpdateDto();
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
                var officeEntity = await _context.Offices.Where(r => r.Id == command.Id).FirstOrDefaultAsync();
                if (officeEntity == null)
                {
                    return -1;
                }
                _mapper.Map(command.Office, officeEntity);
                return await _context.SaveChangesAsync();
            }
        }
    }
}
