using SPMedicalGroup.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Interfaces
{
    interface IConsulta
    {
        int BuscarIdPaciente(int id);

        int BuscarIdMedico(int id);

        Consulta BuscarPorId(int id);

        void MudarDescricao(int id, Consulta status);

        void AprovarRecusar(int id, string status);

        void Cadastrar(Consulta novaConsulta);

        void AtualizarPorId(int id, Consulta consultaAtualiza);

        void Deletar(int id);

        List<Consulta> ListarTudo();

        List<Consulta> ListarConsultasPaciente(int id);

        List<Consulta> ListarConsultasMedico(int id);
    }
}
