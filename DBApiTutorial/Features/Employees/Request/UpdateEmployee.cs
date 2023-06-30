using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class UpdateEmployee
    {
        public class Command : IRequest<ActionResult<EmployeeDto>>
        {
            public int Id { get; set; }
            public EmployeeUpdateDto Employee { get; set; } = new EmployeeUpdateDto();
        }

        public class Handler : IRequestHandler<Command, ActionResult<EmployeeDto>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ActionResult<EmployeeDto>> Handle(Command command, CancellationToken cancellationToken)
            {
                var regionEntity = await _context.Employees
                    .Where(r => r.Id == command.Id)
                    .FirstOrDefaultAsync();
                if (regionEntity == null)
                {
                    throw new ArgumentNullException();
                }
                var updatedEntity = _mapper.Map(command.Employee, regionEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmployeeDto>(updatedEntity);
            }
        }
    }
}
