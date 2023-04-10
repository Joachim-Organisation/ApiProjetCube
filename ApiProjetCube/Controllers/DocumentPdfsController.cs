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
    public class DocumentPdfsController : ControllerBase
    {
        private readonly TestContext _context;

        public DocumentPdfsController(TestContext context)
        {
            _context = context;
        }

        // GET: api/DocumentPdfs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentPdf>>> GetDocumentPdfs()
        {
          if (_context.DocumentPdfs == null)
          {
              return NotFound();
          }
            return await _context.DocumentPdfs.ToListAsync();
        }

        // GET: api/DocumentPdfs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentPdf>> GetDocumentPdf(int id)
        {
          if (_context.DocumentPdfs == null)
          {
              return NotFound();
          }
            var documentPdf = await _context.DocumentPdfs.FindAsync(id);

            if (documentPdf == null)
            {
                return NotFound();
            }

            return documentPdf;
        }

        // PUT: api/DocumentPdfs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocumentPdf(int id, DocumentPdf documentPdf)
        {
            if (id != documentPdf.Id)
            {
                return BadRequest();
            }

            _context.Entry(documentPdf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DocumentPdfExists(id))
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

        // POST: api/DocumentPdfs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DocumentPdf>> PostDocumentPdf(DocumentPdf documentPdf)
        {
          if (_context.DocumentPdfs == null)
          {
              return Problem("Entity set 'TestContext.DocumentPdfs'  is null.");
          }
            _context.DocumentPdfs.Add(documentPdf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDocumentPdf", new { id = documentPdf.Id }, documentPdf);
        }

        // DELETE: api/DocumentPdfs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocumentPdf(int id)
        {
            if (_context.DocumentPdfs == null)
            {
                return NotFound();
            }
            var documentPdf = await _context.DocumentPdfs.FindAsync(id);
            if (documentPdf == null)
            {
                return NotFound();
            }

            _context.DocumentPdfs.Remove(documentPdf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DocumentPdfExists(int id)
        {
            return (_context.DocumentPdfs?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
