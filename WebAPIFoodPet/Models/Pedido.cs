using System;
using System.Collections.Generic;

namespace WebAPIFoodPet.Models
{
    public partial class Pedido
    {
        public int Idpedido { get; set; }
        public int? Idprato { get; set; }
        public int? Idcliente { get; set; }
        public int? IdenderecoCliente { get; set; }
        public double Total { get; set; }
        public DateTime? DtPedidoRealizado { get; set; }
        public DateTime? DtEntregaPedido { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Enderecocliente IdenderecoClienteNavigation { get; set; }
        public virtual Cardapio IdpratoNavigation { get; set; }
    }
}
