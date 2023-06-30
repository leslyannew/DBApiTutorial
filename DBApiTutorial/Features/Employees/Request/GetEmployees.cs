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
    public class GetEmployees
    {
        public class Query : IRequest<ActionResult<IEnumerable<EmployeeDto>>>
        {

        }


        public class Handler : IRequestHandler<Query, ActionResult<IEnumerable<EmployeeDto>>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<ActionResult<IEnumerable<EmployeeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Employees
                    .AsNoTracking()
                    .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                    .ToListAsync();
            }
        }

    }
}