using senai.hroads.webApi.Interfaces;
using senai.hroads.webAPI.Contexts;
using senai.hroads.webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Repositories
{
    public class ClasseRepository : IClasseRepository
    {
        HroadsContext context = new HroadsContext();
        public void Atualizar(int id, ClasseDomain classeAtualizada)
        {
            // busca a classe atráves do seu id
            ClasseDomain classeBuscada = context.Classes.Find(id);

            // verifica se a classe tem um nome informado...
            if (classeAtualizada.nomeClasse != null)
            {
                // se tiver, atribui os novos valores aos valores existentes
                classeBuscada.nomeClasse = classeAtualizada.nomeClasse;
            }
            //se não tiver...
            // atualiza a classe que foi buscada e...
            context.Classes.Update(classeBuscada);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public ClasseDomain BuscarPorId(int id)
        {
            // retorna a primeira classe encontrada para o id informado
            return context.Classes.FirstOrDefault(objClasse => objClasse.idClasse == id);
        }

        public void Cadastrar(ClasseDomain novaClasse)
        {
            // adiciona essa nova classe
            context.Classes.Add(novaClasse);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public void Deletar(int id)
        {
            // busca a classe atráves do seu id
            ClasseDomain classeBuscada = context.Classes.Find(id);

            // remove a classe que foi encontrada e colocada dentro do "classeBuscada"
            context.Classes.Remove(classeBuscada);

            // salva as informações para que sejam gravadas no BD
            context.SaveChanges();
        }

        public List<ClasseDomain> Listar()
        {
            // retorna uma lista com todas as informações da tabela/entidade classe
            return context.Classes.ToList();
        }
    }
}
