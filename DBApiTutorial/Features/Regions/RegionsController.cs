using DBApiTutorial.Domain.Entity;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Features.Regions.Request;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DBApiTutorial.Features.Regions
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RegionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            try
            {
                var result = await _mediator.Send(new GetRegions.Query());
                return Ok(result);
            } 
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}", Name = "regions")]
        public async Task<ActionResult<RegionDto>> GetRegion(int id)
        {
            try
            {
                var result = await _mediator.Send(new GetRegionById.Query() { Id = id });
                return Ok(result);
            } 
            catch (ArgumentNullException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<RegionDto>> CreateRegion(
            [FromBody][Required(ErrorMessage = "Provide a Region to create.")] RegionCreateDto region)
        { 
            try
            {
                var result = await _mediator.Send(new CreateRegion.Command() { Region = region });
                return Created($"regions/{result.Value.Id}", result);
            }
            catch (ArgumentNullException)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RegionDto>> UpdateRegion(int id,
            [FromBody][Required(ErrorMessage = "Provide an updated Region.")] RegionUpdateDto region)
        {
            try
            {
                var result = await _mediator.Send(new UpdateRegion.Command() { Id = id, Region = region });
                return Ok(result);
            } 
            catch (ArgumentNullException)
            {
                return NotFound();
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<RegionDto>> DeleteRegion(int id)
        {
            try
            {
                var result = await _mediator.Send(new DeleteRegion.Command() { Id = id });
                return Ok($"Removed Region {result}");
            }
            catch (ArgumentNullException)
            {
                return NotFound();
            }

        }
    }
}
