using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFoodPet.Models
{
    public class ClienteDados
    {
        [Key]
        public int IDCliente { get; set; }
        public string NomeCliente { get; set; }
        public string CPF { get; set; }
        public int ClienteTelefone { get; set; }
        public Usuario Usuarios { get; set; }
        public ICollection<Endereco> Endereco_ID { get; set; } = new List<Endereco>();
        public ICollection<Pedido> Pedido_ID { get; set; } = new List<Pedido>();
        public ICollection<DadosPet> DadosPet_ID { get; set; } = new List<DadosPet>();

        //Construtor sem argumento
        public ClienteDados()
        {
        }

        public ClienteDados(int iD, Usuario usuarios, string cpf, int clienteTelefone)
        {
            IDCliente = iD;
            Usuarios = usuarios;
            CPF = cpf;
            ClienteTelefone = clienteTelefone;
        }
    }
}
