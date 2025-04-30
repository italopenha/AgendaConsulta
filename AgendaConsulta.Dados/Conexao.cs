using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaConsulta.Dados
{
    public class Conexao : DataContext
    {
        public static string connectionString = "Server=localhost;Database=BD_AGENDA_CONSULTA;Trusted_Connection=True;";

        public Conexao() : base(connectionString) { }
    }
}
