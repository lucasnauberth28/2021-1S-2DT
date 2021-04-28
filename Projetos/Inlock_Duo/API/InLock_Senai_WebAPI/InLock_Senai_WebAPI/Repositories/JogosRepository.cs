using InLock_Senai_WebAPI.Domains;
using InLock_Senai_WebAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace InLock_Senai_WebAPI.Repositories
{
    public class JogosRepository : IJogoRepository
    {
        private string conexao = "Data Source=LAB-A10\\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=senai@132";
        public void Atualizar(int id, JogosDomain jogosAtualizados)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryUpdateId = "UPDATE  jogos SET idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio = @idJogo, @nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio WHERE idJogo = @ID";

                using (SqlCommand cmd = new SqlCommand(queryUpdateId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@nomeJogo", jogosAtualizados.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogosAtualizados.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogosAtualizados.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogosAtualizados.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogosAtualizados.idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogosDomain BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(JogosDomain novoJogo)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryInsert = "INSERT INTO jogos(idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio) VALUES (@idJogo, @nomeJogo, @descricao, @dataLancamento, @valor, @idEstudio)";

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", novoJogo.idJogo);
                    cmd.Parameters.AddWithValue("@nomeJogo", novoJogo.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", novoJogo.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", novoJogo.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", novoJogo.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", novoJogo.idEstudio);


                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string queryDelete = "DELETE FROM idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();

                };
            }
        }

        public List<JogosDomain> Listar()
        {
            List<JogosDomain> ListaJogos = new List<JogosDomain>();
            using (SqlConnection con = new SqlConnection(conexao))
            {
                string querySelectAll = "SELECT idJogo, nomeJogo, descricao, dataLancamento, valor, idEstudio FROM jogos";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {

                        JogosDomain Jogo = new JogosDomain()
                        {
                            idJogo = Convert.ToInt32(rdr[0]),
                            nomeJogo = rdr[1].ToString(),
                            descricao = rdr[2].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr[3]),
                            valor = Convert.ToDecimal(rdr[4]),
                            idEstudio = Convert.ToInt32(rdr[5])

                        };

                        ListaJogos.Add(Jogo);
                    }

                };

            };

            return ListaJogos;
        }
    }
}
