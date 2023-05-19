using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProjetCube.Entities;
using ApiProjetCube.Models;
using FluentAssertions;

namespace ApiProjetCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageForumsController : ControllerBase
    {
        private readonly TestContext _context;

        public MessageForumsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/MessageForums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MessageForum>>> GetMessagesForums()
        {
            if (_context.MessagesForums == null)
            {
                return NotFound();
            }
            return await _context.MessagesForums.ToListAsync();
        }

        // GET: api/MessageForums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MessageForum>> GetMessageForum(int id)
        {
            if (_context.MessagesForums == null)
            {
                return NotFound();
            }
            var messageForum = await _context.MessagesForums.FindAsync(id);

            if (messageForum == null)
            {
                return NotFound();
            }

            return messageForum;
        }

        // GET: api//api/MessageForums?idSubjectForum={idSubjectForum}
        [HttpGet("bySubjectForum")]
        public async Task<ActionResult<List<MessageForum>>> GetMessageForum(int idSubjectForum, string varInnutile)
        {
            if (_context.MessagesForums == null)
            {
                return NotFound();
            }
            var messageForums = await _context.MessagesForums.Include(mf => mf.Utilisateur).Where(u => u.IdSubjectForum == idSubjectForum).ToListAsync();

            if (messageForums == null)
            {
                return NotFound();
            }

            return messageForums;
        }

        // PUT: api/MessageForums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMessageForum(int id, MessageForum messageForum)
        {
            if (id != messageForum.Id)
            {
                return BadRequest();
            }

            _context.Entry(messageForum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MessageForumExists(id))
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

        // POST: api/MessageForums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MessageForum>> PostMessageForum(MessageForum messageForum)
        {
            if (_context.MessagesForums == null)
            {
                return Problem("Entity set 'TestContext.MessagesForums' is null.");
            }

            messageForum.DateCreation = DateTime.Now; // Initialise la date de création avec la date et l'heure actuelles

            _context.MessagesForums.Add(messageForum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMessageForum", new { id = messageForum.Id }, messageForum);
        }

        // DELETE: api/MessageForums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMessageForum(int id)
        {
            if (_context.MessagesForums == null)
            {
                return NotFound();
            }
            var messageForum = await _context.MessagesForums.FindAsync(id);
            if (messageForum == null)
            {
                return NotFound();
            }

            _context.MessagesForums.Remove(messageForum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MessageForumExists(int id)
        {
            return (_context.MessagesForums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
