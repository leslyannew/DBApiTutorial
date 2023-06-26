using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DBApiTutorial.Features.OfficeEmployees.Request
{
    public class GetOfficesByEmployeeId
    {
        public class Query : IRequest<IEnumerable<OfficeDto>?>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, IEnumerable<OfficeDto>?>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<IEnumerable<OfficeDto>?> Handle(Query request, CancellationToken cancellationToken)
            {

                var officeEntities = await _context.OfficeEmployees
                                .Where(offEmp => offEmp.EmployeeId == request.Id)
                                .Join(_context.Offices,
                                offEmp => offEmp.OfficeId,
                                off => off.Id,
                                (offEmp, off) => new Office
                                {
                                    Id = off.Id,
                                    RegionId = off.RegionId,
                                    City = off.City,
                                    State = off.State,
                                    Phone = off.Phone
                                }).ToListAsync();

                if (officeEntities.Count == 0) 
                {
                    return null;
                }

                return _mapper.Map<IEnumerable<OfficeDto>>(officeEntities);

            }
        }
    }

}
