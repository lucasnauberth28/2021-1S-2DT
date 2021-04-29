using senai.hroads.webApi.Interfaces;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoHabilidadeRepository : ITipoHabilidadeRepository
    {

        HroadsContext context = new HroadsContext();
        public void Atualizar(int id, TipoHabilidadeDomain TipoHabilidadeAtualizado)
        {
            // busca a classe atráves do seu id
            TipoHabilidadeDomain tipoHabilidadeBuscado = context.TipoHabilidades.Find(id);

            // verifica se a classe tem um nome informado...
            if (TipoHabilidadeAtualizado.nomeTipoHabilidade != null)
            {
                // se tiver, atribui os novos valores aos valores existentes
               tipoHabilidadeBuscado.nomeTipoHabilidade = TipoHabilidadeAtualizado.nomeTipoHabilidade;
            }
            //se não tiver...
            // atualiza a classe que foi buscada e...
            context.TipoHabilidades.Update(tipoHabilidadeBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Cadastrar(TipoHabilidadeDomain novoTipoHabilidade)
        {
            // adiciona essa nova classe
            context.TipoHabilidades.Add(novoTipoHabilidade);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca a classe atráves do seu id
            TipoHabilidadeDomain tipoHabilidadeBuscado = context.TipoHabilidades.Find(id);

            // remove a classe que foi encontrada e colocada dentro do "classeBuscada"
            context.TipoHabilidades.Remove(tipoHabilidadeBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public List<TipoHabilidadeDomain> Listar()
        {
            // retorna uma lista com todas as informações da tabela/entidade classe
            return context.TipoHabilidades.ToList();
        }
    }
}
