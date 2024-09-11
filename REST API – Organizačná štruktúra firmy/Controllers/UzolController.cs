using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API___Organizačná_štruktúra_firmy.Models;

namespace REST_API___Organizačná_štruktúra_firmy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UzolController : ControllerBase
    {
        private readonly OrgStructContext _context;

        public UzolController(OrgStructContext context)
        {
            _context = context;
        }

        //Get : api/Uzol
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uzol>>> GetUzly()
        {
            if(_context.Uzly is null)
            {
                return NotFound();
            }

            return await _context.Uzly.ToListAsync();
        }

        //Post : api/Uzol
        [HttpPost]
        public async Task<ActionResult<Uzol>> PostUzol(Uzol uzol)
        {
            _context.Uzly.Add(uzol);
            await _context.SaveChangesAsync();

            return Ok(uzol);
        }

        //Put : api/Uzol/{id}
        [HttpPut]
        public async Task<ActionResult<Uzol>> PutUzol(int kod, Uzol uzol)
        {
            if(kod != uzol.Kod)
            {
                return BadRequest();
            }

            _context.Entry(uzol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if(!UzolExists(kod))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(uzol);
        }

        //Delete: api/Uzol/id
        [HttpDelete("{kod}")]
        public async Task<ActionResult<Uzol>> DeleteUzol(int kod)
        {
            if(_context.Uzly is null)
            { 
                return NotFound(); 
            }

            var uzol = await _context.Uzly.FindAsync(kod);

            if(uzol == null)
            {
                return NotFound();
            }

            _context.Uzly.Remove(uzol);
            await _context.SaveChangesAsync();

            return Ok(uzol);
        }

        private bool UzolExists(int kod)
        {
            return (_context.Uzly?.Any(uzol => uzol.Kod == kod)).GetValueOrDefault();
        }
    }
}
