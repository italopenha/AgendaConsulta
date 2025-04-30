using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Entidades
{
    [Table(Name = "TB_MEDICO")]
    public class Medico
    {
        int _ID_MEDICO;
        /// <summary>
        /// COLUNA ID_MEDICO
        /// </summary>
        [Column(Storage = "_ID_MEDICO", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID_MEDICO { get { return _ID_MEDICO; } set { _ID_MEDICO = value; } }

        string _NOME;
        /// <summary>
        /// COLUNA NOME
        /// </summary>
        [Column(Storage = "_NOME", CanBeNull = false)]
        public string NOME { get { return _NOME; } set { _NOME = value; } }

        string _ESPECIALIDADE;
        /// <summary>
        /// COLUNA ESPECIALIDADE
        /// </summary>
        [Column(Storage = "_ESPECIALIDADE", CanBeNull = false)]
        public string ESPECIALIDADE { get { return _ESPECIALIDADE; } set { _ESPECIALIDADE = value; } }
    }
}
