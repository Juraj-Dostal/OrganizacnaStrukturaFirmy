using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using REST_API___Organizačná_štruktúra_firmy.Models;

namespace REST_API___Organizačná_štruktúra_firmy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZamestnanecController : ControllerBase
    {

        private readonly OrgStructContext _context;

        public ZamestnanecController(OrgStructContext context)
        {
            _context = context;
        }

        //Get : api/Zamestnanec
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Zamestnanec>>> GetZamestnanci()
        {
            if (_context.Zamestnanci is null)
            {
                return NotFound();
            }
            
            return await _context.Zamestnanci.ToListAsync();
        }

        //Post : api/Zamestnanec/{id}
        [HttpPost]
        public async Task<ActionResult<Zamestnanec>> PostZamestnanec(Zamestnanec zamestnanec)
        {
            _context.Zamestnanci.Add(zamestnanec);
            await _context.SaveChangesAsync();
            
            return Ok(zamestnanec);
        }

        //Put : api/Zamestnanec/{id}
        [HttpPut]
        public async Task<ActionResult<Zamestnanec>> PutZamestnanec(int id, Zamestnanec zamestnanec)
        { 
            if (id != zamestnanec.Id)
            {
                return BadRequest();
            }

            _context.Entry(zamestnanec).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {

                if (ZamestnanecExists(id)) 
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            
            return Ok(zamestnanec);
        }

        //Delete : api/Zamestnanec/id
        [HttpDelete("{id}")]
        public async Task<ActionResult<Zamestnanec>> DeleteZamestnanec(int id)
        {
            if(_context.Zamestnanci is null)
            {
                return NotFound();
            }
            var zamestnanec = await _context.Zamestnanci.FindAsync(id);
            if (zamestnanec is null)
            {
                return NotFound();
            }
            _context.Zamestnanci.Remove(zamestnanec);
            await _context.SaveChangesAsync();
            
            return Ok(zamestnanec);

        }


        private bool ZamestnanecExists(int id) 
        {
            return (_context.Zamestnanci?.Any(movie => movie.Id == id)).GetValueOrDefault();
        }

    }
}
