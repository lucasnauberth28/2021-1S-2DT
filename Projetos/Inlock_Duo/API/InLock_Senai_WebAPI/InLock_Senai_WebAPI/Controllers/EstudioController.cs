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
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<EstudioDomain> ListaJogos = _estudioRepository.Listar();

            return Ok(ListaJogos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorId(id);


            if (estudioBuscado == null)
            {

                return NotFound("Nenhum estudio encontrado!");
            }

            return Ok(estudioBuscado);
        }
    }
}

    
