using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFoodPet.Models
{
    public class DadosPet
    {
        [Key]
        public int ID { get; set; }
        public string NomePet { get; set; }
        public double PesoPet  { get; set; }
        public int IdadePet { get; set; }
        public ClienteDados ClienteDados { get; set; }
        // Construtor sem argumento
        public DadosPet()
        {
        }

        // Construtor com argumento
        public DadosPet(int petID, string nomePet, int pesoPet, int idadePet, ClienteDados clienteDados_ID)
        {
            ID = petID;
            NomePet = nomePet;
            PesoPet = pesoPet;
            IdadePet = idadePet;
            ClienteDados = clienteDados_ID;
        }


      

    }




}
