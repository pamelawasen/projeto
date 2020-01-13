using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPIFoodPet.Models;
using WebAPIFoodPet.Services;

namespace WebAPIFoodPet.Controllers
{
    [Route("api/pedido")]
    [ApiController]
    public class PedidoesController : ControllerBase
    {
        private readonly PedidoService _pedcontext;

        public PedidoesController(PedidoService context)
        {
            _pedcontext = context;
        }

        /*  // GET: api/Pedidoes
          [HttpGet]
          public async Task<ActionResult<IEnumerable<Pedido>>> GetPedido()
          {
              return await _context.Pedido.ToListAsync();
          }

          // GET: api/Pedidoes/5
          [HttpGet("{id}")]
          public async Task<ActionResult<Pedido>> GetPedido(int id)
          {
              var pedido = await _context.Pedido.FindAsync(id);

              if (pedido == null)
              {
                  return NotFound();
              }

              return pedido;
          }

          // PUT: api/Pedidoes/5
          [HttpPut("{id}")]
          public async Task<IActionResult> PutPedido(int id, Pedido pedido)
          {
              if (id != pedido.Idpedido)
              {
                  return BadRequest();
              }

              _context.Entry(pedido).State = EntityState.Modified;

              try
              {
                  await _context.SaveChangesAsync();
              }
              catch (DbUpdateConcurrencyException)
              {
                  if (!PedidoExists(id))
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

        [HttpPost]
        [Route("preenche")]
        public async Task<ActionResult<Descricaopedido>> Salvar(Descricaopedido desc)
        {
            var busped = _pedcontext.save(desc);
            return await busped;

        }
        // POST: api/Pedidos
        [HttpPost]
        public async Task<ActionResult<Pedido>> PostPedido(Pedido pedido)
        {

            var busPedido = _pedcontext.RealizaPedido(pedido);
            return await busPedido;

        }


        [HttpGet]
        [Route("info/{id}")]
        public DetalhePedido GetInfo(int id)
        {
            var pedido = _pedcontext.Informacoes(id);

            return pedido;
        }



        // DELETE: api/Pedidoes/5
        /* [HttpDelete("{id}")]
         public async Task<ActionResult<Pedido>> DeletePedido(int id)
         {
             var pedido = await _context.Pedido.FindAsync(id);
             if (pedido == null)
             {
                 return NotFound();
             }

             _context.Pedido.Remove(pedido);
             await _context.SaveChangesAsync();

             return pedido;
         }

         private bool PedidoExists(int id)
         {
             return _context.Pedido.Any(e => e.Idpedido == id);
         }*/
    }
}
