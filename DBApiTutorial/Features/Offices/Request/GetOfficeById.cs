using AutoMapper;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Offices.Request
{
    public class GetOfficeById
    {
        public class Query : IRequest<OfficeDto>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, OfficeDto>
        {
            private readonly OrgDBContext _context;
            private readonly IMapper _mapper;

            public Handler(OrgDBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OfficeDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var office = await _context.Offices.Where(o => o.Id == request.Id).FirstOrDefaultAsync();
                return _mapper.Map<OfficeDto>(office);
            }
        }

    }

}