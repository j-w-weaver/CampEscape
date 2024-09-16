using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampEscape.API.Data;
using CampEscape.API.Data.Entities;
using CampEscape.API.DTOs;
using AutoMapper;

namespace CampEscape.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly CampEscapeDbContext _context;
        private readonly IMapper _mapper;

        public RegionsController(CampEscapeDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/Regions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRegionDTO>>> GetRegions()
        {
            var regions = await _context.Regions.ToListAsync();

            if (regions == null)
            {
                return NotFound();
            }

            var records = _mapper.Map<List<GetRegionDTO>>(regions);

            return Ok(records);
        }

        // GET: api/Regions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Region>> GetRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);

            if (region == null)
            {
                return NotFound();
            }

            return Ok(region);
        }

        // PUT: api/Regions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRegion(int id, Region region)
        {
            if (id != region.Id)
            {
                return BadRequest("Invalid RegionId. Region Not Found.");
            }

            _context.Entry(region).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RegionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Region Updated Successfully.");
        }

        // POST: api/Regions 
        [HttpPost]
        public async Task<ActionResult<Region>> CreateRegion(CreateRegionDTO createRegionDTO)
        {
            var region = _mapper.Map<Region>(createRegionDTO);

            _context.Regions.Add(region);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRegion", new { id = region.Id }, region);
        }

        // DELETE: api/Regions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRegion(int id)
        {
            var region = await _context.Regions.FindAsync(id);
            if (region == null)
            {
                return NotFound();
            }

            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RegionExists(int id)
        {
            return _context.Regions.Any(e => e.Id == id);
        }
    }
}
