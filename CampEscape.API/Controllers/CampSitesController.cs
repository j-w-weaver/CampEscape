using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CampEscape.API.Data;
using CampEscape.API.Data.Entities;

namespace CampEscape.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampSitesController : ControllerBase
    {
        private readonly CampEscapeDbContext _context;

        public CampSitesController(CampEscapeDbContext context)
        {
            _context = context;
        }

        // GET: api/CampSites
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CampSite>>> GetCampSites()
        {
            return await _context.CampSites.ToListAsync();
        }

        // GET: api/CampSites/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CampSite>> GetCampSite(int id)
        {
            var campSite = await _context.CampSites.FindAsync(id);

            if (campSite == null)
            {
                return NotFound();
            }

            return campSite;
        }

        // PUT: api/CampSites/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCampSite(int id, CampSite campSite)
        {
            if (id != campSite.Id)
            {
                return BadRequest();
            }

            _context.Entry(campSite).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampSiteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CampSites
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CampSite>> PostCampSite(CampSite campSite)
        {
            _context.CampSites.Add(campSite);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCampSite", new { id = campSite.Id }, campSite);
        }

        // DELETE: api/CampSites/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCampSite(int id)
        {
            var campSite = await _context.CampSites.FindAsync(id);
            if (campSite == null)
            {
                return NotFound();
            }

            _context.CampSites.Remove(campSite);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CampSiteExists(int id)
        {
            return _context.CampSites.Any(e => e.Id == id);
        }
    }
}
