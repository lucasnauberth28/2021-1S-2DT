using senai.hroads.webApi.Interfaces;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class PersonagemRepository:IPersonagemRepository
    {
        HroadsContext context = new HroadsContext();

        public void Atualizar(int id, PersonagemDomain personaAtualizado)
        {
            // busca a classe atráves do seu id
            PersonagemDomain personaBuscado = context.Personagens.Find(id);

            // verifica se a classe tem um nome informado...
            if (personaAtualizado.nomePersonagem != null)
            {
                // se tiver, atribui os novos valores aos valores existentes
                personaBuscado.nomePersonagem = personaAtualizado.nomePersonagem;
            }
            //se não tiver...
            // atualiza a classe que foi buscada e...
            context.Personagens.Update(personaBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Cadastrar(PersonagemDomain novoPersona)
        {
            // adiciona essa nova classe
            context.Personagens.Add(novoPersona);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca a classe atráves do seu id
            PersonagemDomain personaBuscado = context.Personagens.Find(id);

            // remove a classe que foi encontrada e colocada dentro do "classeBuscada"
            context.Personagens.Remove(personaBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public List<PersonagemDomain> Listar()
        {
            // retorna uma lista com todas as informações da tabela/entidade classe
            return context.Personagens.ToList();
        }
    }
}
