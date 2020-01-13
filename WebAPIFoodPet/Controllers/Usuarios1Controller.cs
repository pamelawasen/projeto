using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIFoodPet.Models;
using WebAPIFoodPet.Services;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http.Cors;

namespace WebAPIFoodPet.Controllers
{
    
    [Route("api/use")]
    [ApiController]
    public class Usuarios1Controller : ControllerBase
    {

        private readonly UsuarioService _usContext;
        public Usuarios1Controller(UsuarioService usuarioService)
        {
            _usContext = usuarioService;
        }
        /*  private readonly WebAPIFoodPetContext _context;

          public Usuarios1Controller(WebAPIFoodPetContext context)
          {
              _context = context;
          }*/

        // GET: api/Usuarios1
        /*  [HttpGet]
          public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
          {
              return await _context.Usuario.ToListAsync();
          }

          // GET: api/Usuarios1/5
          [HttpGet]
          [Route("list/{id:int}")]
          public async Task<ActionResult<Usuario>> GetUsuario(int id)
              {
              var usuario = await _context.Usuario.FindAsync(id);

              if (usuario == null)
              {
                  return NotFound();
              }

              return usuario;
          }

          // PUT: api/Usuarios1/5
          [HttpPut("{id}")]
          public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
          {
              if (id != usuario.UsuarioID)
              {
                  return BadRequest();
              }

              _context.Entry(usuario).State = EntityState.Modified;

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!UsuarioExists(id))
                  {
                      return NotFound();
                  }
                  else
                  {
                      throw;
                  }
              }

              return NoContent();
          }*/

        // POST: api/Usuarios1
        [HttpPost]
        [Route("cadastro")]
        [EnableCors(origins: "//", headers: "*", methods: "*")]
        public IActionResult PostUsuario(Usuario usuario)
        {
            _usContext.addUser(usuario);
             return Ok(usuario);
           

           // return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioID }, usuario);
           /* _usContext.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.UsuarioID }, usuario);*/
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login(Usuario user)
        {
            try
            {
                _usContext.LoginUser(user);
                return Ok(user);
            }
            catch (Exception)
            {

                throw new Exception("erro");
            }
        }
        // DELETE: api/Usuarios1/5
       /* [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.UsuarioID == id);
        }*/
    }
}
