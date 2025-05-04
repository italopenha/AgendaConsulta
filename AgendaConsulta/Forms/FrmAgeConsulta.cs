using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaConsulta.Forms
{
    public partial class FrmAgeConsulta : Form
    {
        public FrmAgeConsulta()
        {
            InitializeComponent();
        }

        private void dtpDataHora_ValueChanged(object sender, EventArgs e)
        {
            var dt = dtpDataHora.Value;
            // Arredonda para o horário exato da hora (sem minutos e segundos)
            dtpDataHora.Value = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
        }
    }
}
