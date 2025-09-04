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

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosGenerosController : ControllerBase
    {
        private readonly BiblioContext _context;

        public LibrosGenerosController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/LibrosGeneros
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LibroGenero>>> GetLibroGeneros([FromQuery] string filtro = "")
        {
            var query = _context.LibroGeneros
                .AsNoTracking()
                .Include(lg => lg.Libro)
                    .ThenInclude(lg=>lg.Editorial)
                .Include(lg => lg.Genero)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(lg =>
                    (lg.Libro != null && lg.Libro.Titulo.Contains(filtro)) ||
                    (lg.Genero != null && lg.Genero.Nombre.Contains(filtro))
                );
            }

            return await query.AsNoTracking().ToListAsync();
        }

        // GET: api/LibrosGeneros/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LibroGenero>> GetLibroGenero(int id)
        {
            var libroGenero = await _context.LibroGeneros
                .AsNoTracking()
                .Include(lg => lg.Libro)
                    .ThenInclude(lg=>lg.Editorial)
                .Include(lg => lg.Genero)
                .FirstOrDefaultAsync(lg => lg.Id == id);

            if (libroGenero == null)
            {
                return NotFound();
            }

            return libroGenero;
        }

        // PUT: api/LibrosGeneros/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLibroGenero(int id, LibroGenero libroGenero)
        {
            _context.TryAttach(libroGenero?.Libro);
            _context.TryAttach(libroGenero?.Libro?.Editorial);
            _context.TryAttach(libroGenero?.Genero);

            if (id != libroGenero.Id)
            {
                return BadRequest();
            }

            _context.Entry(libroGenero).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LibroGeneroExists(id))
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

        // POST: api/LibrosGeneros
        [HttpPost]
        public async Task<ActionResult<LibroGenero>> PostLibroGenero(LibroGenero libroGenero)
        {
            _context.TryAttach(libroGenero?.Libro);
            _context.TryAttach(libroGenero?.Libro?.Editorial);
            _context.TryAttach(libroGenero?.Genero);
            _context.LibroGeneros.Add(libroGenero);
            await _context.SaveChangesAsync();

            // Devolver con includes para que el cliente reciba los datos completos
            var creado = await _context.LibroGeneros
                .AsNoTracking()
                .Include(lg => lg.Libro)
                    .ThenInclude(lg=>lg.Editorial)
                .Include(lg => lg.Genero)
                .FirstOrDefaultAsync(lg => lg.Id == libroGenero.Id);

            return CreatedAtAction(nameof(GetLibroGenero), new { id = libroGenero.Id }, creado);
        }

        // DELETE: api/LibrosGeneros/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLibroGenero(int id)
        {
            var libroGenero = await _context.LibroGeneros.FindAsync(id);
            if (libroGenero == null)
            {
                return NotFound();
            }

            libroGenero.IsDeleted = true;
            _context.LibroGeneros.Update(libroGenero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Ejemplares/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreLibroGenero(int id)
        {
            var librogenero = await _context.LibroGeneros
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(e => e.Id == id);

            if (librogenero == null)
            {
                return NotFound();
            }

            librogenero.IsDeleted = false;
            _context.LibroGeneros.Update(librogenero);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LibroGeneroExists(int id)
        {
            return _context.LibroGeneros.Any(e => e.Id == id);
        }
    }
}
