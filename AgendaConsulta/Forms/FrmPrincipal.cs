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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Método para fechar o form ativo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (Form form in this.MdiChildren)
                {
                    form.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrarPaciente_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CloseAllToolStripMenuItem_Click(null, null);

                FrmCadPaciente frm = new FrmCadPaciente
                {
                    MdiParent = this
                };
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnCadastrarMedico_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CloseAllToolStripMenuItem_Click(null, null);

                FrmCadMedico frm = new FrmCadMedico
                {
                    MdiParent = this
                };
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void btnAgendarConsulta_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CloseAllToolStripMenuItem_Click(null, null);

                FrmAgeConsulta frm = new FrmAgeConsulta
                {
                    MdiParent = this
                };
                frm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
    }
}
