using AutoMapper;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class GetEmployees
    {
        public class Query : IRequest<IEnumerable<EmployeeDto>>
        {

        }


        public class Handler : IRequestHandler<Query, IEnumerable<EmployeeDto>>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<IEnumerable<EmployeeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employees = await _context.Employees.OrderBy(o => o.Id).ToListAsync();

                return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            }
        }

    }
}