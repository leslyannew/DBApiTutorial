using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class GetOffices
    {
        public class Query : IRequest<ActionResult<IEnumerable<OfficeDto>>>
        {

        }


        public class Handler : IRequestHandler<Query, ActionResult<IEnumerable<OfficeDto>>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<ActionResult<IEnumerable<OfficeDto>>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Offices
                   .AsNoTracking()
                   .ProjectTo<OfficeDto>(_mapper.ConfigurationProvider)
                   .ToListAsync();
            }
        }

    }
    
}
