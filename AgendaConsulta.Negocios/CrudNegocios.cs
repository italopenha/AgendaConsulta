using AgendaConsulta.Dados;
using AgendaConsulta.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Negocios
{
    public class CrudNegocios
    {
        private readonly CrudDados objDados = new CrudDados();

        #region Paciente

        public void InserirPaciente(Paciente paciente)
        {
            try
            {
                objDados.InserirPaciente(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Paciente> ListarPacientes()
        {
            try
            {
                return objDados.ListarPacientes();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void AtualizarPaciente(Paciente paciente)
        {
            try
            {
                objDados.AtualizarPaciente(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void ExcluirPaciente(Paciente paciente)
        {
            try
            {
                objDados.ExcluirPaciente(paciente);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void ExcluirPacientesEmLote(List<Paciente> pacientes)
        {
            try
            {
                objDados.ExcluirPacientesEmLote(pacientes);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Paciente> ConsultarPacientesPorNome(string nome)
        {
            try
            {
                return objDados.ConsultarPacientesPorNome(nome);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion

        #region Medico

        public void InserirMedico(Medico medico)
        {
            try
            {
                objDados.InserirMedico(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Medico> ListarMedicos()
        {
            try
            {
                return objDados.ListarMedicos();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void AtualizarMedico(Medico medico)
        {
            try
            {
                objDados.AtualizarMedico(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void ExcluirMedico(Medico medico)
        {
            try
            {
                objDados.ExcluirMedico(medico);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void ExcluirMedicosEmLote(List<Medico> medicos)
        {
            try
            {
                objDados.ExcluirMedicosEmLote(medicos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion

        #region Consulta

        public void InserirConsulta(Consulta consulta)
        {
            try
            {
                objDados.InserirConsulta(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<Consulta> ListarConsultas()
        {
            try
            {
                return objDados.ListarConsultas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void AtualizarConsulta(Consulta consulta)
        {
            try
            {
                objDados.AtualizarConsulta(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void ExcluirConsulta(Consulta consulta)
        {
            try
            {
                objDados.ExcluirConsulta(consulta);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void ExcluirConsultasEmLote(List<Consulta> consultas)
        {
            try
            {
                objDados.ExcluirConsultasEmLote(consultas);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion
    }
}
