using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Addition.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Addition
{
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeRepository _officeRepository;
        private readonly IMapper _mapper;

        public OfficesController(IOfficeRepository officeRepository, IMapper mapper)
        {
            _officeRepository = officeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeDto>>> GetOffices()
        {
            var offices = await _officeRepository.GetOfficesAsync();
            return Ok(_mapper.Map<IEnumerable<OfficeDto>>(offices));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOffice(int id)
        {
            var office = await _officeRepository.GetOfficeByIdAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<OfficeDto>(office));
        } 
    } 
}
