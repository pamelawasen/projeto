using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class EnderecoService
    {
        private readonly WebAPIFoodPetContext _context;
        public EnderecoService(WebAPIFoodPetContext context)
        {
            _context = context;
        }
    }
}
