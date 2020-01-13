using System;
using System.Collections.Generic;

namespace WebAPIFoodPet.Models
{
    public partial class Descricaopedido
    {
        public int IddescricaoPedido { get; set; }
        public string DsPrato { get; set; }
        public int? Idprato { get; set; }
        public int? Idcliente { get; set; }
        public double? Valor { get; set; }
        public int Quantidade { get; set; }

        public virtual Cliente IdclienteNavigation { get; set; }
        public virtual Cardapio IdpratoNavigation { get; set; }
    }
}
