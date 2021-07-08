using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using SPMedicalGroup.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultasController : Controller
    {
        private IConsulta _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        [HttpGet("todas")]
        public IActionResult GetConsultas()
        {
            try
            {
                return Ok(_consultaRepository.ListarTudo());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("medico")]
        public IActionResult GetMedico(int id)
        {
          int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            var idMedico = _consultaRepository.BuscarIdMedico(idUsuario);

            return Ok(_consultaRepository.ListarConsultasMedico(idMedico));
        }

        [HttpGet("paciente")]
        public IActionResult GetPaciente(int id)
        {
            int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);
            var idPaciente = _consultaRepository.BuscarIdPaciente(idUsuario);

            return Ok(_consultaRepository.ListarConsultasPaciente(idPaciente));
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_consultaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1, 2")]
        [HttpPost]
        public IActionResult Post(Consulta novaConsulta)
        {
            try
            {
                _consultaRepository.Cadastrar(novaConsulta);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "2")]
        [HttpPatch("medico/{id}")]
        public IActionResult PatchDescricao(int id, Consulta Descricao)
        {
            try
            {
                _consultaRepository.MudarDescricao(id, Descricao);
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Situacao status)
        {
            try
            {
                _consultaRepository.AprovarRecusar(id, status.Situacao1);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

     [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      try
      {
        _consultaRepository.Deletar(id);

        return StatusCode(204);
      }
      catch (Exception ex)
      {
        return BadRequest(ex);
      }
    }
    }
}
