using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SPMG_WebApi.Domains;
using SPMG_WebApi.Interfaces;
using SPMG_WebApi.Repositories;
using SPMG_WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SPMG_WebApi.Controllers
{
   
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class LoginController : Controller
        {
            private IUsuarioRepository _usuarioRepository { get; set; }

            public LoginController()
            {
                _usuarioRepository = new UsuarioRepository();
            }

            [HttpPost]
            public IActionResult Post(LoginViewModel login)
            {
                try
                {
                    Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                    if (usuarioBuscado == null)
                    {
                        return NotFound("E-mail ou senha inválidos!");
                    }



                    var claims = new[]
                    {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                new Claim(ClaimTypes.Role, usuarioBuscado.IdTiposUsuarios.ToString())
            };

                    var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autenticacao"));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "Sp_medical_group_tarde.webApi",
                        audience: "Sp_medical_group_tarde.webApi",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token)
                    });
                }
                catch (Exception ex)
                {
                    return BadRequest(ex);
                }
            }
        }
   }