using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Features.Offices.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Offices
{
    //[Route("api/Regions/{regionId}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    { 
        private readonly IMediator _mediator;

        public OfficesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeDto>>> GetOffices()
        {
            var result = await _mediator.Send(new GetOffices.Query());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffice(int id)
        {
            var result = await _mediator.Send(new GetOfficeById.Query() { Id = id });
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<OfficeDto>> CreateOffice([FromBody] OfficeCreateDto officeToCreate)
        {
            var result = await _mediator.Send(new CreateOffice.Command() { Office =  officeToCreate });
            if(result == null)
            {
                return NotFound("Region does not exist or already has an existing office.");
            }
            return Created($"offices/{result.Id}", result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOffice(int id, [FromBody] OfficeUpdateDto officeToUpdate)
        {
            var result = await _mediator.Send(new UpdateOffice.Command() { Id = id, Office = officeToUpdate });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOffice(int id)
        {
            var result = await _mediator.Send(new DeleteOffice.Command() { Id = id });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
