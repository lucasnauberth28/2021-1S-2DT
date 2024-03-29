﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Peoples.Domains;
using Peoples.Interfaces;
using Peoples.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]
        public class FuncionariosController : ControllerBase
        {
            /// <summary>
            /// Objeto _funcionarioRepository que irá receber todos os métodos definidos na interface IFuncionarioRepository
            /// </summary>
            private IFuncionarioRepository _funcionarioRepository { get; set; }

            /// <summary>
            /// Instancia o objeto _funcionarioRepository para que haja a referência aos métodos no repositório
            /// </summary>
            /// método contrutor é uma função que vai ser executada toda vez que essa classe for chamada
            public FuncionariosController()
            {
                _funcionarioRepository = new FuncionarioRepository();
            }
            [Authorize] // verifica se o usuário está logado, caso não esteja, retorna um erro 401
            [HttpGet]
            public IActionResult Get()
            {
                // cria uma lista nomeada "listaFuncionarios" para receber os dados
                // aqui está sendo listado todos os funcionários e armazenando na lista
                // se eu quero enviar uma lista pra quem tá pedindo
                List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.Listar();

                // retorna o status code 200(Ok) com a lista de funcionarios no formato JSON
                return Ok(listaFuncionarios);
            }
            [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
            [HttpGet("nomesCompletos")]
            public IActionResult GetCompleteName()
            {
                List<FuncionarioDomain> listaFuncionarios = _funcionarioRepository.Listar(); // aqui apenas é necessário pegar as informações do método "Listar" do repository (não será necessário criar um método)

                if (listaFuncionarios != null) // se listaFuncionarios for diferente de null...
                {
                    // faz um try catch:
                    try // se a tentativa der certo...
                    {
                        // junta o nome e o sobrenome em um só atributo (em uma chave) e faz o nome e sobrenome sumir e virar apenas o "nomeCompleto"
                        List<object> listaNomesCompletos = new List<object>();

                        foreach (var item in listaFuncionarios) // aqui vai ler casa item que existe dentro de "listaFuncionarios"
                        {
                            // aqui será possível mudar o nome dos atributos(por exemplo, mudar o "idFuncionario" para apenas "id", mas continuando com as informações certas) e/ou juntar atributos em um só como se estivesse usando um SELECT CONCAT(por exemplo, é possível juntar os atributos "nome" e "sobrenome" em um "nome completo")
                            object objeto = new { idFuncionario = item.idFuncionario, nomeCompleto = item.nome + ' ' + item.sobrenome, dataNascimento = item.dataNascimento };
                            listaNomesCompletos.Add(objeto);
                        }
                        return Ok(listaNomesCompletos);
                    }

                    // caso ocorra algum erro...
                    catch (Exception codErro)
                    {
                        // retorna um status code 400 - BadRequest e o código do erro
                        return BadRequest(codErro);
                    }
                }

                // se a listaFuncionarios for igual null...
                else
                    // retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Nenhum funcionário encontrado!");
            }
            [Authorize] // verifica se o usuário está logado, caso não esteja, retorna um erro 401
            /// http://localhost:5000/api/funcionarios/idFuncionario
            [HttpGet("{id}")]
            public IActionResult GetById(int id)
            {
                // cria um objeto "funcionarioBuscado" que irá receber o "funcionarioBuscado" no banco de dados
                FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);
                // um "=" é atribuição, um "==" é uma comparação

                // verifica se nenhum funcionário foi encontrado
                if (funcionarioBuscado == null)
                {
                    // caso não seja encontrado, retorna um status code 404 - Not Found com uma mensagem personalizada
                    return NotFound("Nenhum funcionário encontrado!");
                }

                // caso seja encontrado, retorna o funcionário buscado com um status code 200 - Ok
                return Ok(funcionarioBuscado);
            }
            [Authorize] // verifica se o usuário está logado, caso não esteja, retorna um erro 401
            [HttpGet("buscar/{buscado}")]
            public IActionResult GetByName(string buscado)
            {
                FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorNome(buscado);

                if (funcionarioBuscado == null)
                {
                    return NotFound("Nenhum funcionário encontrado!");
                }
                else
                    return Ok(funcionarioBuscado);
            }
            [Authorize] // verifica se o usuário está logado, caso não esteja, retorna um erro 401
            /// exemplo: http://localhost:5000/api/funcionarios
            [HttpPost]
            public IActionResult Post(FuncionarioDomain novoFuncionario)
            {
                try // tenta executar...
                {
                    // se o conteúdo do nome e/ou do sobrenome do novo funcionário estar vazio ou com um espaço em branco...
                    if (String.IsNullOrWhiteSpace(novoFuncionario.nome))
                    {
                        // retorna um status code 404 - Not Found com uma mensagem personalizada
                        return NotFound("Campo 'nome' obrigatório!");
                    }
                    if (String.IsNullOrWhiteSpace(novoFuncionario.sobrenome))
                    {
                        // retorna um status code 404 - Not Found com uma mensagem personalizada
                        return NotFound("Campo 'sobrenome' obrigatório!");
                    }
                    else
                        // faz a chamada para o método Cadastrar
                        _funcionarioRepository.Cadastrar(novoFuncionario);

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
            [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro        /// http://localhost:5000/api/funcionarios/idFuncionario
            [HttpPut("{id}")]
            public IActionResult PutIdUrl(int id, FuncionarioDomain funcionarioAtualizado)
            {
                // cria um objeto "funcionarioBuscado" que irá receber o gênero buscado do banco de dados
                FuncionarioDomain funcionarioBuscado = _funcionarioRepository.BuscarPorId(id);

                // caso ele não seja encontrado, retorna um NotFoud com uma mensagem personalizada
                // e um bool para apresentar que houve um erro
                if (funcionarioBuscado == null)
                {
                    return NotFound(new { mensagem = "Funcionário não encontrado!" });
                }

                // o "try/catch" serve para tratamento de erros
                // tenta atualizar o registro(funcionario) || se não acontece nenhum erro...
                try
                {
                    // faz a chamada para o método .AtualizarIdUrl()
                    _funcionarioRepository.Atualizar(id, funcionarioAtualizado);

                    // retorna um status code 204 - No Content
                    return NoContent();
                }
                catch (Exception codErro)
                {
                    // retorna um status code 400 - BadRequest e o código do erro
                    return BadRequest(codErro);
                }
            }


            [Authorize(Roles = "1")] // verifica se o usuário está logado com a permissão de Administrador, caso não esteja, retornará um erro
                /// http://localhost:5000/api/funcionarios/idFuncionario
                [HttpDelete("{id}")]
                public IActionResult Delete(int id)
                {
                    // faz a chamada para o método .Deletar
                    _funcionarioRepository.Deletar(id);

                    // retorna o status code 204 - No Content
                    return StatusCode(204);
                }


            }
        }
    }

