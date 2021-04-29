using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IHabilidadeRepository
    {
        public List<HabilidadeDomain> Listar();
        void Atualizar(int id, HabilidadeDomain HabilidadeAtualizada);
        void Cadastrar(HabilidadeDomain novaHabilidade);
        void Deletar(int id);
    }
}
