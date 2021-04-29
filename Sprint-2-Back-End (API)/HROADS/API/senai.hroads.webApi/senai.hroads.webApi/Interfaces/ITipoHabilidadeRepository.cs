using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface ITipoHabilidadeRepository
    {
        public List<TipoHabilidadeDomain> Listar();
        void Atualizar(int id, TipoHabilidadeDomain TipoHabilidadeAtualizado);
        void Cadastrar(TipoHabilidadeDomain novoTipoHabilidade);
        void Deletar(int id);
    }
}
