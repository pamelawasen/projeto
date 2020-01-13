using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFoodPet.Models
{
    public class EnderecoUsuario
    {
        [Key]
        public int IDEnderecoUsuario { get; set; }
        public ClienteDados ClienteDados_ID { get; set; }
        public Endereco Enderecos_ID { get; set; }
    }
}
