using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class PedidoService
    {
        private readonly WebAPIFoodPetContext _context;
        public PedidoService(WebAPIFoodPetContext context)
        {
            _context = context;
        }

        public void  RealizaPedido(Pedido ped)
        {

            _context.Pedidos.Add(ped);
            _context.SaveChanges();

        }
    }
}
