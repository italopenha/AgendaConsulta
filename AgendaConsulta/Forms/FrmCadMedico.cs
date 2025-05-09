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
    public partial class FrmCadMedico : Form
    {
        private Entidades.Medico medico = new Entidades.Medico();
        private Entidades.Medico medicoAnt = new Entidades.Medico();
        private List<Entidades.Medico> ListaMedicos = new List<Entidades.Medico>();
        private readonly Util util = new Util();
        private readonly Negocios.CrudNegocios crudNeg = new Negocios.CrudNegocios();

        public FrmCadMedico()
        {
            InitializeComponent();
        }

        private void ListarMedicos()
        {
            try
            {
                dgvDados.DataSource = crudNeg.ListarMedicos();
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
                txtEspecialidade.Clear();
                DesbloquearBotoes();
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
                btnConsultarPorEspecialidade.Enabled = true;
                btnExcluir.Enabled = true;
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
                    medicoAnt = new Entidades.Medico();
                    medicoAnt.ID_MEDICO = Convert.ToInt32(dgvDados.CurrentRow.Cells["ID_MEDICO"].Value.ToString());
                    medicoAnt.NOME = dgvDados.CurrentRow.Cells["NOME"].Value.ToString();
                    medicoAnt.ESPECIALIDADE = dgvDados.CurrentRow.Cells["ESPECIALIDADE"].Value.ToString();

                    txtNome.Text = medicoAnt.NOME;
                    txtEspecialidade.Text = medicoAnt.ESPECIALIDADE;
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
                dgvDados.Columns["ID_MEDICO"].Visible = false;
                dgvDados.Columns["NOME"].HeaderText = "Nome";
                dgvDados.Columns["ESPECIALIDADE"].HeaderText = "Especialidade";
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
                medico = new Entidades.Medico();

                if (medicoAnt.ID_MEDICO != 0)
                    medico.ID_MEDICO = medicoAnt.ID_MEDICO;

                if (util.ValidarCampoTexto(txtNome.Text, "Nome do Médico"))
                    medico.NOME = txtNome.Text;
                else
                    return false;

                if (util.ValidarCampoTexto(txtEspecialidade.Text, "Especialidade"))
                    medico.ESPECIALIDADE = txtEspecialidade.Text;
                else
                    return false;

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private bool CadastrarMedico()
        {
            try
            {
                if (MontarEntidade())
                {
                    crudNeg.InserirMedico(medico);
                    MessageBox.Show("Médico cadastrado com sucesso!", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool AtualizarMedico()
        {
            try
            {
                if (MontarEntidade())
                {
                    crudNeg.AtualizarMedico(medico);
                    MessageBox.Show("Médico atualizado com sucesso!", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool ConsultarMedicosPorNome()
        {
            try
            {
                string nome = txtNome.Text.Trim();

                if (util.ValidarCampoTexto(nome, "Nome do Médico"))
                {
                    dgvDados.DataSource = crudNeg.ConsultarMedicosPorNome(nome);

                    if (dgvDados.Rows.Count == 0)
                    {
                        MessageBox.Show($"Não existe nenhum médico com o nome \"{nome}\".", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private bool ConsultarMedicosPorEspecialidade()
        {
            try
            {
                string especialidade = txtEspecialidade.Text.Trim();

                if (util.ValidarCampoTexto(especialidade, "Especialidade"))
                {
                    dgvDados.DataSource = crudNeg.ConsultarMedicosPorEspecialidade(especialidade);

                    if (dgvDados.Rows.Count == 0)
                    {
                        MessageBox.Show($"Não existe nenhum médico para a especialidade \"{especialidade}\".", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                btnConsultarPorEspecialidade.Enabled = false;
                btnExcluir.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ExcluirMedicos()
        {
            try
            {
                if (MessageBox.Show("Deseja realmente excluir este(s) médicos?", " Sistema Agenda Consulta ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ListaMedicos = new List<Entidades.Medico>();

                    foreach (DataGridViewRow row in dgvDados.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells["checkBoxColumn"].Value) == true)
                        {
                            ListaMedicos.Add(new Entidades.Medico()
                            {
                                ID_MEDICO = Convert.ToInt32(row.Cells["ID_MEDICO"].Value.ToString()),
                                NOME = row.Cells["NOME"].Value.ToString(),
                                ESPECIALIDADE = row.Cells["ESPECIALIDADE"].Value.ToString()
                            });
                        }
                    }

                    if (ListaMedicos.Count > 0)
                    {
                        crudNeg.ExcluirMedicosEmLote(ListaMedicos);
                        MessageBox.Show("Médicos(s) excluído(s) com sucesso!", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparDados();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Nenhum médico selecionado para exclusão.", " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
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

        private void txtEspecialidade_KeyPress(object sender, KeyPressEventArgs e)
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

        private void FrmCadMedico_Load(object sender, EventArgs e)
        {
            try
            {
                ListarMedicos();
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
                CadastrarMedico();
                ListarMedicos();
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
                if (AtualizarMedico())
                {
                    ListarMedicos();
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
                ConsultarMedicosPorNome();
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

        private void btnConsultarPorEspecialidade_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                ConsultarMedicosPorEspecialidade();
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
                ListarMedicos();
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                if (ExcluirMedicos())
                {
                    ListarMedicos();
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
