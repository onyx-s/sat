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
    [Route("api/Cards")]
    public class CardsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CardsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Cards
        [HttpGet]
        public IEnumerable<Card> GetCards()
        {
            return _context.Cards;
        }

        // GET: api/Cards/unlinked
        [HttpGet("unlinked")]
        public IEnumerable<Card> GetUnlinkedCards()
        {
            return _context.Cards.Where(c => c.UserId == null);

        }
        
        // GET: api/Cards/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await _context.Cards.SingleOrDefaultAsync(m => m.CardNo == id);

            if (card == null)
            {
                return NotFound();
            }

            return Ok(card);
        }

        // PUT: api/Cards/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCard([FromRoute] string id, [FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != card.CardNo)
            {
                return BadRequest();
            }

            _context.Entry(card).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [HttpPost]
        public async Task<IActionResult> PostCard([FromBody] Card card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Cards.Add(card);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCard", new { id = card.CardNo }, card);
        }

        // DELETE: api/Cards/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var card = await _context.Cards.SingleOrDefaultAsync(m => m.CardNo == id);
            if (card == null)
            {
                return NotFound();
            }

            _context.Cards.Remove(card);
            await _context.SaveChangesAsync();

            return Ok(card);
        }

        private bool CardExists(string id)
        {
            return _context.Cards.Any(e => e.CardNo == id);
        }
    }
}