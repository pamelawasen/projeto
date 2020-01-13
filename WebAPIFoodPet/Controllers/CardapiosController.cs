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

namespace WebAPIFoodPet.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class CardapiosController : ControllerBase
    {
        private readonly MyDbContext _context;

        public CardapiosController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Cardapios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cardapio>>> GetCardapio()
        {
            return await _context.Cardapio.ToListAsync();
        }
        [HttpGet]
        [Route("teste")]
        public HttpResponseMessage get()
        {
            HttpResponseMessage Message = new HttpResponseMessage();
            Message.StatusCode = HttpStatusCode.OK;
            Message.Content = new StringContent("Success: registered.");
            return Message;
        }

        // GET: api/Cardapios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cardapio>> GetCardapio(int id)
        {
            var cardapio = await _context.Cardapio.FindAsync(id);

            if (cardapio == null)
            {
                return NotFound();
            }

            return cardapio;
        }

        // PUT: api/Cardapios/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardapio(int id, Cardapio cardapio)
        {
            if (id != cardapio.Idprato)
            {
                return BadRequest();
            }

            _context.Entry(cardapio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardapioExists(id))
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

        // POST: api/Cardapios
        [HttpPost]
        public async Task<ActionResult<Cardapio>> PostCardapio(Cardapio cardapio)
        {
            _context.Cardapio.Add(cardapio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardapio", new { id = cardapio.Idprato }, cardapio);
        }

        // DELETE: api/Cardapios/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cardapio>> DeleteCardapio(int id)
        {
            var cardapio = await _context.Cardapio.FindAsync(id);
            if (cardapio == null)
            {
                return NotFound();
            }

            _context.Cardapio.Remove(cardapio);
            await _context.SaveChangesAsync();

            return cardapio;
        }

  
        private bool CardapioExists(int id)
        {
            return _context.Cardapio.Any(e => e.Idprato == id);
        }
    }
}
