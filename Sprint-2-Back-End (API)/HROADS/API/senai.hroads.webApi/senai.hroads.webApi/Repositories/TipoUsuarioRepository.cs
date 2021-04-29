using senai.hroads.webApi.Interfaces;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        HroadsContext context = new HroadsContext();

        public void Atualizar(int id, TipoUsuarioDomain TipoUsuarioAtualizado)
        {
            // busca a classe atráves do seu id
            TipoUsuarioDomain tipoUsuarioBuscado = context.TipoUsuarios.Find(id);

            // verifica se a classe tem um nome informado...
            if (TipoUsuarioAtualizado.permissao != null)
            {
                // se tiver, atribui os novos valores aos valores existentes
                tipoUsuarioBuscado.permissao = TipoUsuarioAtualizado.permissao;
            }
            //se não tiver...
            // atualiza a classe que foi buscada e...
            context.TipoUsuarios.Update(tipoUsuarioBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Cadastrar(TipoUsuarioDomain novoTipoUsuario)
        {
            // adiciona essa nova classe
            context.TipoUsuarios.Add(novoTipoUsuario);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca a classe atráves do seu id
            TipoUsuarioDomain tipoUsuarioBuscado = context.TipoUsuarios.Find(id);

            // remove a classe que foi encontrada e colocada dentro do "classeBuscada"
            context.TipoUsuarios.Remove(tipoUsuarioBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public List<TipoUsuarioDomain> Listar()
        {
            // retorna uma lista com todas as informações da tabela/entidade classe
            return context.TipoUsuarios.ToList();
        }
    }
}
