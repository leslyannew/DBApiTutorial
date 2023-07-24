using AutoMapper;
using AutoMapper.QueryableExtensions;
using DBApiTutorial.Domain;
using DBApiTutorial.Features.Regions.DTO;
using DBApiTutorial.Features.Regions.Request;
using DBApiTutorial.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace DBApiTutorial.Features.Regions
{
    //Annotations commented out here so this does not interfere with the existing controller

    //[Route("api/[controller]")]
    //[ApiController]
    public class StarterRegionsController : ControllerBase
    {
        private readonly DBContext _context;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public StarterRegionsController(DBContext context, IMapper mapper, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _mediator = mediator;
        }

        //[HttpGet]
        public async Task<ActionResult<IEnumerable<RegionDto>>> GetRegions()
        {
            //Get all Regions from the database
            var regions = await _context.Regions
                .AsNoTracking() //GET happens often so we do not want EF Core to track these changes for performance reasons
                .ProjectTo<RegionDto>(_mapper.ConfigurationProvider) //Map entity to DTO
                .ToListAsync();

            //If no regions, return 404 Not Found
            if (regions.IsNullOrEmpty())
            {
                return NotFound();
            }
            //Return entities with a 200 Ok response
            return Ok(regions);
        }


        //Requested Id is sent by the client as a parameter
        //[HttpGet("{id}")]
        public async Task<ActionResult<RegionDto>> GetRegion(int id)
        {
            //Get requested Region by Id
            var region = await _context.Regions
                .Where(r => r.Id == id)
                .AsNoTracking()
                .ProjectTo<RegionDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
            if (region == null)
            {
                return NotFound();
            }
            return Ok(region);
        }


        //[HttpPost]
        public async Task<ActionResult<RegionDto>> CreateRegion(
            [FromBody] //This attribute indicates to the controller that this object will come from the Body of the request
            [Required(ErrorMessage = "Provide a Region to create.")] //You can also make parameters required and add custom errors with this attribute
            RegionCreateDto regionToCreate)
        {
            //Map the region received to the entity type
            var regionEntity = _mapper.Map<Region>(regionToCreate);

            //Add the new mapped region to the our table and update the database
            await _context.Regions.AddAsync(regionEntity);
            await _context.SaveChangesAsync();

            //Map the added region back to a Dto and return it at the specified route with a 201 Created response
            var result = _mapper.Map<RegionDto>(regionEntity);
            return Created($"regions/{result.Id}", result);
        }


        //[HttpPut("{id}")]
        public async Task<ActionResult<RegionDto>> UpdateRegion(int id,
            [FromBody][Required(ErrorMessage = "Provide an updated Region.")]
            RegionUpdateDto region)
        {
            var regionEntity = await _context.Regions
                .Where(r => r.Id == id)
                .FirstOrDefaultAsync();

            if (regionEntity == null)
            {
                return NotFound();
            }

            var updatedEntity = _mapper.Map(region, regionEntity);
            await _context.SaveChangesAsync();
            var updatedDto = _mapper.Map<RegionDto>(updatedEntity);
            return Ok(updatedDto);
        }


        //[HttpDelete("{id}")]
        public async Task<ActionResult<int>> DeleteRegion(int id)
        {
            var regionEntity = await _context.Regions
                   .Where(r => r.Id == id)
                   .IgnoreQueryFilters()
                   .FirstOrDefaultAsync();
            if (regionEntity == null)
            {
                return NotFound();
            }
            if (!regionEntity.IsDeleted)
            {
                regionEntity.IsDeleted = true;
            }
            else
            {
                regionEntity.IsDeleted = false;
            }
            await _context.SaveChangesAsync();
            return Ok($"Removed Region {id}");
        }
    }

}

