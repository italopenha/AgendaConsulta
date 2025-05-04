using AgendaConsulta.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Dados
{
    public class FrmAgeConsultaDad
    {
        public bool AgendaDisponivel(int idPaciente, int idMedico, DateTime dataHora)
        {
            try
            {
                using (Conexao db = new Conexao())
                {
                    var pacienteOcupado = (from TB_CONSULTA in db.GetTable<Consulta>()
                                           where TB_CONSULTA.ID_PACIENTE == idPaciente
                                           && TB_CONSULTA.HORARIO == dataHora
                                           select TB_CONSULTA).SingleOrDefault();

                    var medicoOcupado = (from TB_CONSULTA in db.GetTable<Consulta>()
                                         where TB_CONSULTA.ID_MEDICO == idMedico
                                         && TB_CONSULTA.HORARIO == dataHora
                                         select TB_CONSULTA).SingleOrDefault();

                    if (pacienteOcupado != null)
                        return false;
                    else if (medicoOcupado != null)
                        return false;
                    else
                        return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}

