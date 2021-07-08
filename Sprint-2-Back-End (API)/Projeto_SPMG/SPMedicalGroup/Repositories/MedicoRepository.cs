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
    public class MedicoRepository : IMedico
    {
        MedicalContext ctx = new MedicalContext();
        public void Atualizar(int id, Medico MedicoAtualizado)
        {
            Medico medicoBuscado = ctx.Medicos.Find(id);

            if (MedicoAtualizado.NomeMedico != null)
            {
                medicoBuscado.NomeMedico = MedicoAtualizado.NomeMedico;
            }
            if (MedicoAtualizado.Crm != null)
            {
                medicoBuscado.Crm = MedicoAtualizado.Crm;
            }

            ctx.Update(medicoBuscado);

            ctx.SaveChanges();
        }

        public Medico BuscaId(int id)
        {
            return ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);
        }

        public void Cadastrar(Medico newMedico)
        {
            ctx.Medicos.Add(newMedico);

            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            Medico medicoBuscado = ctx.Medicos.FirstOrDefault(m => m.IdMedico == id);

            ctx.Medicos.Remove(medicoBuscado);

            ctx.SaveChanges();
        }

        public List<Medico> Listar()
        {
            return ctx.Medicos.ToList();
        }

        public List<Medico> ListarConsultas(int id)
        {
            var medicoBuscado = ctx.Medicos.Include(p => p.IdUsuarioNavigation)
            .Where(p => p.IdUsuario == id)
            .Select(p => new Medico()

            {
                IdMedico = p.IdMedico,
                NomeMedico = p.NomeMedico,
                IdUsuarioNavigation = new Usuario()
                {
                    IdUsuario = p.IdUsuarioNavigation.IdUsuario,
                    Email = p.IdUsuarioNavigation.Email
                },

                IdEspecialidadeNavigation = new Especialidade()
                {
                    IdEspecialidade = p.IdEspecialidadeNavigation.IdEspecialidade,
                    NomeEspecialidade = p.IdEspecialidadeNavigation.NomeEspecialidade
                },

                IdClinicaNavigation = new Clinica()
                {
                    IdClinica = p.IdClinicaNavigation.IdClinica,
                    HorarioAbertura = p.IdClinicaNavigation.HorarioAbertura,
                    HorarioFechamento = p.IdClinicaNavigation.HorarioFechamento,
                    Endereco = p.IdClinicaNavigation.Endereco,
                    NomeFantasia = p.IdClinicaNavigation.NomeFantasia,
                    RazaoSocial = p.IdClinicaNavigation.RazaoSocial
                }
            });
            return medicoBuscado.ToList();
        }
    }
}
