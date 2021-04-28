using InLock_Senai_WebAPI.Domains;
using InLock_Senai_WebAPI.Interfaces;
using InLock_Senai_WebAPI.Repositories;
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
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<JogosDomain> ListaJogos = _jogoRepository.Listar();

            return Ok(ListaJogos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            // Cria um objeto generoBuscado que irá receber o gênero buscado no banco de dados
            JogosDomain JogoBuscado = _jogoRepository.BuscarPorId(id);

            // Verifica se nenhum gênero foi encontrado
            if (JogoBuscado == null)
            {
                // Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                return NotFound("Nenhum jogo encontrado!");
            }

            // Caso seja encontrado, retorna o gênero buscado com um status code 200 - Ok
            return Ok(JogoBuscado);
        }


        [HttpPost]
        public IActionResult Post(JogosDomain novoJogo)
        {
            // Faz a chamada para o método .Cadastrar()
            _jogoRepository.Cadastrar(novoJogo);

            // Retorna um status code 201 - Created
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, JogosDomain jogoAtualizado)
        {
            // Cria um objeto usuarioBuscado que irá receber o usuario buscado no banco de dados
            JogosDomain jogoBuscado = _jogoRepository.BuscarPorId(id);

            // Caso não seja encontrado, retorna NotFound com uma mensagem personalizada
            // e um bool para apresentar que houve erro
            if (jogoBuscado == null)
            {
                return NotFound
                    (
                        new
                        {
                            mensagem = "Jogo não encontrado!",
                            erro = true
                        }
                    );
            }
            // Tenta atualizar o registro
            try
            {
                // Faz a chamada para o método .AtualizarIdUrl()
                _jogoRepository.Atualizar(id, jogoAtualizado);

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
        /// http://localhost:5000/api/generos/11
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            // Faz a chamada para o método .Deletar()
            _jogoRepository.Deletar(id);

            // Retorna um status code 204 - No Content
            return StatusCode(204);
        }
    }
}
