using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIFoodPet;
using WebAPIFoodPet.Models;
using WebAPIFoodPet.Services;

namespace WebAPIFoodPet.Controllers
{
    [Route("api/cadastro")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClienteDadosService _clientecontext;
        public ClientesController(ClienteDadosService clienteDadosService)
        {
            _clientecontext = clienteDadosService;
        }


        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _clientecontext.GetClientes(id);

            if (cliente == null)
            {
                return BadRequest();
            }

            return cliente;
        }

        [HttpPost]
        [Route("login")]
        public  ActionResult<Cliente> Login(Cliente usuario)
        {
            try
            {
                var result = _clientecontext.LoginUser(usuario);

                return result;
            }
            catch (Exception)
            {

                return BadRequest();
            }

           
        }
        // PUT: api/Clientes/5
    /*    [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Idcliente)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        [HttpPost]
        [Route("insere")]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            try
            {
                _clientecontext.SaveDados(cliente);
               return CreatedAtAction("GetCliente", new { id = cliente.Idcliente }, cliente);
            }
            catch (Exception)
            {

                throw new ApplicationException("erro") ;
            }

           
            /* _context.Cliente.Add(cliente);
             await _context.SaveChangesAsync();*/
            
           
        }

        // DELETE: api/Clientes/5
      /*  [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> DeleteCliente(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return _context.Cliente.Any(e => e.Idcliente == id);
        }*/
    }
}
