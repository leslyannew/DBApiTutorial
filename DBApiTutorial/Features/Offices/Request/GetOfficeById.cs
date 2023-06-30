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
    public class GetOfficeById
    {
        public class Query : IRequest<ActionResult<OfficeDto>>
        {
            public int Id { get; set; }
        }


        public class Handler : IRequestHandler<Query, ActionResult<OfficeDto>>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ActionResult<OfficeDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var office = await _context.Offices
                   .Where(r => r.Id == request.Id)
                   .AsNoTracking()
                   .ProjectTo<OfficeDto>(_mapper.ConfigurationProvider)
                   .FirstOrDefaultAsync();
                if (office == null)
                {
                    throw new ArgumentNullException();
                }
                return office;
            }
        }

    }

}