using AutoMapper;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Features.Regions.Request;
using DBApiTutorial.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Regions
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper, IMediator mediator)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            var result = await _mediator.Send(new GetRegions.Query());
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetRegion(int id)
        {
            var result = await _mediator.Send(new GetRegionById.Query() { Id = id });
            
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<RegionDto>> CreateRegion([FromBody] RegionCreateDto regionToCreate)
        {
            var regionToReturn = await _mediator.Send(new CreateRegion.Command() { Region = regionToCreate });
            return Created($"regions/{regionToReturn.Id}", regionToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRegion(int id, [FromBody] RegionUpdateDto regionToUpdate)
        {
            var result = await _mediator.Send(new UpdateRegion.Command() { Id = id, Region = regionToUpdate });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegion(int id)
        {
            var result = await _mediator.Send(new DeleteRegion.Command() { Id = id });
            if (result == -1)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
