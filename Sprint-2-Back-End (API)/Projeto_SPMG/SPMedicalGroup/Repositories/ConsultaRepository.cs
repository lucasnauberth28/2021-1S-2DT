using Microsoft.EntityFrameworkCore;
using SPMedicalGroup.Contexts;
using SPMedicalGroup.Domains;
using SPMedicalGroup.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SPMedicalGroup.Repositories
{
    public class ConsultaRepository : IConsulta
    {
        MedicalContext ctx = new MedicalContext();

        public void AprovarRecusar(int id, string status)
        {
            Consulta consultaBuscada = ctx.Consulta
                                    .FirstOrDefault(p => p.IdConsulta == id);

            switch (status)
            {
                case "1":
                    consultaBuscada.IdSituacao = 1;
                    break;

                case "2":
                    consultaBuscada.IdSituacao = 2;
                    break;

                case "3":
                    consultaBuscada.IdSituacao = 3;
                    break;

                default:
                    consultaBuscada.IdSituacao = consultaBuscada.IdSituacao;
                    break;
            }

            ctx.Consulta.Update(consultaBuscada);

            ctx.SaveChanges();
        }

        public void AtualizarPorId(int id, Consulta consultaAtualiza)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if (consultaAtualiza.IdMedico != null)
            {
                consultaBuscada.IdMedico = consultaAtualiza.IdMedico;
            }
            if (consultaAtualiza.IdPaciente != null)
            {
                consultaBuscada.IdPaciente = consultaAtualiza.IdPaciente;
            }
            if (consultaAtualiza.IdSituacao != null)
            {
                consultaBuscada.IdSituacao = consultaAtualiza.IdSituacao;
            }
            if (consultaAtualiza.Descricao != null)
            {
                consultaBuscada.Descricao = consultaAtualiza.Descricao;
            }

            ctx.Update(consultaBuscada);

            ctx.SaveChanges();
        }
        public int BuscarIdMedico(int id)
        {
            var medico = ctx.Medicos.FirstOrDefault(c => c.IdUsuario == id);

            return medico.IdMedico;
        }

        public int BuscarIdPaciente(int id)
        {
            var paciente = ctx.Pacientes.FirstOrDefault(c => c.IdUsuario == id);

            return paciente.IdPaciente;
        }

        public Consulta BuscarPorId(int id)
        {
            return ctx.Consulta.FirstOrDefault(u => u.IdConsulta == id);
        }

        public void Cadastrar(Consulta novaConsulta)
        {

            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Consulta consultaBuscada = ctx.Consulta.FirstOrDefault(u => u.IdConsulta == id);

            ctx.Consulta.Remove(consultaBuscada);

            ctx.SaveChanges();
        }

        public List<Consulta> ListarConsultasMedico(int id)
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation)
                      .Include(c => c.IdPacienteNavigation)
                      .Include(c => c.IdSituacaoNavigation)
                      .Where(c => c.IdMedico == id)

                      .Select(c => new Consulta()
                      {
                          IdConsulta = c.IdConsulta,
                          Descricao = c.Descricao,
                          DataConsulta = c.DataConsulta,

                          IdMedicoNavigation = new Medico()
                          {
                              IdMedico = c.IdMedicoNavigation.IdMedico,
                              NomeMedico = c.IdMedicoNavigation.NomeMedico,
                              IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                              IdClinica = c.IdMedicoNavigation.IdClinica,


                              IdEspecialidadeNavigation = new Especialidade()
                              {
                                  IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                  NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                              }

                          },

                          IdPacienteNavigation = new Paciente()
                          {
                              IdPaciente = c.IdPacienteNavigation.IdPaciente,
                              NomePaciente = c.IdPacienteNavigation.NomePaciente,
                              DataNascimento = c.IdPacienteNavigation.DataNascimento,
                              Rg = c.IdPacienteNavigation.Rg,
                              Cpf = c.IdPacienteNavigation.Cpf,
                              Endereco = c.IdPacienteNavigation.Endereco
                          },

                          IdSituacaoNavigation = new Situacao()
                          {
                              IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                              Situacao1 = c.IdSituacaoNavigation.Situacao1
                          }

                      }).ToList();
        }

        public List<Consulta> ListarConsultasPaciente(int id)
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation)
                       .Include(c => c.IdPacienteNavigation)
                       .Include(c => c.IdSituacaoNavigation)
                       .Where(c => c.IdPaciente == id)

                       .Select(c => new Consulta()
                       {
                           IdConsulta = c.IdConsulta,
                           Descricao = c.Descricao,
                           DataConsulta = c.DataConsulta,

                           IdMedicoNavigation = new Medico()
                           {
                               IdMedico = c.IdMedicoNavigation.IdMedico,
                               NomeMedico = c.IdMedicoNavigation.NomeMedico,
                               IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                               IdClinica = c.IdMedicoNavigation.IdClinica,


                               IdEspecialidadeNavigation = new Especialidade()
                               {
                                   IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                   NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                               }

                           },

                           IdPacienteNavigation = new Paciente()
                           {
                               IdPaciente = c.IdPacienteNavigation.IdPaciente,
                               NomePaciente = c.IdPacienteNavigation.NomePaciente,
                               DataNascimento = c.IdPacienteNavigation.DataNascimento,
                               Rg = c.IdPacienteNavigation.Rg,
                               Cpf = c.IdPacienteNavigation.Cpf,
                               Endereco = c.IdPacienteNavigation.Endereco
                           },

                           IdSituacaoNavigation = new Situacao()
                           {
                               IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                               Situacao1 = c.IdSituacaoNavigation.Situacao1
                           }

                       }).ToList();
        }

        public List<Consulta> ListarTudo()
        {
            return ctx.Consulta.Include(c => c.IdMedicoNavigation)
                          .Include(c => c.IdPacienteNavigation)
                          .Include(c => c.IdSituacaoNavigation)
                          .Select(c => new Consulta()
                          {
                              IdConsulta = c.IdConsulta,
                              Descricao = c.Descricao,
                              DataConsulta = c.DataConsulta,

                              IdMedicoNavigation = new Medico()
                              {
                                  IdMedico = c.IdMedicoNavigation.IdMedico,
                                  NomeMedico = c.IdMedicoNavigation.NomeMedico,
                                  IdEspecialidade = c.IdMedicoNavigation.IdEspecialidade,
                                  IdClinica = c.IdMedicoNavigation.IdClinica,


                                  IdEspecialidadeNavigation = new Especialidade()
                                  {
                                      IdEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.IdEspecialidade,
                                      NomeEspecialidade = c.IdMedicoNavigation.IdEspecialidadeNavigation.NomeEspecialidade
                                  }

                              },

                              IdPacienteNavigation = new Paciente()
                              {
                                  IdPaciente = c.IdPacienteNavigation.IdPaciente,
                                  NomePaciente = c.IdPacienteNavigation.NomePaciente,
                                  DataNascimento = c.IdPacienteNavigation.DataNascimento,
                                  Rg = c.IdPacienteNavigation.Rg,
                                  Cpf = c.IdPacienteNavigation.Cpf,
                                  Endereco = c.IdPacienteNavigation.Endereco
                              },

                              IdSituacaoNavigation = new Situacao()
                              {
                                  IdSituacao = c.IdSituacaoNavigation.IdSituacao,
                                  Situacao1 = c.IdSituacaoNavigation.Situacao1
                              }

                          }).ToList();
        }

        public void MudarDescricao(int id, Consulta status)
        {
            Consulta consultaBuscada = ctx.Consulta.Find(id);

            if (status.Descricao != null)
            {
                consultaBuscada.Descricao = status.Descricao;
            }

            ctx.Update(consultaBuscada);

            ctx.SaveChanges();
        }
    }
}  
