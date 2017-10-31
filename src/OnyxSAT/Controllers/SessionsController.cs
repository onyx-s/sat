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
    [Route("api/Sessions")]
    public class SessionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SessionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Sessions
        [HttpGet]
        public IEnumerable<Session> GetSessions()
        {
            return _context.Sessions;
        }

        // GET: api/Sessions/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSession([FromRoute] DateTime id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = await _context.Sessions.SingleOrDefaultAsync(m => m.DateTime == id);

            if (session == null)
            {
                return NotFound();
            }

            return Ok(session);
        }

        // PUT: api/Sessions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSession([FromRoute] DateTime id, [FromBody] Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != session.DateTime)
            {
                return BadRequest();
            }

            _context.Entry(session).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SessionExists(id))
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

        // POST: api/Sessions
        [HttpPost]
        public async Task<IActionResult> PostSession([FromBody] Session session)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Sessions.Add(session);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SessionExists(session.DateTime))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetSession", new { id = session.DateTime }, session);
        }

        // DELETE: api/Sessions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSession([FromRoute] DateTime id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var session = await _context.Sessions.SingleOrDefaultAsync(m => m.DateTime == id);
            if (session == null)
            {
                return NotFound();
            }

            _context.Sessions.Remove(session);
            await _context.SaveChangesAsync();

            return Ok(session);
        }

        private bool SessionExists(DateTime id)
        {
            return _context.Sessions.Any(e => e.DateTime == id);
        }
    }
}