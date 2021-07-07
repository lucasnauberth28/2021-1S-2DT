using Microsoft.EntityFrameworkCore;
using SPMG_WebApi.Contexts;
using SPMG_WebApi.Domains;
using SPMG_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        SPMGContext ctx = new SPMGContext();
        public Paciente BuscarPorId(int id)
        {
            return ctx.Pacientes.FirstOrDefault(tu => tu.IdPaciente == id);
        }

        public List<Paciente> Listar()
        {
            return ctx.Pacientes

                .Include(p => p.IdUsuarioNavigation)
                .ToList();
        }
    }
}
