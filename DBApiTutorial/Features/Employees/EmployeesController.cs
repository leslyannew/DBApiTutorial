using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Employees.Request;
using DBApiTutorial.Features.Regions.Request;
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
            try
            {
                var result = await _mediator.Send(new GetEmployees.Query());
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployeeById(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetEmployeeById.Query() { Id = id });
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> CreateEmployee([FromBody] EmployeeCreateDto employee)
        {
            try
            {
                var result = await _mediator.Send(new CreateEmployee.Command() { Employee = employee });
                return Created($"employees/{result.Value.Id}", result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] EmployeeUpdateDto employee)
        {
            try
            {
                var result = await _mediator.Send(new UpdateEmployee.Command() { Id = id, Employee = employee });
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmployee(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteEmployee.Command() { Id = id });
                return Ok($"Removed Employee {result}");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
