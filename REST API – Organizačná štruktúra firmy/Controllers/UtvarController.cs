using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API___Organizačná_štruktúra_firmy.Models;

namespace REST_API___Organizačná_štruktúra_firmy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UtvarController : ControllerBase
    {
        private readonly OrgStructContext _context;

        public UtvarController(OrgStructContext context)
        {
            _context = context;
        }

        //Get : api/Utvar
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Utvar>>> GetUtvary()
        {
            if(_context.Utvary is null)
            {
                return NotFound();
            }
            return await _context.Utvary.ToListAsync();
        }

        //Post : api/Utvar
        [HttpPost]
        public async Task<ActionResult<Utvar>> PostUtvar(Utvar utvar)
        {
            _context.Utvary.Add(utvar);
            await _context.SaveChangesAsync();
            return Ok();
        }

        //Put : api/Utvar/{id}
        [HttpPut]
        public async Task<ActionResult<Utvar>> PutUtvar(int kod, Utvar utvar)
        {
            if(kod != utvar.Kod)
            {
                return BadRequest();
            }

            _context.Entry(utvar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!UtvarExists(kod))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        //Delete: api/Movies/id
        [HttpDelete("{kod}")]
        public async Task<ActionResult<Utvar>> DeleteUtvar(int kod)
        {
            if(_context.Utvary is null)
            { 
                return NotFound(); 
            }
            var utvar = await _context.Utvary.FindAsync(kod);
            if(utvar == null)
            {
                return NotFound();
            }
            _context.Utvary.Remove(utvar);
            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool UtvarExists(int kod)
        {
            return (_context.Utvary?.Any(utvar => utvar.Kod == kod)).GetValueOrDefault();
        }
    }
}
