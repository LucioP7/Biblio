using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.ExtensionMethods;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EjemplaresController : ControllerBase
    {
        private readonly BiblioContext _context;

        public EjemplaresController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/Ejemplares
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ejemplar>>> GetEjemplares([FromQuery] string filtro = "")
        {
            return await _context.Ejemplares
                .AsNoTracking()
                .Where(ej => ej.Libro != null && ej.Libro.Titulo.Contains(filtro)) //Nulos
                .ToListAsync();
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Ejemplar>>> GetDeletedsEjemplares()
        {
            return await _context.Ejemplares
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted).ToListAsync();
        }

        // GET: api/Ejemplares/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ejemplar>> GetEjemplar(int id)
        {
            var ejemplar = await _context.Ejemplares.AsNoTracking().FirstOrDefaultAsync(ej => ej.Id.Equals(id));

            if (ejemplar == null)
            {
                return NotFound();
            }

            return ejemplar;
        }

        // PUT: api/Ejemplares/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEjemplar(int id, Ejemplar ejemplar)
        {
            _context.TryAttach(ejemplar?.Libro);
            if (id != ejemplar.Id)
            {
                return BadRequest();
            }

            _context.Entry(ejemplar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EjemplarExists(id))
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

        // POST: api/Ejemplares
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ejemplar>> PostEjemplar(Ejemplar ejemplar)
        {
            _context.TryAttach(ejemplar?.Libro);
            _context.Ejemplares.Add(ejemplar);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEjemplar", new { id = ejemplar.Id }, ejemplar);
        }

        // DELETE: api/Ejemplares/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEjemplar(int id)
        {
            var ejemplar = await _context.Ejemplares.FindAsync(id);
            if (ejemplar == null)
            {
                return NotFound();
            }
            ejemplar.IsDeleted = true;
            //Impacta en memoria
            _context.Ejemplares.Update(ejemplar);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreEjemplar(int id)
        {
            var ejemplar = await _context.Ejemplares.IgnoreQueryFilters().FirstOrDefaultAsync(ej => ej.Id.Equals(id));
            if (ejemplar == null)
            {
                return NotFound();
            }
            ejemplar.IsDeleted = false;
            //Impacta en memoria
            _context.Ejemplares.Update(ejemplar);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool EjemplarExists(int id)
        {
            return _context.Ejemplares.Any(e => e.Id == id);
        }
    }
}
