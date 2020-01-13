using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class PedidoService
    {
        private readonly MyDbContext _context;
        public PedidoService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<Pedido>> RealizaPedido(Pedido ped)
        {
            
            ped.DtPedidoRealizado = DateTime.Now;
            DateTime dataRealizado = (DateTime)ped.DtPedidoRealizado;
            ped.DtEntregaPedido = dataRealizado.AddHours(48);
            _context.Pedido.Add(ped);
            _context.SaveChanges();
            return ped;
        }

        public async Task<ActionResult<Descricaopedido>> save(Descricaopedido descricaopedido)
        {
            _context.Descricaopedido.Add(descricaopedido);
            _context.SaveChanges();
            return descricaopedido;
        }

        public DetalhePedido Informacoes(int idcliente)
        {
            var endereco = _context.Enderecocliente.FirstOrDefault(w => w.Idcliente == idcliente);
            var end = _context.Endereco.Select(s => s.Idendereco == endereco.Idendereco).ToList();
            var detalhe = new DetalhePedido();
            detalhe.IDcliente = endereco.Idcliente;
            return detalhe; 


               
        }
    }
}
