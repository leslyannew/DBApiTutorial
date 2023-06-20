using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class DeleteOffice
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command, int>
        {
            private readonly OrgDBContext _context;

            public Handler(OrgDBContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var officeEntity = await _context.Offices.Where(r => r.Id == command.Id).FirstOrDefaultAsync();
                if (officeEntity == null)
                {
                    return -1;
                }
                _context.Offices.Remove(officeEntity);
                return await _context.SaveChangesAsync();
            }
        }

    }
}
