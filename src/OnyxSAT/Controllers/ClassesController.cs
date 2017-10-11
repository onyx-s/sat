using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnyxSAT.Data;
using OnyxSAT.Models;

namespace OnyxSAT.Controllers
{
    [Produces("application/json")]
    [Route("api/Classes")]
    public class ClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Classes
        [HttpGet]
        public IEnumerable<Class> GetClasses()
        {
            return _context.Classes;
        }

        // GET: api/Classes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @class = await _context.Classes.SingleOrDefaultAsync(m => m.ClassId == id);

            if (@class == null)
            {
                return NotFound();
            }

            return Ok(@class);
        }

        // PUT: api/Classes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClass([FromRoute] int id, [FromBody] Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @class.ClassId)
            {
                return BadRequest();
            }

            _context.Entry(@class).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClassExists(id))
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

        // POST: api/Classes
        [HttpPost]
        public async Task<IActionResult> PostClass([FromBody] Class @class)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Classes.Add(@class);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClass", new { id = @class.ClassId }, @class);
        }

        // DELETE: api/Classes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClass([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @class = await _context.Classes.SingleOrDefaultAsync(m => m.ClassId == id);
            if (@class == null)
            {
                return NotFound();
            }

            _context.Classes.Remove(@class);
            await _context.SaveChangesAsync();

            return Ok(@class);
        }

        private bool ClassExists(int id)
        {
            return _context.Classes.Any(e => e.ClassId == id);
        }
    }
}