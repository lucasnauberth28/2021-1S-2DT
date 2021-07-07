using Microsoft.AspNetCore.Mvc;
using SPMG_WebApi.Domains;
using SPMG_WebApi.Interfaces;
using SPMG_WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Controllers
{ 
    
    [Produces("application/json")]
        [Route("api/[controller]")]
        [ApiController]

    public class ConsultasController : Controller
    {
       private IConsultaRepository _ConsultaRepository { get; set; }

        public ConsultasController()
        {
            _ConsultaRepository = new ConsultaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ConsultaRepository.Listar());
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_ConsultaRepository.BuscarPorId(id));
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost]
        public IActionResult Post(Consulta NovaConsulta)
        {
            try
            {
                _ConsultaRepository.Cadastrar(NovaConsulta);

                return StatusCode(201);
            }
            catch(Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Consulta ConsultaAtualizada)
        {
            try
            {
                _ConsultaRepository.Atualizar(id, ConsultaAtualizada);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _ConsultaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpGet("cons")]
        public IActionResult GetMy()
        {
            try
            {
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
                return Ok(_ConsultaRepository.Minhas(idUsuario));

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Situacao ConsultaPermissao)
        {
            try
            {
                _ConsultaRepository.AlterStatus(id, ConsultaPermissao.Situacao1);

                return StatusCode(204);
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPatch("descricao/{id}")]
        public IActionResult UpdateDescricao(int id, Consulta Descricao)
        {
            try
            {
                _ConsultaRepository.Prontuario(id, Descricao);
                return StatusCode(204);

            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }

        }
    }
}
