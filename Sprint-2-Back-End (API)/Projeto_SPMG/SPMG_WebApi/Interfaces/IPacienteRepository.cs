using SPMG_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> Listar();
        Paciente BuscarPorId(int id);
    }
}
