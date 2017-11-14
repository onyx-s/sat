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
  [Route("api/Attendances")]
  public class AttendancesController : Controller
  {
    private readonly ApplicationDbContext _context;

    public AttendancesController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/Attendances
    [HttpGet]
    public IEnumerable<Attendance> GetAttendances()
    {
      return _context.Attendances;
    }

    // GET: api/Attendances/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAttendance([FromRoute] DateTime id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var attendance = await _context.Attendances.SingleOrDefaultAsync(m => m.DateTime == id);

      if (attendance == null)
      {
        return NotFound();
      }

      return Ok(attendance);
    }

    // PUT: api/Attendances/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAttendance([FromRoute] DateTime id, [FromBody] Attendance attendance)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != attendance.DateTime)
      {
        return BadRequest();
      }

      _context.Entry(attendance).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!AttendanceExists(id))
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

    // POST: api/Attendances
    [HttpPost]
    public async Task<IActionResult> PostAttendance([FromBody] Attendance attendance)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      attendance.DateTime = System.DateTime.Now;

      Card card = await _context.Cards.SingleOrDefaultAsync(m => m.CardNo == attendance.CardNo);

      if (card == null)
      {
        card = new Card { CardNo = attendance.CardNo };

        _context.Cards.Add(card);
        await _context.SaveChangesAsync();
      }

      _context.Attendances.Add(attendance);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        if (AttendanceExists(attendance.DateTime))
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("GetAttendance", new { id = attendance.DateTime }, attendance);
    }

    // DELETE: api/Attendances/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAttendance([FromRoute] DateTime id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var attendance = await _context.Attendances.SingleOrDefaultAsync(m => m.DateTime == id);
      if (attendance == null)
      {
        return NotFound();
      }

      _context.Attendances.Remove(attendance);
      await _context.SaveChangesAsync();

      return Ok(attendance);
    }


    private bool AttendanceExists(DateTime id)
    {
      return _context.Attendances.Any(e => e.DateTime == id);
    }
  }
}