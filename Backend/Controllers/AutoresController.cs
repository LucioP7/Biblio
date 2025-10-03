using Backend.DataContext;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AutoresController : ControllerBase
    {
        //Acceder y manipular los datos de la base de datos a través del contexto de datos BiblioContext.
        private readonly BiblioContext _context;

        //Accede al contructor por inyección de dependencias. Gracias a la configuracion que hacemos en el archivo program. 
        public AutoresController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/Autores
        //AsNoTracking mejora el rendimiento en consultas de solo lectura. Como no seguimiento 
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Autor>>> GetAutores([FromQuery] string filtro="")
        {
            //El a es un parámetro de la expresión lambda, y en este contexto representa una instancia de la entidad Autor.

            //Podrías ponerle cualquier nombre(ejemplo: autor => !autor.IsDeleted), lo importante es que ese parámetro corresponde al tipo definido en Entity<Autor>().

            //No necesariamente tiene que ser la inicial de la entidad. Se suele usar una letra(ejemplo a, u, p) por costumbre y brevedad, pero es válido usar un nombre descriptivo

            return await _context.Autores
                .AsNoTracking()
                .Where(a=>a.Nombre.ToUpper().Contains(filtro.ToUpper()))
                .ToListAsync();

            //Puede coincidir la letra que uses, porque cada lambda vive en su propio ámbito.
            //Buenas prácticas: usá un nombre corto pero representativo para que el código sea más legible.
        }

        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Autor>>> GetDeletedsAutores()
        {
            return await _context.Autores
                .AsNoTracking()
                .IgnoreQueryFilters()
                .Where(a => a.IsDeleted).ToListAsync();
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Autor>> GetAutor(int id)
        {
            var autor = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(a=>a.Id.Equals(id));

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutor(int id, Autor autor)
        {
            if (id != autor.Id)
            {
                return BadRequest();
            }

            _context.Entry(autor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorExists(id))
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

        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Autor>> PostAutor(Autor autor)
        {
            _context.Autores.Add(autor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutor", new { id = autor.Id }, autor);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var autor = await _context.Autores.FindAsync(id);
            if (autor == null)
            {
                return NotFound();
            }
            autor.IsDeleted = true;
            //Impacta en memoria
            _context.Autores.Update(autor);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();

            return NoContent();
        }

        //El restore tiene que ser un PUT porque estamos modificando un recurso existente. Cambia el isdeleted a false.
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreAutor(int id)
        {
            var autor = await _context.Autores.IgnoreQueryFilters().FirstOrDefaultAsync(a=>a.Id.Equals(id));
            if (autor == null)
            {
                return NotFound();
            }
            autor.IsDeleted = false;
            //Impacta en memoria
            _context.Autores.Update(autor);
            //Aca recien impacta en la base de datos
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool AutorExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
