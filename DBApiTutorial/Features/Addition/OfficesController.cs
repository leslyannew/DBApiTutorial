using AutoMapper;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Addition.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DBApiTutorial.Features.Addition
{
    //[Route("api/Regions/{regionId}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class OfficesController : ControllerBase
    {
        private readonly IOfficeRepository officeRepository;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public OfficesController(IOfficeRepository officeRepository, IRegionRepository regionRepository, IMapper mapper)
        {
            this.officeRepository = officeRepository;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfficeDto>>> GetOffices()
        {
            var offices = await officeRepository.GetOfficesAsync();
            return Ok(mapper.Map<IEnumerable<OfficeDto>>(offices));

        }

        [HttpGet("{officeid}", Name = "GetOffice")]
        public async Task<IActionResult> GetOffice(int id)
        {
            var office = await officeRepository.GetOfficeByIdAsync(id);

            if (office == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<OfficeDto>(office));
        }

        [HttpPost]
        public async Task<ActionResult<OfficeDto>> CreateOffice(int regionId, [FromBody] OfficeCreateDto officeToCreate)
        {
            if (!await regionRepository.RegionExistsAsync(regionId))
            {
                return NotFound("Cannot create Office for a Region that does not exist.");
            }

            var officeEntity = mapper.Map<Domain.Entity.Office>(officeToCreate);
            await officeRepository.AddOfficeAsync(officeEntity);
            await officeRepository.SaveChangesAsync();
            var officeToReturn = mapper.Map<OfficeDto>(officeEntity);
            return CreatedAtRoute("GetOffice",
                new
                {
                    regionId = regionId,
                    officeId = officeToReturn.Id
                },
                officeToReturn);
        }
    }
}
