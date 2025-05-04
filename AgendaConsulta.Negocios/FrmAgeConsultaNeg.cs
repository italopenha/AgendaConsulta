using AgendaConsulta.Dados;
using AgendaConsulta.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Negocios
{
    public class FrmAgeConsultaNeg
    {
        private readonly FrmAgeConsultaDad objFrmAgeConsultaDad = new FrmAgeConsultaDad();

        public bool AgendaDisponivel(int idPaciente, int idMedico, DateTime dataHora)
        {
            try
            {
                return objFrmAgeConsultaDad.AgendaDisponivel(idPaciente, idMedico, dataHora);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
    }
}
