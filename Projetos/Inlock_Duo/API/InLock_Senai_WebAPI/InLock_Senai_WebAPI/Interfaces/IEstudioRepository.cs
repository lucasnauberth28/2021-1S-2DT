using InLock_Senai_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Interfaces
{
    interface IEstudioRepository
    {
        List<EstudioDomain> Listar();

        EstudioDomain BuscarPorId(int id);
    }
}
