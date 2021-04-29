using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IClasseRepository
    {
        public List<ClasseDomain> Listar();
        ClasseDomain BuscarPorId(int id);
        void Atualizar(int id, ClasseDomain classeAtualizada);
        void Cadastrar(ClasseDomain novaClasse);
        void Deletar(int id);
    }
}
