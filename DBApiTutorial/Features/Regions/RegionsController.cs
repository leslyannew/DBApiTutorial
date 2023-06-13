using AutoMapper;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Services;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Regions
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // GET api/regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            var regions = await _regionRepository.GetRegionsAsync();
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regions));

        }

        // GET api/regions/1
        [HttpGet("{id}", Name = "GetRegion")]
        public async Task<ActionResult> GetRegion(int id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(region));
        }

        [HttpPost]
        public async Task<ActionResult<RegionDto>> CreateRegion([FromBody] RegionCreateDto regionToCreate)
        {
            var regionEntity = _mapper.Map<Domain.Entity.Region>(regionToCreate);
            await _regionRepository.AddRegionAsync(regionEntity);
            await _regionRepository.SaveChangesAsync();
            var regionToReturn = _mapper.Map<RegionDto>(regionEntity);
            return CreatedAtRoute("GetRegion",
                new
                {
                    id = regionToReturn.Id
                },
                regionToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateRegion(int id, [FromBody] RegionUpdateDto regionToUpdate)
        {
            var regionEntity = await _regionRepository.GetRegionByIdAsync(id);
            if (regionEntity == null)
            {
                return NotFound();
            }
            
            _mapper.Map(regionToUpdate, regionEntity);
            await _regionRepository.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRegion(int id)
        {
            var regionEntity = await _regionRepository.GetRegionByIdAsync(id);
            if (regionEntity == null)
            {
                return NotFound();
            }

            _regionRepository.DeleteRegion(regionEntity);
            await _regionRepository.SaveChangesAsync();
            return NoContent();
        }
    }
}
