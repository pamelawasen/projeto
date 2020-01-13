using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class EnderecoService
    {
        private readonly MyDbContext _context;
        public EnderecoService(MyDbContext context)
        {
            _context = context;
        }
      

        public  Enderecocliente AddEndereco(Endereco endereco, int idCliente)
        {
            if (endereco != null)
            {
                Enderecocliente end = new Enderecocliente();
                _context.Endereco.Add(endereco);
                _context.SaveChanges();
                var enrecoSalvo = _context.Endereco.ToList();
                foreach (var item in enrecoSalvo)
                {
                    end.Idendereco = item.Idendereco;
                }
                end.Idcliente = idCliente;
                _context.Enderecocliente.Add(end);
                _context.SaveChanges();
                return end;
            }
            return null;
            
        }

    }
}
