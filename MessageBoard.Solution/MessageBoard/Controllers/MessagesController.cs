using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MessageBoard.Models;
using System.Linq;

namespace MessageBoard.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MessagesController : ControllerBase
  {
    private readonly MessageBoardContext _db;

    public MessagesController(MessageBoardContext db)
    {
      _db = db;
    }

    // GET 
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> Get(string userName, int age, string date, string messageDescription)
    {
      var query = _db.Messages.AsQueryable();
      if (userName != null)
      {
        query = query.Where(entry => entry.UserName == userName);
      }

      if (age > 0)
      {
        query = query.Where(entry => entry.Age == age);
      }

      if (date != null)
      {
        query = query.Where(entry => entry.Date == date);
      }

      if (messageDescription != null)
      {
        query = query.Where(entry => entry.MessageDescription == messageDescription);
      }

      return await query.ToListAsync();
    }

    // POST api/
    [HttpPost]
    public async Task<ActionResult<Message>> Post(Message message)
    {
      _db.Messages.Add(message);
      await _db.SaveChangesAsync();

      return CreatedAtAction(nameof(GetMessage), new { id = message.MessageId }, message);
    }

    //Get: api/Messages/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Message>> GetMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);

      if (message == null)
      {
        return NotFound();
      }

      return message;
    }

    [HttpPut("{id}")]

    public async Task<IActionResult> Put(int id, Message message)
    {
      if (id != message.MessageId)
      {
        return BadRequest();
      }

      _db.Entry(message).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!MessageExists(id))
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

    // DELETE: api/Messages/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMessage(int id)
    {
      var message = await _db.Messages.FindAsync(id);
      if (message == null)
      {
        return NotFound();
      }

      _db.Messages.Remove(message);
      await _db.SaveChangesAsync();

      return NoContent();
    }

    private bool MessageExists(int id)
    {
      return _db.Messages.Any(e => e.MessageId == id);
    }
  }
}