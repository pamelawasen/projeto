using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebAPIFoodPet.Models
{
    public class WebAPIFoodPetContext : DbContext
    {
        public WebAPIFoodPetContext (DbContextOptions<WebAPIFoodPetContext> options)
            : base(options)
        {
        }

      /*  public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cardapio> Cardapio { get; set; }
        public DbSet<DadosPet> DadosPets { get; set; }
        public DbSet<ClienteDados> ClienteDados { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
       */
    }
}
