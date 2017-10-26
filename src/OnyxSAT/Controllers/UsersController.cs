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
  [Route("api/Users")]
  public class UsersController : Controller
  {
    private readonly ApplicationDbContext _context;

    public UsersController(ApplicationDbContext context)
    {
      _context = context;
    }

    // GET: api/Users
    [HttpGet]
    public IEnumerable<User> GetUsers()
    {
      return _context.Users;
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = await _context.Users
          .Include(u => u.UserRoles)
              .ThenInclude(uR => uR.Role)
          .Include(u => u.Classes)
          .Include(u => u.Cards)
          .AsNoTracking()
          .SingleOrDefaultAsync(m => m.UserId == id);

      if (user == null)
      {
        return NotFound();
      }

      return Ok(user);
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser([FromRoute] int id, [FromBody] User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      if (id != user.UserId)
      {
        return BadRequest();
      }

      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
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

    // POST: api/Users
    [HttpPost]
    public async Task<IActionResult> PostUser([FromBody] User user)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = user.UserId }, user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute] int id)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var user = await _context.Users.SingleOrDefaultAsync(m => m.UserId == id);
      if (user == null)
      {
        return NotFound();
      }

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();

      return Ok(user);
    }

    // POST: api/users/1/roles    
    [HttpPost("{id}/roles")]
    public async Task<IActionResult> PostRole([FromRoute] int id, [FromBody] UserRole userRole)
    {
      userRole.UserId = id;

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      _context.UserRoles.Add(userRole);
      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateException)
      {
        var userHasRole = _context.UserRoles.Any(uR => uR.UserId == userRole.UserId && uR.RoleId == userRole.RoleId);
        
        if (userHasRole)
        {
          return new StatusCodeResult(StatusCodes.Status409Conflict);
        }
        else
        {
          throw;
        }
      }

      return CreatedAtAction("PostRole", new { userId = userRole.UserId, roleId = userRole.RoleId }, userRole);
    }

    // DELETE: api/users/5/roles/2
    [HttpDelete("{id}/roles/{roleId}")]
    public async Task<IActionResult> DeleteUserRole([FromRoute] int id, [FromRoute] int roleId)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var userRole = await _context.UserRoles.SingleOrDefaultAsync(m => m.UserId == id && m.RoleId == roleId);
      if (userRole == null)
      {
        return NotFound();
      }

      _context.UserRoles.Remove(userRole);
      await _context.SaveChangesAsync();

      return Ok(userRole);
    }

    private bool UserExists(int id)
    {
      return _context.Users.Any(e => e.UserId == id);
    }
  }
}