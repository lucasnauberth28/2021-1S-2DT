using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Peoples.Domains;
using Peoples.Interfaces;
using Peoples.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Peoples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        public DateTime? DataTime { get; set; }

        [HttpPost("login")]
        public IActionResult Login(UsuarioDomain login)
        {

            UsuarioDomain usuarioBuscado = _usuarioRepository.Logar(login.email, login.senha);

            if (usuarioBuscado == null)
            {
                return NotFound("E-mail ou senha inválidos");
            }
            var claims = new[]
          {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString()),
            };

            var secretkey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("peoples-chave-autenticacao"));

            var credentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken
           (
                issuer: "Peoples.webAPI",
                audience: "Peoples.webAPI",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials
            );

            return Ok(new
            {
                // pegou todos os campos de "token" e jogou dentro do return
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> listaUsuario = _usuarioRepository.Listar();

            return Ok(listaUsuario);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum Usuário encontrado!");
            }

            return Ok(usuarioBuscado);
        }

        [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
        /// http://localhost:5000/api/funcionarios/idFuncionario
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // faz a chamada para o método .Deletar
            _usuarioRepository.Deletar(id);

            // retorna o status code 204 - No Content
            return StatusCode(204);
        }


        [Authorize] // verifica se o usuário está logado, caso não esteja, retorna um erro 401
        /// exemplo: http://localhost:5000/api/usuarios
        [HttpPost("cadastrar")]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            try // tenta executar...
            {
                // se o conteúdo do email e/ou da senha do novo usuário estar vazio ou com um espaço em branco...
                if (String.IsNullOrWhiteSpace(novoUsuario.email))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'email' obrigatório!");
                }
                if (String.IsNullOrWhiteSpace(novoUsuario.senha))
                {
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Campo 'senha' obrigatório!");
                }

                // se estiver tudo preenchido...
                else
                    // faz a chamada para o método Cadastrar
                    _usuarioRepository.Cadastrar(novoUsuario);

                // e retorna o status code 201 - Created
                return StatusCode(201);
            }

            // se não conseguiu executar...
            catch (Exception codErro)
            {
                // retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }
    }
}


