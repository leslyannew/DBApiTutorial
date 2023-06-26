using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class UpdateEmployee
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
            public EmployeeUpdateDto Employee { get; set; } = new EmployeeUpdateDto();
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
                
                var employeeEntity = await _context.Employees.Where(e => e.Id == command.Id).FirstOrDefaultAsync();
                if (employeeEntity == null)
                {
                    return -1;
                }
                _mapper.Map(command.Employee, employeeEntity);
                return await _context.SaveChangesAsync();
            }
        }
    }
}
