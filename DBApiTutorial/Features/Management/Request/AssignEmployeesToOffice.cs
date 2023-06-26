using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class AssignEmployeesToOffice
    {
        public class Command : IRequest<int>
        {
            public int OfficeId { get; set; }
            public int[] EmployeeIds { get; set; } = Array.Empty<int>();
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
                foreach (int employeeId in command.EmployeeIds)
                {
                    if (!_context.OfficeEmployees.Where(oe => oe.EmployeeId == employeeId && oe.OfficeId == command.OfficeId).Any())
                    {
                        await _context.OfficeEmployees.AddAsync
                        (new OfficeEmployee
                        {
                            OfficeId = command.OfficeId,
                            EmployeeId = employeeId
                        });
                    }
                }

                return await _context.SaveChangesAsync();
            }
        }
    }
}
