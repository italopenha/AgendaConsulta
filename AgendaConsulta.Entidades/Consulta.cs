using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Entidades
{
    [Table(Name = "TB_CONSULTA")]
    public class Consulta
    {
        int _ID_CONSULTA;
        /// <summary>
        /// COLUNA ID_CONSULTA
        /// </summary>
        [Column(Storage = "_ID_CONSULTA", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID_CONSULTA { get { return _ID_CONSULTA; } set { _ID_CONSULTA = value; } }

        DateTime _HORARIO;
        /// <summary>
        /// COLUNA HORARIO
        /// </summary>
        [Column(Storage = "_HORARIO", CanBeNull = false)]
        public DateTime HORARIO { get { return _HORARIO; } set { _HORARIO = value; } }

        int _ID_PACIENTE;
        /// <summary>
        /// COLUNA ID_PACIENTE
        /// </summary>
        [Column(Storage = "_ID_PACIENTE", CanBeNull = false)]
        public int ID_PACIENTE { get { return _ID_PACIENTE; } set { _ID_PACIENTE = value; } }

        int _ID_MEDICO;
        /// <summary>
        /// COLUNA ID_MEDICO
        /// </summary>
        [Column(Storage = "_ID_MEDICO", CanBeNull = false)]
        public int ID_MEDICO { get { return _ID_MEDICO; } set { _ID_MEDICO = value; } }
    }
}
