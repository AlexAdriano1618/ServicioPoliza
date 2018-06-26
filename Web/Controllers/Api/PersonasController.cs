using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Datos;
using Entidades;
using Entidades.Utils;
using System;

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
        [HttpGet("{id}")]
        public async Task<Response> GetPersona([FromRoute] int id)
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

                var ciudad = await _context.Persona.SingleOrDefaultAsync(m => m.IdPersona == id);

                if (ciudad == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = Mensaje.RegistroNoEncontrado,
                    };
                }

                return new Response
                {
                    IsSuccess = true,
                    Message = Mensaje.Satisfactorio,
                    Resultado = ciudad,
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
        [HttpPut("{id}")]
        public async Task<Response> PutPersona([FromRoute] int id, [FromBody] Persona persona)
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
                var ciudadActualizar = await _context.Persona.Where(x => x.IdPersona == id).FirstOrDefaultAsync();
                if (ciudadActualizar != null)
                {
                    try
                    {
                        ciudadActualizar.Nombre = persona.Nombre;
                        _context.Persona.Update(ciudadActualizar);
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
                return new Response
                {
                    IsSuccess = false,
                    Message = Mensaje.ExisteRegistro
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

        // PUT: api/Personas/5
        
        [HttpPost]
        [Route("InsertarPersona")]
        public async Task<Response> PostPersona([FromBody] Persona persona)
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

                _context.Persona.Add(persona);
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
        

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<Response> DeletePersona([FromRoute] int id)
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

                var respuesta = await _context.Persona.SingleOrDefaultAsync(m => m.IdPersona == id);
                if (respuesta == null)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = Mensaje.RegistroNoEncontrado,
                    };
                }
                _context.Persona.Remove(respuesta);
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

        private bool PersonaExists(int id)
        {
            return _context.Persona.Any(e => e.IdPersona == id);
        }
    }
}