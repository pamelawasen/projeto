using System;
using System.Collections.Generic;

namespace WebAPIFoodPet.Models
{
    public partial class Cardapio
    {
        public Cardapio()
        {
            Descricaopedido = new HashSet<Descricaopedido>();
            Pedido = new HashSet<Pedido>();
        }

        public int Idprato { get; set; }
        public string DsPrato { get; set; }
        public double? Valor { get; set; }

        public virtual ICollection<Descricaopedido> Descricaopedido { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
