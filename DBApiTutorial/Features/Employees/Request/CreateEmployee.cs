using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Employees.Request
{
    public class CreateEmployee
    {
        public class Command : IRequest<ActionResult<EmployeeDto>>
        {
            public EmployeeCreateDto Employee { get; set; } = new EmployeeCreateDto();
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
                var employeeEntity = _mapper.Map<Employee>(command.Employee);
                await _context.Employees.AddAsync(employeeEntity);
                await _context.SaveChangesAsync();
                return _mapper.Map<EmployeeDto>(employeeEntity);
            }
        }

    }

}