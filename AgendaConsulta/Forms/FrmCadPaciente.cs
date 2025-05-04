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
    public partial class FrmCadPaciente : Form
    {
        private Entidades.Paciente paciente = new Entidades.Paciente();
        private Entidades.Paciente pacienteAnt = new Entidades.Paciente();
        private Util util = new Util();
        private Negocios.CrudNegocios crudNeg = new Negocios.CrudNegocios();

        public FrmCadPaciente()
        {
            InitializeComponent();
        }

        private void ListarPacientes()
        {
            try
            {
                dgvDados.DataSource = crudNeg.ListarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LimparDados()
        {
            try
            {
                txtNome.Clear();
                dtpDtNascimento.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void MontarEntidadeAnterior()
        {
            try
            {
                if (dgvDados.RowCount > 0)
                {
                    pacienteAnt = new Entidades.Paciente();
                    pacienteAnt.ID_PACIENTE = Convert.ToInt32(dgvDados.CurrentRow.Cells["ID_PACIENTE"].Value.ToString());
                    pacienteAnt.NOME = dgvDados.CurrentRow.Cells["NOME"].Value.ToString();
                    pacienteAnt.DT_NASCIMENTO = Convert.ToDateTime(dgvDados.CurrentRow.Cells["DT_NASCIMENTO"].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatarGrid()
        {
            try
            {
                dgvDados.Columns["ID_PACIENTE"].Visible = false;
                dgvDados.Columns["NOME"].HeaderText = "Nome";
                dgvDados.Columns["DT_NASCIMENTO"].HeaderText = "Data de Nascimento";
                dgvDados.Columns["DT_NASCIMENTO"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvDados.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private bool MontarEntidade()
        {
            try
            {
                paciente = new Entidades.Paciente();

                if (pacienteAnt.ID_PACIENTE != 0)
                    paciente.ID_PACIENTE = pacienteAnt.ID_PACIENTE;

                if (util.VerificaTamanhoTexto(txtNome.Text, "Nome do Paciente") == false)
                    return false;
                else 
                    paciente.NOME = txtNome.Text;

                paciente.DT_NASCIMENTO = Convert.ToDateTime(dtpDtNascimento.Text);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool CadastrarPaciente()
        {
            try
            {
                if (MontarEntidade())
                {
                    crudNeg.InserirPaciente(paciente);
                    MessageBox.Show("Paciente cadastrado com sucesso!", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimparDados();
                    return true;    
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private void dgvDados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                dgvDados.AutoResizeColumns();
                foreach (DataGridViewColumn coluna in dgvDados.Columns)
                {
                    coluna.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    coluna.ReadOnly = true;
                }

                FormatarGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                // Verifica se o caractere digitado é um número e não é a tecla Backspace
                if (char.IsDigit(e.KeyChar) && e.KeyChar != '\b')
                {
                    // Define Handled como true para impedir que o caractere seja inserido no TextBox
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                CadastrarPaciente();
                ListarPacientes();
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

        private void FrmCadPaciente_Load(object sender, EventArgs e)
        {
            try
            {
                ListarPacientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
