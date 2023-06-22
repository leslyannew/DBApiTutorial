using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class DeleteEmployee
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
                var employeeEntity = await _context.Employees.Where(e => e.Id == command.Id).FirstOrDefaultAsync();
                if (employeeEntity == null)
                {
                    return -1;
                }
                _context.Employees.Remove(employeeEntity);
                return await _context.SaveChangesAsync();
            }
        }

    }
}
