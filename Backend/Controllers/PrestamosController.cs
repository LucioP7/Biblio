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
    public class PrestamosController : ControllerBase
    {
        private readonly BiblioContext _context;

        public PrestamosController(BiblioContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetPrestamos([FromQuery] string filtro = "")
        {
            var query = _context.Prestamos
                .Include(p => p.Usuario)
                .Include(p => p.Ejemplar)
                    .ThenInclude(e => e.Libro)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(p =>
                    (p.Usuario != null && p.Usuario.Nombre.Contains(filtro)) ||
                    (p.Usuario != null && p.Usuario.Dni.Contains(filtro)) ||
                    (p.Ejemplar != null && p.Ejemplar.Libro != null && p.Ejemplar.Libro.Titulo.Contains(filtro))
                );
            }

            return await query.AsNoTracking().ToListAsync();
        }

        // GET: api/Prestamos/deleteds
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Prestamo>>> GetDeletedsPrestamos()
        {
            return await _context.Prestamos
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Include(p => p.Usuario)
                .Include(p => p.Ejemplar)
                    .ThenInclude(e => e.Libro)
                .Where(p => p.IsDeleted)
                .ToListAsync();
        }

        // GET: api/Prestamos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Prestamo>> GetPrestamo(int id)
        {
            var prestamo = await _context.Prestamos
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.Ejemplar)
                    .ThenInclude(e => e.Libro)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            return prestamo;
        }

        // PUT: api/Prestamos/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrestamo(int id, Prestamo prestamo)
        {
            _context.TryAttach(prestamo?.Usuario);
            _context.TryAttach(prestamo?.Ejemplar);
            _context.TryAttach(prestamo?.Ejemplar?.Libro);
            if (id != prestamo.Id)
            {
                return BadRequest();
            }

            _context.Entry(prestamo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrestamoExists(id))
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

        // POST: api/Prestamos
        [HttpPost]
        public async Task<ActionResult<Prestamo>> PostPrestamo(Prestamo prestamo)
        {
            _context.TryAttach(prestamo?.Usuario);
            _context.TryAttach(prestamo?.Ejemplar);
            _context.TryAttach(prestamo?.Ejemplar?.Libro);
            _context.Prestamos.Add(prestamo);
            await _context.SaveChangesAsync();

            var creado = await _context.Prestamos
                .AsNoTracking()
                .Include(p => p.Usuario)
                .Include(p => p.Ejemplar)
                    .ThenInclude(e => e.Libro)
                .FirstOrDefaultAsync(p => p.Id == prestamo.Id);

            return CreatedAtAction(nameof(GetPrestamo), new { id = prestamo.Id }, creado);
        }

        // DELETE: api/Prestamos/5 (Soft Delete)
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrestamo(int id)
        {
            var prestamo = await _context.Prestamos.FindAsync(id);
            if (prestamo == null)
            {
                return NotFound();
            }

            prestamo.IsDeleted = true;
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // PUT: api/Prestamos/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePrestamo(int id)
        {
            var prestamo = await _context.Prestamos
                .IgnoreQueryFilters()
                .FirstOrDefaultAsync(p => p.Id == id);

            if (prestamo == null)
            {
                return NotFound();
            }

            prestamo.IsDeleted = false;
            _context.Prestamos.Update(prestamo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrestamoExists(int id)
        {
            return _context.Prestamos.Any(e => e.Id == id);
        }
    }
}
