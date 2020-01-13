using CryptSharp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;

namespace WebAPIFoodPet.Services
{
    public class ClienteDadosService
    {
        private readonly MyDbContext _context;
        public ClienteDadosService(MyDbContext context)
        {
            _context = context;
        }
        public Task<Cliente> GetClientes(int id) {
            var cliente =  _context.Cliente.FindAsync(id);
            return cliente;
        }
        public static class Criptografia
        {
            public static string Codifica(string senha)
            {
                return Crypter.MD5.Crypt(senha);
            }

            public static bool Compara(string senha, string hash)
            {
                return Crypter.CheckPassword(senha, hash);
            }
        }

        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Cliente>>> GetUsuario()
        {
            return await _context.Cliente.ToListAsync();
        }

        public void SaveDados(Cliente cliente)
        {
            var verifica = _context.Cliente.FirstOrDefault(w => w.Email == cliente.Email);
            var senhaCriptografada = Criptografia.Codifica(cliente.Senha);
            cliente.Senha = senhaCriptografada;
            cliente.DtCriacao = DateTime.Now;
            _context.Cliente.Add(cliente);
            _context.SaveChanges();
        }

        public Cliente LoginUser(Cliente usuario)
        {
         
                var usuarios = _context.Cliente.FirstOrDefault(x => x.Email == usuario.Email);

                var result = Criptografia.Compara(usuario.Senha, usuarios.Senha);

                if (result)
                {

                return usuarios;
            }
            else
          
            {
                return null;
            }
            
           
        }
    }
}
