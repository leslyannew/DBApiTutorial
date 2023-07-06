using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Offices.DTO;
using DBApiTutorial.Features.Offices.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Offices
{
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
            try
            {
                var result = await _mediator.Send(new GetOffices.Query());
                return Ok(result);
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OfficeDto>> GetOffice(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetOfficeById.Query() { Id = id });
                return Ok(result);
            } 
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<OfficeDto>> CreateOffice([FromBody] OfficeCreateDto office)
        {
            try
            {
                var result = await _mediator.Send(new CreateOffice.Command() { Office = office });
                return Created($"offices/{result.Value.Id}", result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<OfficeDto>> UpdateOffice(int id, [FromBody] OfficeUpdateDto officeToUpdate)
        {
            try 
            {
                var result = await _mediator.Send(new UpdateOffice.Command() { Id = id, Office = officeToUpdate });
                return Ok(result);
            } 
            catch
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteOffice(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteOffice.Command() { Id = id });
                return Ok($"Removed Office {result}");
            } 
            catch
            {
                return NotFound();
            }
        }
    }
}
