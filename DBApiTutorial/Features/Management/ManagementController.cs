using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.DTO;
using DBApiTutorial.Features.Employees.Request;
using DBApiTutorial.Features.OfficeEmployees.Request;
using DBApiTutorial.Features.Offices.DTO;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.OfficeEmployees
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagementController : ControllerBase
    {
        private IMediator _mediator;

        public ManagementController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        [HttpGet("{employeeId}/offices")]
        public async Task<ActionResult<OfficeDto>> GetOfficesByEmployeeId(int employeeId)
        {
            try
            {
                var offices = await _mediator.Send(new GetOfficesByEmployeeId.Query() { Id = employeeId });
                return Ok(offices);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            
        }

        [HttpGet("{officeId}/employees")]
        public async Task<ActionResult<EmployeeDto>> GetEmployeesByOfficeId(int officeId)
        {
            try
            {
                var employees = await _mediator.Send(new GetEmployeesByOfficeId.Query() { Id = officeId });
                return Ok(employees);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost("{employeeId}/offices")]
        public async Task<ActionResult<int>> AssignOfficesToEmployee(int employeeId, int[] officeIds)
        {
            try
            {
                var result = await _mediator.Send(new AssignOfficesToEmployee.Command() { EmployeeId = employeeId, OfficeIds = officeIds });
                return Ok($"Employee {result} updated.");
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
            
        }

        [HttpPost("{officeId}/employees")]
        public async Task<ActionResult<int>> AssignEmployeesToOffice(int officeId, int[] employeeIds)
        {           
            try
            {
                var result = await _mediator.Send(new AssignEmployeesToOffice.Command() { OfficeId = officeId, EmployeeIds = employeeIds });
                return Ok($"Office {result} updated.");
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{officeId}-{employeeId}")]
        public async Task<ActionResult<string>> RemoveAssignment(int officeId, int employeeId)
        {
            try
            {
                var result = await _mediator.Send(new RemoveAssignment.Command() { OfficeId = officeId , EmployeeId = employeeId, });
                return Ok($"Assignment between {result} removed.");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }
    }
}
