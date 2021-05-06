﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;
using WebApi_SPMedical.Interfaces;
using WebApi_SPMedical.Repositories;

namespace WebApi_SPMedical.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicasController : ControllerBase
    {
        private IClinicaRepository _clinicaRepository { get; set; }

        public ClinicasController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {

            try
            {
                return Ok(_clinicaRepository.Listar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex);

            }
        }

        [HttpPost]
        public IActionResult Post(Clinica novaClinica)
        {
            try
            {
                // Faz a chamada para o método
                _clinicaRepository.Cadastrar(novaClinica);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Clinica clinicaAtualizada)
        {
            try
            {
                // Faz a chamada para o método
                _clinicaRepository.Atualizar(id, clinicaAtualizada);

                // Retorna um status code
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
                _clinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


    } 
}
