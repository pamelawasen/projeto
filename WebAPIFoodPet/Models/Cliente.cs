using System;
using System.Collections.Generic;

namespace WebAPIFoodPet.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Descricaopedido = new HashSet<Descricaopedido>();
            Pedido = new HashSet<Pedido>();
        }

        public int Idcliente { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public int? Telefone { get; set; }
        public string Senha { get; set; }
        public DateTime? DtCriacao { get; set; }

        public virtual ICollection<Descricaopedido> Descricaopedido { get; set; }
        public virtual ICollection<Pedido> Pedido { get; set; }
    }
}
