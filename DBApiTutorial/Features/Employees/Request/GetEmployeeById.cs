using AutoMapper;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class GetEmployeeById
    {
        public class Query : IRequest<EmployeeDto?>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, EmployeeDto?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<EmployeeDto?> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees.Where(e => e.Id == request.Id).FirstOrDefaultAsync();
                if (employee == null)
                {
                    return null;
                }
                return _mapper.Map<EmployeeDto>(employee);
            }
        }

    }
}