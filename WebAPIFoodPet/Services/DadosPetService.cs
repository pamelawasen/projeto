using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class DadosPetService
    {
        private readonly WebAPIFoodPetContext _context;
        public DadosPetService(WebAPIFoodPetContext context)
        {
            _context = context;
        }

        public void CadastroDadosPet(DadosPet dados)
        {
            _context.DadosPets.Add(dados);
            _context.SaveChanges();
        }


    }
}
