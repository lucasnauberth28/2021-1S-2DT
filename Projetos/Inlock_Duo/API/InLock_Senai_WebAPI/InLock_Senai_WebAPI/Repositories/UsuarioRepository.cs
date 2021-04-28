using InLock_Senai_WebAPI.Domains;
using InLock_Senai_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
        
    {
        private string conexao = "Data Source=LAB-A10\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd = senai@132";

        public void Atualizar(int id, UsuarioDomain usuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryUpdateId = "UPDATE usuarios  SET email, senha = @email, @senha WHERE idUsuario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@email", usuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@senha", usuarioAtualizado.senha);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain BuscarEmailSenha(string email, string senha)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectByEmailSenha = "SELECT email, senha FROM usuarios WHERE email, senha = @email, @senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectByEmailSenha, con))
                {
                    cmd.Parameters.AddWithValue("@email", email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBusca = new UsuarioDomain
                        {
                            email = ((string)rdr["email"]),
                            senha = ((string)rdr["senha"])

                        };

                        return usuarioBusca;
                    }

                    return null;
                }
            }
        }

        public UsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectById = "SELECT idUsuario FROM usuarios WHERE idUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBusca = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),

                        };
                        return usuarioBusca;
                    }
                    return null;
                }
            }
        }

        public void Cadastrar(UsuarioDomain novoUsuario)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryInsert = "INSERT INTO usuarios(email, senha, idTipoUsuario) VALUES (@email, @senha, @idTipoUsuario)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@email", novoUsuario.email);
                    cmd.Parameters.AddWithValue("@senha", novoUsuario.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", novoUsuario.idTiposUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }

        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryDelete = "DELETE FROM idUsuario, email, senha, idTipoUsuario FROM usuarios";

                using (SqlCommand cmd  = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();

                };
            }
        }

        /// <summary>
        /// Lista os Usuários 
        /// </summary>
        /// <returns>Lista de usuários</returns>
        public List<UsuarioDomain> Listar()
        {
            List<UsuarioDomain> ListaUsuarios = new List<UsuarioDomain>();
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectAll = "SELECT idUsuario, email, senha, idTipoUsuario FROM usuarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        UsuarioDomain Usuario = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr[0]),
                            email = rdr[1].ToString(),
                            senha = rdr[2].ToString(),
                            idTiposUsuario = Convert.ToInt32(rdr[3])
                        };

                        ListaUsuarios.Add(Usuario);
                    }

                };

            };

            return ListaUsuarios;
        }
    }
}
