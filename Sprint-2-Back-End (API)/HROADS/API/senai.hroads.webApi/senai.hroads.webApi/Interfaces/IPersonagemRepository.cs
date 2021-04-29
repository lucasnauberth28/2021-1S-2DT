using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Interfaces
{
    interface IPersonagemRepository
    {
        public List<PersonagemDomain> Listar();
        void Atualizar(int id, PersonagemDomain personaAtualizado);
        void Cadastrar(PersonagemDomain novoPersona);
        void Deletar(int id);
    }
}
