using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Employees.Request;
using DBApiTutorial.Features.OfficeEmployees.Request;
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
        public async Task<ActionResult> GetOfficesByEmployeeId(int employeeId)
        {
            var offices = await _mediator.Send(new GetOfficesByEmployeeId.Query() { Id = employeeId });
            if (offices == null)
            {
                return NotFound();
            }
            return Ok(offices);
        }

        [HttpGet("{officeId}/employees")]
        public async Task<ActionResult> GetEmployeesByOfficeId(int officeId)
        {
            var employees = await _mediator.Send(new GetEmployeesByOfficeId.Query() { Id = officeId });
            if (employees == null)
            {
                return NotFound();
            }
            return Ok(employees);
        }

        [HttpPost("{employeeId}/offices")]
        public async Task<ActionResult> AssignOfficesToEmployee(int employeeId, int[] officeIds)
        {
            var result = await _mediator.Send(new AssignOfficesToEmployee.Command() { EmployeeId = employeeId, OfficeIds = officeIds });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost("{officeId}/employees")]
        public async Task<ActionResult> AssignEmployeesToOffice(int officeId, int[] employeeIds)
        {
            var result = await _mediator.Send(new AssignEmployeesToOffice.Command() { OfficeId = officeId, EmployeeIds = employeeIds });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{employeeId}-{officeId}")]
        public async Task<ActionResult> RemoveAssignment(int employeeId, int officeId)
        {
            var result = await _mediator.Send(new RemoveAssignment.Command() { EmployeeId = employeeId, OfficeId = officeId});
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
