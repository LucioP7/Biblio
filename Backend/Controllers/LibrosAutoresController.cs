using Backend.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using Service.ExtentionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosAutoresController : ControllerBase
    {
        private readonly BiblioContext _context;

        public LibrosAutoresController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/LibrosAutores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroAutor>>> GetLibroAutores([FromQuery] string filtro = "")
        {
            var query = _context.LibroAutores
                .Include(la => la.Libro) 
                    .ThenInclude(la=>la.Editorial)
                .Include(la => la.Autor)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(lg =>
                    (lg.Libro != null && lg.Libro.Titulo.Contains(filtro)) ||
                    (lg.Autor != null && lg.Autor.Nombre.Contains(filtro))
                );
            }

            return await query.AsNoTracking().ToListAsync();
        }

        // GET: api/LibrosAutores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroAutor>> GetLibroAutor(int id)
        {
            var libroAutor = await _context.LibroAutores
                .Include(la => la.Libro)   // Incluye datos del libro
                    .ThenInclude(la=>la.Editorial)
                .Include(la => la.Autor)   // Incluye datos del autor
                .FirstOrDefaultAsync(la => la.Id == id);

            if (libroAutor == null)
            {
                return NotFound();
            }

            return libroAutor;
        }

        // PUT: api/LibrosAutores/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroAutor(int id, LibroAutor libroAutor)
        {
            _context.TryAttach(libroAutor?.Libro);
            _context.TryAttach(libroAutor?.Libro?.Editorial);
            _context.TryAttach(libroAutor?.Autor);

            if (id != libroAutor.Id)
            {
                return BadRequest();
            }

            _context.Entry(libroAutor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroAutorExists(id))
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

        // POST: api/LibrosAutores
        [HttpPost]
        public async Task<ActionResult<LibroAutor>> PostLibroAutor(LibroAutor libroAutor)
        {
            _context.TryAttach(libroAutor?.Libro);
            _context.TryAttach(libroAutor?.Libro?.Editorial);
            _context.TryAttach(libroAutor?.Autor);
            _context.LibroAutores.Add(libroAutor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLibroAutor", new { id = libroAutor.Id }, libroAutor);
        }

        // DELETE: api/LibrosAutores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroAutor(int id)
        {
            var libroAutor = await _context.LibroAutores.FindAsync(id);
            if (libroAutor == null)
            {
                return NotFound();
            }

            libroAutor.IsDeleted = true; // Eliminación lógica
            _context.LibroAutores.Update(libroAutor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Ejemplares/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLibroAutor(int id)
        {
            var libroautor = await _context.LibroAutores
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (libroautor == null)
            {
                return NotFound();
            }

            libroautor.IsDeleted = false;
            _context.LibroAutores.Update(libroautor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroAutorExists(int id)
        {
            return _context.LibroAutores.Any(e => e.Id == id);
        }
    }
}
