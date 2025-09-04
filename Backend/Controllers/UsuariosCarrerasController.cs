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
    public class UsuariosCarrerasController : ControllerBase
    {
        private readonly BiblioContext _context;

        public UsuariosCarrerasController(BiblioContext context)
        {
            _context = context;
        }

        // GET: api/UsuariosCarreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioCarrera>>> GetUsuarioCarreras()
        {
            return await _context.UsuarioCarreras
                                 .Include(uc => uc.Usuario)
                                 .Include(uc => uc.Carrera)
                                 .AsNoTracking()
                                 .ToListAsync();
        }

        // GET: api/UsuariosCarreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioCarrera>> GetUsuarioCarrera(int id)
        {
            var usuarioCarrera = await _context.UsuarioCarreras
                                               .Include(uc => uc.Usuario)
                                               .Include(uc => uc.Carrera)
                                               .FirstOrDefaultAsync(uc => uc.Id == id);

            if (usuarioCarrera == null)
            {
                return NotFound();
            }

            return usuarioCarrera;
        }

        // PUT: api/UsuariosCarreras/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarioCarrera(int id, UsuarioCarrera usuarioCarrera)
        {
            _context.TryAttach(usuarioCarrera?.Usuario);
            _context.TryAttach(usuarioCarrera?.Carrera);
            if (id != usuarioCarrera.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuarioCarrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioCarreraExists(id))
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

        // POST: api/UsuariosCarreras
        [HttpPost]
        public async Task<ActionResult<UsuarioCarrera>> PostUsuarioCarrera(UsuarioCarrera usuarioCarrera)
        {
            _context.TryAttach(usuarioCarrera?.Usuario);
            _context.TryAttach(usuarioCarrera?.Carrera);
            _context.UsuarioCarreras.Add(usuarioCarrera);
            await _context.SaveChangesAsync();

            // Traemos de nuevo con include para devolver usuario y carrera
            var result = await _context.UsuarioCarreras
                                       .Include(uc => uc.Usuario)
                                       .Include(uc => uc.Carrera)
                                       .FirstOrDefaultAsync(uc => uc.Id == usuarioCarrera.Id);

            return CreatedAtAction("GetUsuarioCarrera", new { id = usuarioCarrera.Id }, result);
        }

        // DELETE: api/UsuariosCarreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarioCarrera(int id)
        {
            var usuarioCarrera = await _context.UsuarioCarreras.FindAsync(id);
            if (usuarioCarrera == null)
            {
                return NotFound();
            }

            _context.UsuarioCarreras.Remove(usuarioCarrera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioCarreraExists(int id)
        {
            return _context.UsuarioCarreras.Any(e => e.Id == id);
        }
    }
}
