using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiProjetCube.Entities;
using ApiProjetCube.Models;

namespace ApiProjetCube.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectForumsController : ControllerBase
    {
        private readonly TestContext _context;

        public SubjectForumsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/SubjectForums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubjectForum>>> GetSubjectsForums()
        {
          if (_context.SubjectsForums == null)
          {
              return NotFound();
          }
            return await _context.SubjectsForums.ToListAsync();
        }

        // GET: api/SubjectForums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectForum>> GetSubjectForum(int id)
        {
          if (_context.SubjectsForums == null)
          {
              return NotFound();
          }
            var subjectForum = await _context.SubjectsForums.FindAsync(id);

            if (subjectForum == null)
            {
                return NotFound();
            }

            return subjectForum;
        }

        [HttpGet("ByCategorieId/{id}")]
        public async Task<ActionResult<IEnumerable<SubjectForum>>> GetSubjectForumByCategorieId(int id)
        {
            if (_context.SubjectsForums == null)
            {
                return NotFound();
            }
            var subjectForums = await _context.SubjectsForums.Where(s => s.IdCategorie == id).ToListAsync();

            if (subjectForums == null || subjectForums.Count == 0)
            {
                return NotFound();
            }

            return subjectForums;
        }

        // GET: api/SubjectForums/ByUserId/5
        [HttpGet("ByUserId/{id}")]
        public async Task<ActionResult<IEnumerable<SubjectForum>>> GetSubjectForumsByUserId(int id)
        {
            var subjectForums = await _context.SubjectsForums.Where(s => s.IdUtilisateur == id).ToListAsync();
            if (subjectForums == null || subjectForums.Count == 0)
            {
                return NotFound();
            }

            return subjectForums;
        }


        // PUT: api/SubjectForums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubjectForum(int id, SubjectForum subjectForum)
        {
            if (id != subjectForum.Id)
            {
                return BadRequest();
            }

            _context.Entry(subjectForum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectForumExists(id))
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

        // POST: api/SubjectForums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SubjectForum>> PostSubjectForum(SubjectForum subjectForum)
        {
          if (_context.SubjectsForums == null)
          {
              return Problem("Entity set 'TestContext.SubjectsForums'  is null.");
          }
            _context.SubjectsForums.Add(subjectForum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubjectForum", new { id = subjectForum.Id }, subjectForum);
        }

        // DELETE: api/SubjectForums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubjectForum(int id)
        {
            if (_context.SubjectsForums == null)
            {
                return NotFound();
            }
            var subjectForum = await _context.SubjectsForums.FindAsync(id);
            if (subjectForum == null)
            {
                return NotFound();
            }

            _context.SubjectsForums.Remove(subjectForum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SubjectForumExists(int id)
        {
            return (_context.SubjectsForums?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
