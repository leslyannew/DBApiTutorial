using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Employees.Request;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Features.Offices.Request;
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
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var result = await _mediator.Send(new GetEmployees.Query());
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            var result = await _mediator.Send(new GetEmployeeById.Query() { Id = id });
            if (result == null) 
            { 
                return NotFound(); 
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeCreateDto employeeToCreate)
        {
            var result = await _mediator.Send(new CreateEmployee.Command() { Employee = employeeToCreate });
            if (result == null)
            {
                return BadRequest();
            }
            return Created($"employees/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDto employeeToUpdate)
        {
            var result = await _mediator.Send(new UpdateEmployee.Command() { Id = id, Employee = employeeToUpdate });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            var result = await _mediator.Send(new DeleteEmployee.Command() { Id = id });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
