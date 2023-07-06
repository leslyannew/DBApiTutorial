using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class AssignOfficesToEmployee
    {
        public class Command : IRequest<int>
        {
            public int EmployeeId { get; set; }
            public int[] OfficeIds { get; set; } = Array.Empty<int>();
        }


        public class Handler : IRequestHandler<Command, int>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                foreach (int officeId in command.OfficeIds)
                {
                    if (!_context.OfficeEmployees.Where(oe => oe.OfficeId == officeId && oe.EmployeeId == command.EmployeeId).Any())
                    {
                        if (_context.Employees.Where(e => e.Id  == command.EmployeeId).Any() && _context.Offices.Where(o => o.Id == officeId).Any())
                        {
                            await _context.OfficeEmployees.AddAsync
                            (new OfficeEmployee
                            {
                                EmployeeId = command.EmployeeId,
                                OfficeId = officeId
                            });
                        }
                        else
                        {
                            throw new ArgumentNullException();
                        }
                        
                    }
                }
                await _context.SaveChangesAsync();
                return command.EmployeeId;
            }
        }
    }
}
