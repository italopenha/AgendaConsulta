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
        private static readonly string connectionString;

        static Conexao()
        {
#if DEBUG
            connectionString = "Server=localhost;Database=TESTE;Trusted_Connection=True;";  
#else
            connectionString = "Server=localhost;Database=BD_AGENDA_CONSULTA;Trusted_Connection=True;";  
#endif
        }

        public Conexao() : base(connectionString) { }
    }
}
