using System;
using System.Collections.Generic;

namespace WebAPIFoodPet.Models
{
    public partial class Enderecocliente
    {
        public Enderecocliente()
        {
            Pedido = new HashSet<Pedido>();
        }

        public int IdenderecoCliente { get; set; }
        public int? Idcliente { get; set; }
        public int? Idendereco { get; set; }

        public virtual Endereco IdenderecoNavigation { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
