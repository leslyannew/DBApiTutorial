﻿using AutoMapper;
using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DBApiTutorial.Features.Employees.Request
{
    public class RemoveAssignment
    {
        public class Command : IRequest<string>
        {
            public int EmployeeId { get; set; }
            public int OfficeId { get; set; } 
        }


        public class Handler : IRequestHandler<Command, string>
        {
            private readonly DBContext _context;
            private readonly IMapper _mapper;

            public Handler(DBContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<string> Handle(Command command, CancellationToken cancellationToken)
            {
                var assignment = _context.OfficeEmployees.Where(oe => oe.OfficeId == command.OfficeId && oe.EmployeeId == command.EmployeeId).FirstOrDefault();
                if (assignment == null) 
                {
                    throw new ArgumentNullException();
                }
                assignment.IsDeleted = true;
                await _context.SaveChangesAsync();
                return $"Office {command.OfficeId} and Employee {command.EmployeeId}";
            }
        }
    }
}
