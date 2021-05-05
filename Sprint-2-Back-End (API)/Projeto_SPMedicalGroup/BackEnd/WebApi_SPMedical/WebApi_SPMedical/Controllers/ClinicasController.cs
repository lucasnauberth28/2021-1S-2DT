using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public IActionResult GetById()
        {
            try
            {
                return Ok(_clinicaRepository.BuscarPorId(id));
            }
            catch (Exception)
            {

                throw;
            }
        }
    } 
}
