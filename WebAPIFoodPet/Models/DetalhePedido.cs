using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFoodPet.Models
{
   
    public class DetalhePedido {
        public int? IDcliente { get; set; }
        public int IDEnderecoCliente { get; set; }
        public string Dsprato { get; set; }
        public List<Descricaopedido> Compras { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public double Total { get; set; }
        public int Quantidade { get; set; }
        public string DataEntrega { get; set; }
    
    }
}
