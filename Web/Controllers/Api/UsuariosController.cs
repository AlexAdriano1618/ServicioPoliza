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
    [Route("api/Usuarios")]
    public class UsuariosController : Controller
    {
        private readonly Ejemplo94Context _context;

        public UsuariosController(Ejemplo94Context context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [Route("ListarUsuarios")]
        [HttpGet]
        public IEnumerable<Usuarios> GetUsuarios()
        {
            return _context.Usuarios;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<Response> GetUsuarios([FromRoute] int id)
        {
            var usuarios = await _context.Usuarios.SingleOrDefaultAsync(m => m.IdUsuario == id);
            if (usuarios != null)
            {
                return new Response
                {
                    IsSuccess = true,
                    Message = Mensaje.Satisfactorio,
                    Resultado = usuarios
                };
            }

            return new Response
            {
                IsSuccess = false,
                Message = Mensaje.ModeloInvalido
            };
        }

        // PUT: api/Usuarios/5
        [HttpPut("{id}")]
        public async Task<Response> PutUsuarios([FromRoute] int id, [FromBody] Usuarios usuarios)
        {
            if (!ModelState.IsValid)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Mensaje.ModeloInvalido
                };
            }

            var modificar = await _context.Usuarios.Where(x => x.IdUsuario == id).FirstOrDefaultAsync();
            if (modificar != null)
            {
                modificar.Nombres = usuarios.Nombres;
                modificar.Apellido = usuarios.Apellido;
                modificar.Apellido2 = usuarios.Apellido2;
                _context.Usuarios.Update(modificar);
                await _context.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Message = Mensaje.Satisfactorio
                };
            }
            return new Response
            {
                IsSuccess = false,
                Message = Mensaje.Error
            };
        }

        // POST: api/Usuarios
        [Route("InsertarUsuaruo")]
        [HttpPost]
        public async Task<Response> PostUsuarios([FromBody] Usuarios usuarios)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = Mensaje.ModeloInvalido
                    };
                }
                _context.Usuarios.Add(usuarios);
                await _context.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Message = Mensaje.Satisfactorio
                };

            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = Mensaje.Error,
                };
              }
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<Response> DeleteUsuarios([FromRoute] int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = Mensaje.ModeloInvalido,
                    };
                }

                var respuesta = await _context.Usuarios.SingleOrDefaultAsync(m => m.IdUsuario == id);
                if (respuesta == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = Mensaje.RegistroNoEncontrado,
                    };
                }
                _context.Usuarios.Remove(respuesta);
                await _context.SaveChangesAsync();

                return new Response
                {
                    IsSuccess = true,
                    Message = Mensaje.Satisfactorio,
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = Mensaje.Error,
                };
            }
        }

        private bool UsuariosExists(int id)
        {
            return _context.Usuarios.Any(e => e.IdUsuario == id);
        }
    }
}