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
    public class DocumentImagesController : ControllerBase
    {
        private readonly TestContext _context;

        public DocumentImagesController(TestContext context)
        {
            _context = context;
        }

        // GET: api/DocumentImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentImage>>> GetDocumentImages()
        {
          if (_context.DocumentImages == null)
          {
              return NotFound();
          }
            return await _context.DocumentImages.ToListAsync();
        }

        // GET: api/DocumentImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentImage>> GetDocumentImage(int id)
        {
          if (_context.DocumentImages == null)
          {
              return NotFound();
          }
            var documentImage = await _context.DocumentImages.FindAsync(id);

            if (documentImage == null)
            {
                return NotFound();
            }

            return documentImage;
        }

        // PUT: api/DocumentImages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentImage(int id, DocumentImage documentImage)
        {
            if (id != documentImage.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentImageExists(id))
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

        // POST: api/DocumentImages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentImage>> PostDocumentImage(DocumentImage documentImage)
        {
          if (_context.DocumentImages == null)
          {
              return Problem("Entity set 'TestContext.DocumentImages'  is null.");
          }
            _context.DocumentImages.Add(documentImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentImage", new { id = documentImage.Id }, documentImage);
        }

        // DELETE: api/DocumentImages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentImage(int id)
        {
            if (_context.DocumentImages == null)
            {
                return NotFound();
            }
            var documentImage = await _context.DocumentImages.FindAsync(id);
            if (documentImage == null)
            {
                return NotFound();
            }

            _context.DocumentImages.Remove(documentImage);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentImageExists(int id)
        {
            return (_context.DocumentImages?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
