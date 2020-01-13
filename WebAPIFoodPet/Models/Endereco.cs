using System;
using System.Collections.Generic;

namespace WebAPIFoodPet.Models
{
    public partial class Endereco
    {
        public Endereco()
        {
            Enderecocliente = new HashSet<Enderecocliente>();
        }

        public int Idendereco { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string NmCep { get; set; }

        public virtual ICollection<Enderecocliente> Enderecocliente { get; set; }
    }
}
