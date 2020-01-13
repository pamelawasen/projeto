using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIFoodPet;
using WebAPIFoodPet.Models;
using WebAPIFoodPet.Services;

namespace WebAPIFoodPet.Controllers
{
    [Route("api/endereco")]
    [ApiController]
    public class EnderecoesController : ControllerBase
    {
        private readonly EnderecoService _enderecocontext;
        public EnderecoesController(EnderecoService enderecoService)
        {
            _enderecocontext = enderecoService;
        }

       /* // GET: api/Enderecoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEndereco()
        {
            return await _context.Endereco.ToListAsync();
        }

        // GET: api/Enderecoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        // PUT: api/Enderecoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.Idendereco)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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
        */
        // POST: api/Enderecoes
        [HttpPost]
        [Route("addendereco/{idcliente}")]
        public async Task<ActionResult<Enderecocliente>> PostEndereco(int idcliente, Endereco endereco)
        {
            var busEndereco = _enderecocontext.AddEndereco(endereco, idcliente);
            return busEndereco;
        }

        // DELETE: api/Enderecoes/5
     /*   [HttpDelete("{id}")]
        public async Task<ActionResult<Endereco>> DeleteEndereco(int id)
        {
            var endereco = await _context.Endereco.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Endereco.Remove(endereco);
            await _context.SaveChangesAsync();

            return endereco;
        }

        private bool EnderecoExists(int id)
        {
            return _context.Endereco.Any(e => e.Idendereco == id);
        }*/
    }
}
