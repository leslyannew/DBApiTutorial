using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class GetEmployeeByIdWithOffices
    {
        public class Query : IRequest<EmployeeWithOfficesDto>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, EmployeeWithOfficesDto?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<EmployeeWithOfficesDto?> Handle(Query request, CancellationToken cancellationToken)
            {
                var employeeWithOffices = await (
                    from employee in _context.Employees
                    where employee.Id == request.Id
                    select new EmployeeWithOfficesDto
                    {
                        Id = employee.Id,
                        FirstName = employee.FirstName,
                        LastName = employee.LastName,
                        Offices = (from office in _context.Offices
                                   join officeEmp in _context.OfficeEmployees on office.Id equals officeEmp.OfficeId
                                   where employee.Id == officeEmp.EmployeeId
                                   select new OfficeDto
                                   {
                                       Id = office.Id,
                                       RegionId = office.RegionId,
                                       City = office.City,
                                       State = office.State,
                                       Phone = office.Phone

                                   }).ToList()

                    }).FirstOrDefaultAsync();
                return employeeWithOffices;




                //var emp = _context.Employees.Where(e => e.Id == request.Id).FirstOrDefault();
                //var offEmp = _context.OfficeEmployees.Where(oe => oe.EmployeeId == request.Id).AsEnumerable();
                //IEnumerable<Office> offices = new List<Office>();
                //IEnumerable<OfficeDto> officeDtos = new List<OfficeDto>();
                //foreach(OfficeEmployee off in offEmp)
                //{
                //    offices = await _context.Offices.Where(o => o.Id == off.OfficeId).ToListAsync();
                //}
                //foreach(Office office in offices)
                //{
                //    officeDtos = _mapper.Map<OfficeDto>(office);
                //}

                //EmployeeWithOfficesDto dto = new EmployeeWithOfficesDto(offices);


            }
        }
    }
        
}
