using Senai_Filmes_WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai_Filmes_WebApi.Interfaces
{
    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        //TipoRetorno NomeMetodo(TipoParametro NomeParametro);
        /// <summary>
        /// Lista todos os Generos
        /// </summary>
        /// <returns>Uma lista os Generos</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um genero pelo id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Um objeto genero que foi buscado</returns>
        GeneroDomain BuscarPorId(int id);

        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto novo genero com as informacoes</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um genero existente passando o id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto genero com as novas informacoes</param>
        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza um genero existente passando o id pela url da requisicao
        /// </summary>
        /// <param name="id">id do genero atualizado</param>
        /// <param name="genero">Objeto genero com as informacoes atualizadas</param>
        void AtualizarIdUrl(int id, GeneroDomain genero);

        /// <summary>
        /// Deleta um genero existente
        /// </summary>
        /// <param name="id">id do genero que sera deletado</param>
        void Deletar(int id);
    }
}
