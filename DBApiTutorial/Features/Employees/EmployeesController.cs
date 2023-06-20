using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Employees.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Offices
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeWithOfficesDto>>> GetEmployees()
        {
            var result = await _mediator.Send(new GetEmployees.Query());
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeWithOfficesDto>> GetEmployeeById(int id, bool includeOffices = false)
        {
            if (includeOffices)
            {
                return Ok(await _mediator.Send(new GetEmployeeByIdWithOffices.Query() { Id = id }));
            }

            return Ok(await _mediator.Send(new GetEmployeeById.Query() { Id = id }));
        }
    }
}
