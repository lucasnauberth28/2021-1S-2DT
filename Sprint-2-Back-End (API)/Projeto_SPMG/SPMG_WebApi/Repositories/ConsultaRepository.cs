using Microsoft.EntityFrameworkCore;
using SPMG_WebApi.Contexts;
using SPMG_WebApi.Domains;
using SPMG_WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMG_WebApi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        SPMGContext ctx = new SPMGContext();
        public void AlterStatus(int id, string ConsultumPermissao)
        {
            Consulta ConsultumBuscado =ctx.Consulta

              .Include(p => p.IdMedicoNavigation)

              .Include(p => p.IdPacienteNavigation)

              .Include(p => p.IdSituacaoNavigation)

              .FirstOrDefault(p => p.IdConsulta == id);

            switch (ConsultumPermissao)
            {
                case "1":
                    ConsultumBuscado.IdSituacao = 1;
                    break;

                case "2":
                    ConsultumBuscado.IdSituacao = 2;
                    break;

                case "3":
                    ConsultumBuscado.IdSituacao = 3;
                    break;

                default:
                    ConsultumBuscado.IdSituacao = ConsultumBuscado.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public void Atualizar(int id, Consulta ConsultumAtualizado)
        {
            Consulta ConsultumBuscado = ctx.Consulta.Find(id);

            if (ConsultumAtualizado.IdMedico != null)
            {
                ConsultumBuscado.IdMedico = ConsultumAtualizado.IdMedico;
            }

            if (ConsultumAtualizado.IdPaciente != null)
            {
                ConsultumBuscado.IdPaciente = ConsultumAtualizado.IdPaciente;
            }

            if (ConsultumAtualizado.IdSituacao != null)
            {
                ConsultumBuscado.IdSituacao = ConsultumAtualizado.IdSituacao;
            }

            if (ConsultumAtualizado.DataConsulta > DateTime.Now)
            {
                ConsultumBuscado.DataConsulta = ConsultumAtualizado.DataConsulta;
            }

            if (ConsultumAtualizado.HoraConsulta != null)
            {
                ConsultumBuscado.HoraConsulta = ConsultumAtualizado.HoraConsulta;
            }

            if (ConsultumAtualizado.Descricao != null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            if (ConsultumAtualizado.Descricao == null)
            {
                ConsultumBuscado.Descricao = ConsultumBuscado.Descricao;
            }

            ctx.Consulta.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(tu => tu.IdConsulta == id);
        }

        public void Cadastrar(Consulta novoConsultum)
        {
            ctx.Consulta.Add(novoConsultum);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta ConsultumBuscado = ctx.Consulta.Find(id);

            ctx.Consulta.Remove(ConsultumBuscado);

            ctx.SaveChanges();
        }

        public List<Consulta> Listar()
        {
            return ctx.Consulta

               .Include(p => p.IdMedicoNavigation)

               .Include(p => p.IdPacienteNavigation)

               .Include(p => p.IdSituacaoNavigation)

               .Include(p => p.IdMedicoNavigation.IdUsuarioNavigation)

               .Include(p => p.IdPacienteNavigation.IdUsuarioNavigation)

               .Include(p => p.IdMedicoNavigation.IdEspecialidadeNavigation)

               .ToList();
        }

        public List<Consulta> Minhas(int idUsuario)
        {
           return ctx.Consulta

                .Include(p => p.IdMedicoNavigation)

                .Include(p => p.IdPacienteNavigation)

                .Include(p => p.IdSituacaoNavigation)

                .Where(p => p.IdConsulta == idUsuario)

                .ToList();
        }

        public void Prontuario(int id, Consulta novoProntuario)
        {
            Consulta ConsultumBuscado = ctx.Consulta.Find(id);

            if (novoProntuario.Descricao != null)
            {
                ConsultumBuscado.Descricao = novoProntuario.Descricao;
            }

            ctx.Consulta.Update(ConsultumBuscado);

            ctx.SaveChanges();
        }
    }
}
