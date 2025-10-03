using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public class CarrerasController : ControllerBase
    {
        private readonly BiblioContext _context;

        public CarrerasController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/Carreras
        //El AsNoTracking es para que no sea modificable la lista que devuelve. Significa que es de solo lectura y mejora el rendimiento. Se aplica a todos los GET y hace que la respuesta sea más rápida.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras([FromQuery] string filtro="")
        {
            return await _context.Carreras.AsNoTracking().Where(a=>a.Nombre.Contains(filtro)).ToListAsync();
        }

        //Recupera las carreras que fueron eliminadas logicamente. El IgnoreQueryFilters es para ignorar el filtro global que tenemos en el datacontext y traer los registros que tienen isdeleted en true.
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetDeletedsCarreras()
        {
            return await _context.Carreras
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted).ToListAsync();
        }

        // GET: api/Carreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(int id)
        {
            var carrera = await _context.Carreras.AsNoTracking().FirstOrDefaultAsync(c=>c.Id.Equals(id));

            if (carrera == null)
            {
                return NotFound();
            }

            return carrera;
        }

        // PUT: api/Carreras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarrera(int id, Carrera carrera)
        {
            if (id != carrera.Id)
            {
                return BadRequest();
            }

            _context.Entry(carrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarreraExists(id))
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

        // POST: api/Carreras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Carrera>> PostCarrera(Carrera carrera)
        {
            _context.Carreras.Add(carrera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarrera", new { id = carrera.Id }, carrera);
        }

        // DELETE: api/Carreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarrera(int id)
        {
            var carrera = await _context.Carreras.FindAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            carrera.IsDeleted=true;
            //Impacta en memoria
            _context.Carreras.Update(carrera);
            //Impacta en la base de datos
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //El restore tiene que ser un PUT porque estamos modificando un recurso existente. Cambia el isdeleted a false. Restaura un autor logico.
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCarrera(int id)
        {
            var carrera = await _context.Carreras.IgnoreQueryFilters().FirstOrDefaultAsync(c => c.Id.Equals(id));
            if (carrera == null)
            {
                return NotFound();
            }
            carrera.IsDeleted = false;
            //Impacta en memoria
            _context.Carreras.Update(carrera);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();
            return NoContent();
        }

        private bool CarreraExists(int id)
        {
            return _context.Carreras.Any(e => e.Id == id);
        }
    }
}
