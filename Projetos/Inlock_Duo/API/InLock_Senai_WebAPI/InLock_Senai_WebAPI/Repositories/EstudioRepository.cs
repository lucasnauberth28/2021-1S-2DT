using InLock_Senai_WebAPI.Domains;
using InLock_Senai_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        private string conexao = "Data Source=LAB-A10\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";
        public List<EstudioDomain> Listar()
        {
            List<EstudioDomain> ListaEstudio = new List<EstudioDomain>();
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectAll = "SELECT idEstudio, nomeEstudio FROM estudios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        EstudioDomain estudio = new EstudioDomain()
                        {
                            nomeEstudio = rdr[1].ToString(),

                        };

                        ListaEstudio.Add(estudio);
                    }

                };

            };

            return ListaEstudio;
        }

        public EstudioDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectById = "SELECT idEstudio FROM estudios WHERE idEstudio = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        EstudioDomain estudioBuscar = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudios"]),

                        };
                        return estudioBuscar;
                    }
                    return null;
                }
            }

        }
    }
}