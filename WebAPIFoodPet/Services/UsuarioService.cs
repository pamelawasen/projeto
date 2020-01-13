
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebAPIFoodPet.Models;
using CryptSharp;
using System.Web.Mvc;

namespace WebAPIFoodPet.Services
{
    public class UsuarioService
    {
        // readonly previne que a dependencia não seja alterada
        private readonly WebAPIFoodPetContext _context;
        public UsuarioService(WebAPIFoodPetContext context)
        {
            _context = context;
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

        public async Task<Microsoft.AspNetCore.Mvc.ActionResult<IEnumerable<Usuario>>> GetUsuario()
          {
              return await _context.Usuario.ToListAsync();
          }

        public void addUser(Usuario user)
        {
            var varificaBanco = _context.Usuario.FirstOrDefault(w => w.Email == user.Email);
        
            var senhaCriptografada = Criptografia.Codifica(user.Senha);
            user.Senha = senhaCriptografada;
            user.DtCriacao = DateTime.Now;
            _context.Usuario.Add(user);
            _context.SaveChanges();
        }

        public void LoginUser(Usuario user)
        {
      
                var usuario = _context.Usuario.FirstOrDefault(x => x.Email == user.Email);
                Criptografia.Compara(user.Senha, usuario.Senha);
         
            
        }
    }
}
