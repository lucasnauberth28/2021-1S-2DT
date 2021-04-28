using InLock_Senai_WebAPI.Domains;
using InLock_Senai_WebAPI.Interfaces;
using InLock_Senai_WebAPI.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<UsuarioDomain> ListaUsuarios = _usuarioRepository.Listar();

            return Ok(ListaUsuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            UsuarioDomain UsuarioBuscado = _usuarioRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (UsuarioBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum usuario encontrado!");
            }

            // Caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
            return Ok(UsuarioBuscado);
        }

        //[Authorize(Roles = "1"]

        [HttpPost]
        public IActionResult Post(UsuarioDomain novoUsuario)
        {
            // Faz a chamada para o método .Cadastrar()
            _usuarioRepository.Cadastrar(novoUsuario);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, UsuarioDomain usuarioAtualizado)
        {
            // Cria um objeto usuarioBuscado que irá receber o usuario buscado no banco de dados
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (usuarioBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Usuário não encontrado!",
                            erro = true
                        }
                    );
            }

            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _usuarioRepository.Atualizar(id, usuarioAtualizado);

                // Retorna um status code 204 - No Content
                return NoContent();
            }
            // Caso ocorra algum erro
            catch (Exception codErro)
            {
                // Retorna um status code 400 - BadRequest e o código do erro
                return BadRequest(codErro);
            }
        }

      
        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="id">id do gênero que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        /// http://localhost:5000/api/generos/11
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _usuarioRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}

