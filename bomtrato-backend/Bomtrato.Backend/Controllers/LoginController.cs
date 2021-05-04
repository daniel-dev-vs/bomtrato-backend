using Bomtrato.Backend.Data.Entities;
using Bomtrato.Backend.Service.Interfaces;
using Bomtrato.Backend.Service.Services;
using Bomtrato.Backend.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bomtrato.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioService Service;
        public LoginController(IUsuarioService service)
        {
            this.Service = service;
        }


        [HttpPost]
   
        [AllowAnonymous]      
        public ActionResult<dynamic> Autenticar([FromBody] UsuarioDto usuarioLogin) 
        {

            Usuario usuario = Service.SingleOrDefault(x => x.Senha.ToLower() == usuarioLogin.Senha.ToLower() && usuarioLogin.Nome.ToLower() == x.Nome.ToLower());

            if (usuario == null)
                return NotFound("Usuario não encontrado");


            var token = TokenService.GenerateToken(usuario);
            usuario.Senha = "";

            return Ok( new { usuario = usuario, token = token});
        }
    }
}
