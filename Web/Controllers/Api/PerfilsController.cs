using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades;

namespace Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Perfils")]
    public class PerfilsController : Controller
    {
        private readonly Ejemplo94Context _context;

        public PerfilsController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: api/Perfils
        [HttpGet]
        [Route("ListarPerfiles")]
        public IEnumerable<Perfil> GetPerfil()
        {
            return _context.Perfil;
        }

        // GET: api/Perfils/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerfil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfil.SingleOrDefaultAsync(m => m.IdPerfil == id);

            if (perfil == null)
            {
                return NotFound();
            }

            return Ok(perfil);
        }

        // PUT: api/Perfils/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerfil([FromRoute] int id, [FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != perfil.IdPerfil)
            {
                return BadRequest();
            }

            _context.Entry(perfil).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PerfilExists(id))
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

        // POST: api/Perfils
        [HttpPost]
        public async Task<IActionResult> PostPerfil([FromBody] Perfil perfil)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Perfil.Add(perfil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerfil", new { id = perfil.IdPerfil }, perfil);
        }

        // DELETE: api/Perfils/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerfil([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var perfil = await _context.Perfil.SingleOrDefaultAsync(m => m.IdPerfil == id);
            if (perfil == null)
            {
                return NotFound();
            }

            _context.Perfil.Remove(perfil);
            await _context.SaveChangesAsync();

            return Ok(perfil);
        }

        private bool PerfilExists(int id)
        {
            return _context.Perfil.Any(e => e.IdPerfil == id);
        }
    }
}