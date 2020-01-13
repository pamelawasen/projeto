using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class ClienteDadosService
    {
        private readonly WebAPIFoodPetContext _context;
        public ClienteDadosService(WebAPIFoodPetContext context)
        {
            _context = context;
        }
        public void ClienteDados(ClienteDados cliente)
        {
            _context.ClienteDados.Add(cliente);
            _context.SaveChanges();
        }
    }
}
