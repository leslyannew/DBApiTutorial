using AutoMapper;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class GetOffices
    {
        public class Query : IRequest<IEnumerable<OfficeDto>>
        {

        }


        public class Handler : IRequestHandler<Query, IEnumerable<OfficeDto>>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }


            public async Task<IEnumerable<OfficeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var offices = await _context.Offices.OrderBy(o => o.Id).ToListAsync();
                return _mapper.Map<IEnumerable<OfficeDto>>(offices);
            }
        }

    }
    
}
