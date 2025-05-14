using AgendaConsulta.Entidades;
using AgendaConsulta.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgendaConsulta.Forms
{
    public partial class FrmAgeConsulta : Form
    {
        private Consulta consulta = new Consulta();
        private Consulta consultaAnt = new Consulta();
        private List<Paciente> ListaPacientes;
        private List<Medico> ListaMedicos;
        private readonly CrudNegocios objNeg = new CrudNegocios();
        private readonly FrmAgeConsultaNeg objAgeCon = new FrmAgeConsultaNeg();
        private readonly Util util = new Util();

        public FrmAgeConsulta()
        {
            InitializeComponent();
        }

        private void ListarConsultas()
        {
            try
            {
                dgvDados.DataSource = objNeg.ListarConsultas();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private bool AgendarConsulta()
        {
            try
            {
                if (MontarEntidade())
                {
                    if (objAgeCon.AgendaDisponivel(Convert.ToInt32(cbxPaciente.SelectedValue), Convert.ToInt32(cbxMedico.SelectedValue), dtpDataHora.Value))
                    {
                        objNeg.InserirConsulta(consulta);
                        MessageBox.Show("Consulta agendada com sucesso!", "Sistema Agenda Consulta", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LimparDados();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("A consulta não pode ser agendada.\n\nO paciente ou médico selecionado já tem uma consulta agendada nesse horário.", "Sistema Agenda Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("É necessário preencher todos os campos.", "Sistema Agenda Consulta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public bool MontarEntidade()
        {
            try
            {
                consulta = new Consulta();

                if (consultaAnt.ID_CONSULTA != 0)
                {
                    consulta.ID_CONSULTA = consultaAnt.ID_CONSULTA;
                }

                if (cbxPaciente.SelectedValue == null)
                {
                    return false;
                }
                else
                {
                    consulta.ID_PACIENTE = Convert.ToInt32(cbxPaciente.SelectedValue);
                }

                if (cbxMedico.SelectedValue == null)
                {
                    return false;
                }
                else
                {
                    consulta.ID_MEDICO = Convert.ToInt32(cbxMedico.SelectedValue);
                }

                if (util.ValidarCampoDataConsulta(dtpDataHora.Value, "Data e Hora") == false)
                {
                    return false;
                }
                else
                {
                    consulta.HORARIO = dtpDataHora.Value;
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private void FormatarGrid()
        {
            try
            {
                dgvDados.Columns["ID_CONSULTA"].Visible = false;
                dgvDados.Columns["HORARIO"].HeaderText = "Data e Hora";
                dgvDados.Columns["ID_PACIENTE"].Visible = false;
                dgvDados.Columns["ID_MEDICO"].Visible = false;
                dgvDados.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private void LimparDados()
        {
            try
            {
                cbxPaciente.SelectedIndex = -1;
                cbxMedico.SelectedIndex = -1;
                dtpDataHora.Value = DateTime.Now;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CarregarComboPacientes()
        {
            try
            {
                ListaPacientes = new List<Paciente>();
                ListaPacientes = objNeg.ListarPacientes();
                cbxPaciente.DataSource = ListaPacientes;
                cbxPaciente.DisplayMember = "NOME";
                cbxPaciente.ValueMember = "ID_PACIENTE";
                int ID_PACIENTE = Convert.ToInt32(cbxPaciente.SelectedValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public void CarregarComboMedicos()
        {
            try
            {
                ListaMedicos = new List<Medico>();
                ListaMedicos = objNeg.ListarMedicos();
                cbxMedico.DataSource = ListaMedicos;
                cbxMedico.DisplayMember = "NOME";
                cbxMedico.ValueMember = "ID_MEDICO";
                int ID_MEDICO = Convert.ToInt32(cbxMedico.SelectedValue);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        private void dtpDataHora_ValueChanged(object sender, EventArgs e)
        {
            var dt = dtpDataHora.Value;
            // Arredonda para o horário exato da hora (sem minutos e segundos)
            dtpDataHora.Value = new DateTime(dt.Year, dt.Month, dt.Day, dt.Hour, 0, 0);
        }

        private void FrmAgeConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                CarregarComboPacientes();
                CarregarComboMedicos();
                ListarConsultas();
                LimparDados();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, " Sistema Agenda Consulta ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            try
            {
                LimparDados();
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

        private void btnAgendar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor = Cursors.WaitCursor;
                AgendarConsulta();
                ListarConsultas();
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
