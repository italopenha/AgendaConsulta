using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Entidades
{
    [Table(Name = "TB_PACIENTE")]
    public class Paciente
    {
        int _ID_PACIENTE;
        /// <summary>
        /// COLUNA ID_PACIENTE
        /// </summary>
        [Column(Storage = "_ID_PACIENTE", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID_PACIENTE { get { return _ID_PACIENTE; } set { _ID_PACIENTE = value; } }

        string _NOME;
        /// <summary>
        /// COLUNA NOME
        /// </summary>
        [Column(Storage = "_NOME", CanBeNull = false)]
        public string NOME { get { return _NOME; } set { _NOME = value; } }

        DateTime _DT_NASCIMENTO;
        /// <summary>
        /// COLUNA DT_NASCIMENTO
        /// </summary>
        [Column(Storage = "_DT_NASCIMENTO", CanBeNull = false)]
        public DateTime DT_NASCIMENTO { get { return _DT_NASCIMENTO; } set { _DT_NASCIMENTO = value; } }
    }
}
