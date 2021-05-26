﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;
using WebApi_SPMedical.Interfaces;
using WebApi_SPMedical.Repositories;
using WebApi_SPMedical.ViewModels;

namespace WebApi_SPMedical.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
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
                // Busca o usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // Caso não encontre nenhum usuário com o e-mail e senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem de erro
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Dependências
                    Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
                */

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                // Armazena na Claim o e-mail do usuário autenticado
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                // Armazena na Claim o ID do usuário autenticado
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                // Armazena na Claim o tipo de usuário que foi autenticado (Administrador ou Comum)
                new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
            };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autenticacao"));

                // Define as credenciais do token - Header
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                // Gera o token
                var token = new JwtSecurityToken(
                    issuer: "Sp_medical_group_tarde.webApi",                 // emissor do token
                    audience: "Sp_medical_group_tarde.webApi",               // destinatário do token
                    claims: claims,                                          // dados definidos acima
                    expires: DateTime.Now.AddMinutes(30),                    // tempo de expiração
                    signingCredentials: creds                                // credenciais do token
                );

                // Retorna Ok com o token
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
