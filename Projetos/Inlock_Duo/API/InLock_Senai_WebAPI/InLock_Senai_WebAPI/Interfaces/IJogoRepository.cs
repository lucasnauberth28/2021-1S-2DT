using InLock_Senai_WebAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Interfaces
{
    interface IJogoRepository
    {
        List<JogosDomain> Listar();
        JogosDomain BuscarPorId(int id);
        void Atualizar(int id, JogosDomain jogosAtualizados);
        void Cadastrar(JogosDomain novoJogo);
        void Deletar(int id);
    }
}
