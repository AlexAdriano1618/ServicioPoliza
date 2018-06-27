using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades;
using Entidades.Utils;

namespace Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/Logins")]
    public class LoginsController : Controller
    {
        private readonly Ejemplo94Context _context;

        public LoginsController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: api/Logins
        [HttpGet]
        [Route("ListaLogin")]
        public IEnumerable<Login> GetLogin()
        {
            return _context.Login;
        }
        [HttpPost]
        [Route("ObtenerUser")]
        public async Task<Response> ObtenerUser([FromBody] Login login)
        {
            try
            {
                var ciudadActualizar = await _context.Login.Where(x => x.Usuario == login.Usuario && x.Clave == login.Clave).FirstOrDefaultAsync();
                if (ciudadActualizar != null)
                {
                    return new Response
                    {
                        IsSuccess = true,
                        Message = Mensaje.UsuarioEncontrado,
                    };
                }
                return new Response
                {
                    IsSuccess = false,
                    Message = Mensaje.ErrorUsuarioEncontrado,
                };

            }
            catch (Exception)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Mensaje.Excepcion
                };
            }
        }
        // GET: api/Logins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.SingleOrDefaultAsync(m => m.IdLogin == id);

            if (login == null)
            {
                return NotFound();
            }

            return Ok(login);
        }

        // PUT: api/Logins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogin([FromRoute] int id, [FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != login.IdLogin)
            {
                return BadRequest();
            }

            _context.Entry(login).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoginExists(id))
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

        // POST: api/Logins
        [HttpPost]
        public async Task<IActionResult> PostLogin([FromBody] Login login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Login.Add(login);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LoginExists(login.IdLogin))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLogin", new { id = login.IdLogin }, login);
        }

        // DELETE: api/Logins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogin([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var login = await _context.Login.SingleOrDefaultAsync(m => m.IdLogin == id);
            if (login == null)
            {
                return NotFound();
            }

            _context.Login.Remove(login);
            await _context.SaveChangesAsync();

            return Ok(login);
        }

        private bool LoginExists(int id)
        {
            return _context.Login.Any(e => e.IdLogin == id);
        }
    }
}