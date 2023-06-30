using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class GetEmployeeById
    {
        public class Query : IRequest<ActionResult<EmployeeDto>>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, ActionResult<EmployeeDto>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<ActionResult<EmployeeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employees
                    .Where(r => r.Id == request.Id)
                    .AsNoTracking()
                    .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                    .FirstOrDefaultAsync();
                if (employee == null)
                {
                    throw new ArgumentNullException();
                }
                return employee;
            }
        }

    }
}