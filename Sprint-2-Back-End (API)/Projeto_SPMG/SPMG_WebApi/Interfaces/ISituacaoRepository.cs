using SPMG_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Interfaces
{
    interface ISituacaoRepository
    {
        List<Situacao> Listar();
        Situacao BuscarPorId(int id);
    }
}
