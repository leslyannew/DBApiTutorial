using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Addition.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Addition
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegion(int id)
        {
            var region = await _regionRepository.GetRegionByIdAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(region));
        }

        //// POST api/regions
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/regions/1
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/regions/1
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
