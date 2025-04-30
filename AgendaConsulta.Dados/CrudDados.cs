using AgendaConsulta.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Dados
{
    public class CrudDados
    {
        #region Paciente

        public void InserirPaciente(Paciente paciente)
        {
            try
            {
                using (Conexao db = new Conexao())
                {
                    db.GetTable<Paciente>().InsertOnSubmit(paciente);
                    db.SubmitChanges();
                }
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
                using (Conexao db = new Conexao())
                {
                    return db.GetTable<Paciente>().ToList();
                }
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
                using (Conexao db = new Conexao())
                {
                    var pacienteParaAtualizar = (from TB_PACIENTE in db.GetTable<Paciente>()
                                                  where TB_PACIENTE.ID_PACIENTE == paciente.ID_PACIENTE
                                                  select TB_PACIENTE).SingleOrDefault();

                    if (pacienteParaAtualizar != null)
                    {
                        pacienteParaAtualizar.NOME = paciente.NOME;
                        pacienteParaAtualizar.DT_NASCIMENTO = paciente.DT_NASCIMENTO;
                        db.SubmitChanges();
                    }
                }
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
                using (Conexao db = new Conexao())
                {
                    var pacienteParaExcluir = (from TB_PACIENTE in db.GetTable<Paciente>()
                                                where TB_PACIENTE.ID_PACIENTE == paciente.ID_PACIENTE
                                                select TB_PACIENTE).SingleOrDefault();

                    if (pacienteParaExcluir != null)
                    {
                        db.GetTable<Paciente>().DeleteOnSubmit(pacienteParaExcluir);
                        db.SubmitChanges();
                    }
                }
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
                using (Conexao db = new Conexao())
                {
                    foreach (var paciente in pacientes)
                    {
                        var pacienteParaExcluir = (from TB_PACIENTE in db.GetTable<Paciente>()
                                                   where TB_PACIENTE.ID_PACIENTE == paciente.ID_PACIENTE
                                                   select TB_PACIENTE).SingleOrDefault();

                        if (pacienteParaExcluir != null)
                        {
                            db.GetTable<Paciente>().DeleteOnSubmit(pacienteParaExcluir);
                        }
                    }
                    db.SubmitChanges();
                }
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
                using (Conexao db = new Conexao())
                {
                    db.GetTable<Medico>().InsertOnSubmit(medico);
                    db.SubmitChanges();
                }
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
                using (Conexao db = new Conexao())
                {
                    return db.GetTable<Medico>().ToList();
                }
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
                using (Conexao db = new Conexao())
                {
                    var medicoParaAtualizar = (from TB_MEDICO in db.GetTable<Medico>()
                                                 where TB_MEDICO.ID_MEDICO == medico.ID_MEDICO
                                                 select TB_MEDICO).SingleOrDefault();

                    if (medicoParaAtualizar != null)
                    {
                        medicoParaAtualizar.NOME = medico.NOME;
                        medicoParaAtualizar.ESPECIALIDADE = medico.ESPECIALIDADE;
                        db.SubmitChanges();
                    }
                }
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
                using (Conexao db = new Conexao())
                {
                    var medicoParaExcluir = (from TB_MEDICO in db.GetTable<Medico>()
                                               where TB_MEDICO.ID_MEDICO == medico.ID_MEDICO
                                               select TB_MEDICO).SingleOrDefault();

                    if (medicoParaExcluir != null)
                    {
                        db.GetTable<Medico>().DeleteOnSubmit(medicoParaExcluir);
                        db.SubmitChanges();
                    }
                }
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
                using (Conexao db = new Conexao())
                {
                    foreach (var medico in medicos)
                    {
                        var medicoParaExcluir = (from TB_MEDICO in db.GetTable<Medico>()
                                                   where TB_MEDICO.ID_MEDICO == medico.ID_MEDICO
                                                   select TB_MEDICO).SingleOrDefault();

                        if (medicoParaExcluir != null)
                        {
                            db.GetTable<Medico>().DeleteOnSubmit(medicoParaExcluir);
                        }
                    }
                    db.SubmitChanges();
                }
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
                using (Conexao db = new Conexao())
                {
                    db.GetTable<Consulta>().InsertOnSubmit(consulta);
                    db.SubmitChanges();
                }
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
                using (Conexao db = new Conexao())
                {
                    return db.GetTable<Consulta>().ToList();
                }
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
                using (Conexao db = new Conexao())
                {
                    var consultaParaAtualizar = (from TB_CONSULTA in db.GetTable<Consulta>()
                                                 where TB_CONSULTA.ID_CONSULTA == consulta.ID_CONSULTA
                                                 select TB_CONSULTA).SingleOrDefault();

                    if (consultaParaAtualizar != null)
                    {
                        consultaParaAtualizar.HORARIO = consulta.HORARIO;
                        consultaParaAtualizar.ID_PACIENTE = consulta.ID_PACIENTE;
                        consultaParaAtualizar.ID_MEDICO = consulta.ID_MEDICO;
                        db.SubmitChanges();
                    }
                }
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
                using (Conexao db = new Conexao())
                {
                    var consultaParaExcluir = (from TB_CONSULTA in db.GetTable<Consulta>()
                                               where TB_CONSULTA.ID_CONSULTA == consulta.ID_CONSULTA
                                               select TB_CONSULTA).SingleOrDefault();

                    if (consultaParaExcluir != null)
                    {
                        db.GetTable<Consulta>().DeleteOnSubmit(consultaParaExcluir);
                        db.SubmitChanges();
                    }
                }
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
                using (Conexao db = new Conexao())
                {
                    foreach (var consulta in consultas)
                    {
                        var consultaParaExcluir = (from TB_CONSULTA in db.GetTable<Consulta>()
                                                   where TB_CONSULTA.ID_CONSULTA == consulta.ID_CONSULTA
                                                   select TB_CONSULTA).SingleOrDefault();

                        if (consultaParaExcluir != null)
                        {
                            db.GetTable<Consulta>().DeleteOnSubmit(consultaParaExcluir);
                        }
                    }
                    db.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        #endregion
    }
}
