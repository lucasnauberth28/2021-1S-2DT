using Peoples.Domains;
using Peoples.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Peoples.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string conexao = "Data Source=LAB-A10\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=senai@132";
        public void Atualizar(int id, UsuarioDomain usuario)
        {

            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                // declara a query a ser executada
                string queryUpdateId = "UPDATE usuarios SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @id";

                using (SqlCommand command = new SqlCommand(queryUpdateId, conexao))
                {
                    // passa os valores para os parâmetros
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@email", usuario.email);
                    command.Parameters.AddWithValue("@senha", usuario.senha);
                    command.Parameters.AddWithValue("@idTipoUsuario", usuario.idTipoUsuario);

                    conexao.Open();

                    command.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                string querySearchById = "SELECT usuarios.idUsuario, usuarios.email, usuarios.senha, usuarios.idTipoUsuario, tipoUsuarios.permissao FROM usuarios INNER JOIN tipoUsuarios ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario WHERE usuarios.idUsuario = @id";

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
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            email = reader["email"].ToString(),

                            senha = reader["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                                permissao = reader["permissao"].ToString()
                            }
                        };

                        // retorna os "usuarioBuscado" com os dados obtidos
                        return usuarioBuscado;
                    }

                    // se não, retorna null
                    else
                        return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            // declara a SqlConnection passando a string de conexão
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                // declara a query que será executada
                string queryInsert = "INSERT INTO usuarios(email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario)";

                // Declara o comando passando a query e a conexão
                using (SqlCommand command = new SqlCommand(queryInsert, conexao))
                {
                    // Passa o valor do parâmetro
                    command.Parameters.AddWithValue("@email", novoUsuario.email);
                    command.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    command.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTipoUsuario);

                    // Abre a conexão com o banco de dados
                    conexao.Open();

                    // Executa o comando
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                // declara a query a ser executada passando o parâmetro @id
                string queryDelete = "DELETE usuarios WHERE usuarios.idUsuarios = @id";

                // declara o SqlCommand "command" passando a query que será executada e a conexão como parâmetros
                using (SqlCommand command = new SqlCommand(queryDelete, conexao))
                {
                    command.Parameters.AddWithValue("@id", id);

                    // abre a conexão com o banco de dados
                    conexao.Open();

                    // executa o comando
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                string querySelectAll = "SELECT usuarios.idUsuario, usuarios.email, usuarios.senha, usuarios.idTipoUsuario, tipoUsuarios.permissoes FROM usuarios INNER JOIN tipoUsuarios ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario";

                conexao.Open();

                SqlDataReader reader;

                using (SqlCommand command = new SqlCommand(querySelectAll, conexao))
                {
                    // executa a query e armazena os dados no "reader"
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            email = reader["email"].ToString(),

                            senha = reader["senha"].ToString(),

                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                                permissao = reader["permissao"].ToString()
                            }
                        };

                        listaUsuarios.Add(usuario);
                    }

                    return listaUsuarios;
                }
            }
        }

        public UsuarioDomain Logar(string email, string senha)
        {
            // Define a conexão passando a string
            using (SqlConnection conexao = new SqlConnection("conexao"))
            {
                // Define a query a ser executada no banco
                string queryLogar = "SELECT usuarios.idUsuario, usuarios.email, usuarios.idTipoUsuario, tipoUsuarios.permissao FROM usuarios INNER JOIN tipoUsuarios ON usuarios.idTipoUsuario = tipoUsuarios.idTipoUsuario WHERE email = @email AND senha = @senha";

                // Define o comando passando a query e a conexão
                using (SqlCommand command = new SqlCommand(queryLogar, conexao))
                {
                    // Define o valor dos parâmetros
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@senha", senha);

                    // Abre a conexão com o banco
                    conexao.Open();

                    // Executa o comando e armazena os dados no objeto rdr
                    SqlDataReader reader = command.ExecuteReader();

                    // Caso o resultado da query possua registro
                    if (reader.Read())
                    {
                        // Instancia um objeto usuario 
                        UsuarioDomain usuario = new UsuarioDomain
                        {
                            // Atribui às propriedades os valores das colunas da tabela do banco
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),

                            email = reader["email"].ToString(),

                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                            tipoUsuario = new TipoUsuarioDomain
                            {
                                idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                                permissao = reader["permissao"].ToString()
                            }
                        };

                        // Retorna o usuario buscado
                        return usuario;
                    }
                }

                // Caso não encontre um email e senha correspondente, retorna null
                return null;
            }
        }

    }
}

