using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi_SPMedical.Domains;
using WebApi_SPMedical.Interfaces;
using WebApi_SPMedical.Contexts;

namespace WebApi_SPMedical.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        public void Atualizar(int id, Consultum ConsultumAtualizado)
        {
            
        }

        public Consultum BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Consultum novoConsultum)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Consultum> Listar()
        {
            throw new NotImplementedException();
        }

        public List<Consultum> MinhasC(int idUsuario)
        {
            throw new NotImplementedException();
        }

        public void Prontuario(int id, Consultum novoProntuario)
        {
            throw new NotImplementedException();
        }

        public void StatusAlterar(int id, string ConsultumPermissao)
        {
            throw new NotImplementedException();
        }
    }
}
