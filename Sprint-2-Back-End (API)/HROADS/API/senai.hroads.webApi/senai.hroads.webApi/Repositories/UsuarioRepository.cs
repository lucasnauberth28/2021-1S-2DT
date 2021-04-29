using senai.hroads.webApi.Interfaces;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class UsuarioRepository:IUsuarioRepository
    {
        HroadsContext context = new HroadsContext();

        public void Atualizar(int id, UsuarioDomain UsuarioAtualizado)
        {
            // busca a classe atráves do seu id
            UsuarioDomain UsuarioBuscado = context.Usuarios.Find(id);

            // verifica se a classe tem um nome informado...
            if (UsuarioAtualizado.email != null)
            {
                // se tiver, atribui os novos valores aos valores existentes
               UsuarioBuscado.email = UsuarioAtualizado.email;
            }
            //se não tiver...
            // atualiza a classe que foi buscada e...
            context.Usuarios.Update(UsuarioBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            return context.Usuarios.FirstOrDefault(x => x.idUsuario == id);
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {

            // adiciona essa nova classe
            context.Usuarios.Add(novoUsuario);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca a classe atráves do seu id
            UsuarioDomain UsuarioBuscado = context.Usuarios.Find(id);

            // remove a classe que foi encontrada e colocada dentro do "classeBuscada"
            context.Usuarios.Remove(UsuarioBuscado);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public List<UsuarioDomain> Listar()
        {
            // retorna uma lista com todas as informações da tabela/entidade classe
            return context.Usuarios.ToList();
        }
    }
}
