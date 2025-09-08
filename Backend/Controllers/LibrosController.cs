using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DataContext;
using Service.Models;
using Service.ExtentionMethods;
using Microsoft.AspNetCore.Authorization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LibrosController : ControllerBase
    {
        private readonly BiblioContext _context;

        public LibrosController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/Libros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Libro>>> GetLibros([FromQuery] string filtro = "")
        {
            return await _context.Libros.AsNoTracking().Where(l => l.Titulo.Contains(filtro)).ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Libro>>> GetDeletedsLibros()
        {
            return await _context.Libros
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted).ToListAsync();
        }

        // GET: api/Libros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Libro>> GetLibro(int id)
        {
            var libro = await _context.Libros.AsNoTracking().FirstOrDefaultAsync(a => a.Id.Equals(id));

            if (libro == null)
            {
                return NotFound();
            }

            return libro;
        }

        // PUT: api/Libros/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibro(int id, Libro libro)
        {
            _context.TryAttach(libro?.Editorial);
            if (id != libro.Id)
            {
                return BadRequest();
            }

            _context.Entry(libro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroExists(id))
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

        // POST: api/Libros
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Libro>> PostLibro(Libro libro)
        {
            _context.TryAttach(libro?.Editorial);
            _context.Libros.Add(libro);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibro", new { id = libro.Id }, libro);
        }

        // DELETE: api/Libros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibro(int id)
        {
            var libro = await _context.Libros.FindAsync(id);
            if (libro == null)
            {
                return NotFound();
            }
            libro.IsDeleted = true;
            _context.Libros.Update(libro);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLibro(int id)
        {
            var libro = await _context.Libros.IgnoreQueryFilters().FirstOrDefaultAsync(l => l.Id.Equals(id));
            if (libro == null)
            {
                return NotFound();
            }
            libro.IsDeleted = false;
            //Impacta en memoria
            _context.Libros.Update(libro);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool LibroExists(int id)
        {
            return _context.Libros.Any(e => e.Id == id);
        }
    }
}
