using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DBApiTutorial.Features.Regions.Request
{
    public class DeleteRegion
    {
        public class Command : IRequest<int>
        {
            public int Id { get; set; }
        }

        
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly DBContext _context;

            public Handler(DBContext context)
            {
               _context = context;
            }
            
            public async Task<int> Handle(Command command, CancellationToken cancellationToken)
            {
                var regionEntity = await _context.Regions
                    .Where(r => r.Id == command.Id)
                    .FirstOrDefaultAsync();
                if (regionEntity == null)
                {
                    throw new ArgumentNullException();
                }
                _context.Regions.Remove(regionEntity);
                await _context.SaveChangesAsync();
                return command.Id;
            }
        }
        
    }

}