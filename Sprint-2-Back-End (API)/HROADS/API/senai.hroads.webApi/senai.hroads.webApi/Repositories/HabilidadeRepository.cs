using senai.hroads.webApi.Interfaces;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class HabilidadeRepository : IHabilidadeRepository
    {
        HroadsContext context = new HroadsContext();
        public void Atualizar(int id, HabilidadeDomain HabilidadeAtualizada)
        {
            // busca a classe atráves do seu id
            HabilidadeDomain habilidadeBuscada = context.Habilidades.Find(id);

            // verifica se a classe tem um nome informado...
            if (HabilidadeAtualizada.nomeHabilidade != null)
            {
                // se tiver, atribui os novos valores aos valores existentes
                habilidadeBuscada.nomeHabilidade = HabilidadeAtualizada.nomeHabilidade;
            }
            //se não tiver...
            // atualiza a classe que foi buscada e...
            context.Habilidades.Update(habilidadeBuscada);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Cadastrar(HabilidadeDomain novaHabilidade)
        {
            // adiciona essa nova classe
            context.Habilidades.Add(novaHabilidade);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca a classe atráves do seu id
            HabilidadeDomain habilidadeBuscada = context.Habilidades.Find(id);

            // remove a classe que foi encontrada e colocada dentro do "classeBuscada"
            context.Habilidades.Remove(habilidadeBuscada);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public List<HabilidadeDomain> Listar()
        {
            // retorna uma lista com todas as informações da tabela/entidade classe
            return context.Habilidades.ToList();
        }
    }
}
