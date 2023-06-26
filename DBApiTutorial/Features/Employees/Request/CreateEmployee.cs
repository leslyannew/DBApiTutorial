using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;

namespace DBApiTutorial.Features.Employees.Request
{
    public class CreateEmployee
    {
        public class Command : IRequest<EmployeeDto?>
        {
            //public int RegionId { get; set; }
            public EmployeeCreateDto Employee { get; set; } = new EmployeeCreateDto();
        }


        public class Handler : IRequestHandler<Command, EmployeeDto?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<EmployeeDto?> Handle(Command command, CancellationToken cancellationToken)
            {
                var employeeEntity = _mapper.Map<Employee>(command.Employee);
                //var officeIds = command.Employee.OfficesIds;

                await _context.Employees.AddAsync(employeeEntity);
                await _context.SaveChangesAsync();

                //if (officeIds != null) 
                //{
                //    foreach (int officeId in officeIds)
                //    {
                //        await _context.OfficeEmployees.AddAsync
                //        (new OfficeEmployee
                //        {
                //            EmployeeId = employeeEntity.Id,
                //            OfficeId = officeId
                //        });
                //    }
                //}
                await _context.SaveChangesAsync();

                return _mapper.Map<EmployeeDto>(employeeEntity);
            }
        }

    }

}