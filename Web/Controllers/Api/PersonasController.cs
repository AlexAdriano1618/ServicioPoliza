using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades;
using Entidades.Utils;

namespace Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Personas")]
    public class PersonasController : Controller
    {
        private readonly Ejemplo94Context _context;

        public PersonasController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        [Route("ListarPersonas")]
        public IEnumerable<Persona> GetPersona()
        {
            return _context.Persona;
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = await _context.Persona.SingleOrDefaultAsync(m => m.IdPersona == id);

            if (persona == null)
            {
                return NotFound();
            }

            return Ok(persona);
        }

        // PUT: api/Personas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona([FromRoute] int id, [FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != persona.IdPersona)
            {
                return BadRequest();
            }

            _context.Entry(persona).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        [HttpPost]
        [Route("InsertarPersona")]
        public async Task<IActionResult> PostPersona([FromBody] Persona persona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Persona.Add(persona);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersona", new { id = persona.IdPersona }, persona);
            //if (!ModelState.IsValid)
            //{
            //    return new Response
            //    {
            //        IsSuccess = false,
            //        Message = Mensaje.ModeloInvalido
            //    };
            //}
            //_context.Persona.Add(persona);
            //await _context.SaveChangesAsync();
            //return new Response
            //{
            //    IsSuccess = true
            //    Message = Mensaje.Satisfactorio
            //};
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersona([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var persona = await _context.Persona.SingleOrDefaultAsync(m => m.IdPersona == id);
            if (persona == null)
            {
                return NotFound();
            }

            _context.Persona.Remove(persona);
            await _context.SaveChangesAsync();

            return Ok(persona);
        }

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.IdPersona == id);
        }
    }
}