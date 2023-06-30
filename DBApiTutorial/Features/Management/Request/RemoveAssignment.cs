using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class RemoveAssignment
    {
        public class Command : IRequest<int>
        {
            public int EmployeeId { get; set; }
            public int OfficeId { get; set; } 
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
                var offices = _context.OfficeEmployees.Where(oe => oe.OfficeId == command.OfficeId && oe.EmployeeId == command.EmployeeId);
                foreach (OfficeEmployee office in offices)
                {
                    _context.OfficeEmployees.Remove(office);
                }

                return await _context.SaveChangesAsync();
            }
        }
    }
}
