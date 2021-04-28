using InLock_Senai_WebAPI.Domains;
using InLock_Senai_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        private string conexao = "Data Source=LAB-A10\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd:senai@132";
        public TipoUsuarioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectById = "SELECT idTipoUsuario FROM tiposUsuarios WHERE idTipoUsuario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        TipoUsuarioDomain usuarioBuscar = new TipoUsuarioDomain
                        {
                               idtiposUsuarios = Convert.ToInt32(rdr["idTiposUsuarios"]),
                               
                        };
                        return usuarioBuscar;
                    }
                    return null;
                }
            }

        }

        public List<TipoUsuarioDomain> Listar()
        {
            List<TipoUsuarioDomain> ListaTiposUsuarios = new List<TipoUsuarioDomain>();
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectAll = "SELECT idTipoUsuario, titulo FROM tiposUsuarios";


                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        TipoUsuarioDomain TipoUsuario = new TipoUsuarioDomain()
                        {
                            idtiposUsuarios = Convert.ToInt32(rdr[0]),
                            titulo = rdr[1].ToString(),
                        };

                        ListaTiposUsuarios.Add(TipoUsuario);
                    }

                };

            };

            return ListaTiposUsuarios;
        }
    }
}

