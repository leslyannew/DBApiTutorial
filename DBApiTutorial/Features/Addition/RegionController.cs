using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Addition.DTO;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DBApiTutorial.Features.Addition
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionRepository _regionRepository;
        private readonly IMapper _mapper;

        public RegionController(IRegionRepository regionRepository, IMapper mapper)
        {
            _regionRepository = regionRepository;
            _mapper = mapper;
        }

        // GET: api/<RegionController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            var regions = await _regionRepository.ListAllAsync();
            return Ok(_mapper.Map<IEnumerable<RegionDto>>(regions));
            
        }

        // GET api/<RegionController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRegion(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);

            if(region == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<RegionDto>(region));
        }

        //// POST api/<RegionController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<RegionController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<RegionController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
