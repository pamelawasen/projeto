using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIFoodPet.Models
{

    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DtCriacao { get; set; }
        //  public ICollection<ClienteDados> DadosUsuarios { get; set; } = new List<ClienteDados>();

        //Construtor sem argumento
        public Usuario()
        {
        }
        //Construtor com argumento
        public Usuario(int usuarioID, string email, string senha, DateTime dtCriacao)
        {
            UsuarioID = usuarioID;
            Email = email;
            Senha = senha;
            DtCriacao = dtCriacao;

        }

    }

}
