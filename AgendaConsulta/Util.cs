using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaConsulta
{
    public class Util
    {
        public bool CampoTextoValido(string texto, string nomeCampo)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                MessageBox.Show($"Preencha o campo \"{nomeCampo}\".", "Sistema Agenda Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (texto.Length < 3)
            {
                MessageBox.Show($"O campo \"{nomeCampo}\" deve ter no mínimo 3 caracteres.", "Sistema Agenda Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else if (texto.Length > 50)
            {
                MessageBox.Show($"O campo \"{nomeCampo}\" deve ter no máximo 50 caracteres.", "Sistema Agenda Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public bool CampoDataValido(DateTime data, string nomeCampo)
        {
            if (data > DateTime.Now)
            {
                MessageBox.Show($"\"{nomeCampo}\" não pode ser uma data futura.", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
