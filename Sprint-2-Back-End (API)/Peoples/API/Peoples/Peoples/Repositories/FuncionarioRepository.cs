using Peoples.Domains;
using Peoples.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Peoples.Repositories
{
    public class FuncionarioRepository : IFuncionarioRepository
    {
        public void Atualizar(int id, FuncionarioDomain funcionario)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                // declara a query a ser executada
                string queryUpdateIdUrl = "UPDATE funcionarios SET nome = @nome, sobrenome = @sobrenome, dataNascimento = @dataNascimento WHERE idFuncionario = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateIdUrl, conexao))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@nome", funcionario.nome);
                    command.Parameters.AddWithValue("@sobrenome", funcionario.sobrenome);
                    command.Parameters.AddWithValue("@dataNascimento", funcionario.dataNascimento);

                    conexao.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public FuncionarioDomain BuscarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                string querySearchById = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios WHERE funcionarios.idFuncionario = @id";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchById, conexao))
                {
                    // passa o valor para o parâmetro @id
                    command.Parameters.AddWithValue("@id", id);

                    // executa a query e armazena os dados na "reader"
                    reader = command.ExecuteReader();

                    // verifica se o resultado da query retornou algum registro
                    if (reader.Read())
                    {
                        // se sim, será instanciado um novo objeto "funcionarioBuscado" do tipo FuncionarioDomain
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados, assim, a ordem não vai mais importar
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            // atribui a propriedade "nome" o valor da coluna "Nome" da tabela do banco de dados
                            nome = reader["nome"].ToString(),

                            // atribui a propriedade "sobrenome" o valor da coluna "sobrenome" da tabela do banco de dados
                            sobrenome = reader["sobrenome"].ToString(),

                            // atribui a propriedade "dataNascimento" o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };

                        // retorna os "funcionarioBuscado" com os dados obtidos
                        return funcionarioBuscado;
                    }
                    // se não, retorna null
                    else
                        return null;
                }
            }
        }

        public FuncionarioDomain BuscarPorNome(string nome)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                string querySearchByName = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios WHERE funcionarios.nome = @nome";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySearchByName, conexao))
                {
                    command.Parameters.AddWithValue("@nome", nome);

                    reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        FuncionarioDomain funcionarioBuscado = new FuncionarioDomain
                        {
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            nome = reader["nome"].ToString(),

                            sobrenome = reader["sobrenome"].ToString(),

                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };
                        return funcionarioBuscado;
                    }
                    else
                        return null;
                }
            }
        }

        public void Cadastrar(FuncionarioDomain novoFuncionario)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                string queryInsert = "INSERT INTO funcionarios(nome, sobrenome, dataNascimento) VALUES (@nome, @sobrenome, @dataNascimento)";

                using (SqlCommand command = new SqlCommand(queryInsert, conexao))
                {
                    // passa o valor de novoFuncionario para os parâmetros(@)
                    command.Parameters.AddWithValue("@nome", novoFuncionario.nome);
                    command.Parameters.AddWithValue("@sobrenome", novoFuncionario.sobrenome);
                    command.Parameters.AddWithValue("@dataNascimento", novoFuncionario.dataNascimento);

                    // abre a conexão com o banco de dados
                    conexao.Open();

                    // executa a query
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                // declara a query a ser executada passando o parâmetro @id
                string queryDelete = "DELETE funcionarios WHERE funcionarios.idFuncionario = @id";

                // declara o SqlCommand "command" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(queryDelete, conexao))
                {
                    // define o valor id recebido no método como valor do parâmetro @id || usamos esse parâmetro para não cairmos no "efeito Joana D'Arc"
                    command.Parameters.AddWithValue("@id", id);

                    // abre a conexão com o banco de dados
                    conexao.Open();

                    // executa o comando
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<FuncionarioDomain> Listar()
        {
            List<FuncionarioDomain> listaFuncionarios = new List<FuncionarioDomain>();

            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                string querySelectAll = "SELECT idFuncionario, nome, sobrenome, dataNascimento FROM funcionarios";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, conexao))
                {
                    // executa a query e armazena os dados no "reader"
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        // instancia um objeto "funcionario" do tipo FuncionarioDomain
                        FuncionarioDomain funcionario = new FuncionarioDomain()
                        {
                            // atribui a propriedade "idFuncionario" o valor da coluna "idFuncionario" da tabela do banco de dados
                            idFuncionario = Convert.ToInt32(reader["idFuncionario"]),

                            // atribui a propriedade "nome" o valor da coluna "nome" da tabela do banco de dados
                            nome = reader["nome"].ToString(),

                            // atribui a propriedade "sobrenome" o valor da coluna "sobrenome" da tabela do banco de dados
                            sobrenome = reader["sobrenome"].ToString(),

                            // atribui a propriedade "dataNascimento" o valor da coluna "dataNascimento" da tabela do banco de dados
                            dataNascimento = Convert.ToDateTime(reader["dataNascimento"])
                        };

                        // adiciona o objeto "funcionario" criado à lista listaFuncionarios
                        listaFuncionarios.Add(funcionario);
                    }

                    // retorna a lista de funcionarios
                    return listaFuncionarios;
                }
            }
        }

    }
}
