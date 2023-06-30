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
            private readonly DBContext _context;

            public Handler(DBContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var employeeEntity = await _context.Employees
                    .Where(r => r.Id == command.Id)
                    .FirstOrDefaultAsync();
                if (employeeEntity == null)
                {
                    throw new ArgumentNullException();
                }
                _context.Employees.Remove(employeeEntity);
                await _context.SaveChangesAsync();
                return command.Id;
            }
        }

    }
}
