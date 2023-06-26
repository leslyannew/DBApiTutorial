using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.OfficeEmployees.Request
{
    public class GetEmployeesByOfficeId
    {
        public class Query : IRequest<IEnumerable<EmployeeDto>?>  
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, IEnumerable<EmployeeDto>?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<EmployeeDto>?> Handle(Query request, CancellationToken cancellationToken)
            {

                var employeeEntities = await _context.OfficeEmployees
                                .Where(offEmp => offEmp.OfficeId == request.Id)
                                .Join(_context.Employees,
                                offEmp => offEmp.EmployeeId,
                                emp => emp.Id,
                                (offEmp, emp) => new Employee
                                {
                                    Id = emp.Id,
                                    FirstName = emp.FirstName, 
                                    LastName = emp.LastName

                                }).ToListAsync();

                if (employeeEntities.Count == 0)
                {
                    return null;
                }

                return _mapper.Map<IEnumerable<EmployeeDto>>(employeeEntities);
            }
        }
    }

}
