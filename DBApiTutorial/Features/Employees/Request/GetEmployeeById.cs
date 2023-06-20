using AutoMapper;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class GetEmployeeById
    {
        public class Query : IRequest<IEnumerable<EmployeeDto>>
        {
            public int Id { get; set; }
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
                var employees = await _context.Employees.Where(e => e.Id == request.Id).OrderBy(e => e.Id).ToListAsync();

                return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
            }
        }

    }
}