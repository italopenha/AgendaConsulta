using AgendaConsulta.Entidades;
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
        private readonly Util util = new Util();
        private readonly Negocios.CrudNegocios crudNeg = new Negocios.CrudNegocios();

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
                DesbloquearBotoes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void MontarEntidadeAnterior()
        {
            try
            {
                if (dgvDados.RowCount > 0)
                {
                    pacienteAnt = new Entidades.Paciente();
                    pacienteAnt.ID_PACIENTE = Convert.ToInt32(dgvDados.CurrentRow.Cells["ID_PACIENTE"].Value.ToString());
                    pacienteAnt.NOME = dgvDados.CurrentRow.Cells["NOME"].Value.ToString();
                    pacienteAnt.DT_NASCIMENTO = Convert.ToDateTime(dgvDados.CurrentRow.Cells["DT_NASCIMENTO"].Value.ToString());

                    txtNome.Text = pacienteAnt.NOME;
                    dtpDtNascimento.Value = pacienteAnt.DT_NASCIMENTO;
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

                if (util.CampoTextoValido(txtNome.Text, "Nome do Paciente"))
                    paciente.NOME = txtNome.Text;
                else
                    return false;

                if (util.CampoDataValido(dtpDtNascimento.Value, "Data de Nascimento"))
                    paciente.DT_NASCIMENTO = Convert.ToDateTime(dtpDtNascimento.Text);
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private bool CadastrarPaciente()
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

        private bool AtualizarPaciente()
        {
            try
            {
                if (MontarEntidade())
                {
                    crudNeg.AtualizarPaciente(paciente);
                    MessageBox.Show("Paciente atualizado com sucesso!", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool ConsultarPacientesPorNome()
        {
            try
            {
                string nome = txtNome.Text.Trim();

                if (util.CampoTextoValido(nome, "Nome do Paciente"))
                {
                    dgvDados.DataSource = crudNeg.ConsultarPacientesPorNome(nome);

                    if (dgvDados.Rows.Count == 0)
                    {
                        MessageBox.Show($"Não existe nenhum paciente com o nome \"{nome}\".", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

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

        private void BloquearBotoes()
        {
            try
            {
                btnCadastrar.Enabled = false;
                btnConsultarPorNome.Enabled = false;
                btnExcluir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DesbloquearBotoes()
        {
            try
            {
                btnCadastrar.Enabled = true;
                btnConsultarPorNome.Enabled = true;
                btnExcluir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgvDados_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                MontarEntidadeAnterior();
                BloquearBotoes();
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

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (AtualizarPaciente())
                {
                    ListarPacientes();
                }
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

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                LimparDados();
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

        private void btnConsultarPorNome_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ConsultarPacientesPorNome();
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

        private void btnListarTodos_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
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

        private void dgvDados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool cell_checked = false;
                if (e.RowIndex >= 0)
                {
                    cell_checked = Convert.ToBoolean(dgvDados.CurrentRow.Cells["checkBoxColumn"].Value);

                    if (cell_checked == true)
                    {
                        dgvDados.CurrentRow.Cells["checkBoxColumn"].Value = false;
                    }
                    else if (cell_checked == false)
                    {
                        dgvDados.CurrentRow.Cells["checkBoxColumn"].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
