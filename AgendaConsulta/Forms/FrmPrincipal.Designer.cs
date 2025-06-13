namespace AgendaConsulta.Forms
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPrincipal));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnCadastrarPaciente = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCadastrarMedico = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAgendarConsulta = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.btnAgendarConsulta});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnCadastrarPaciente,
            this.btnCadastrarMedico});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(67, 22);
            this.toolStripDropDownButton1.Text = "Cadastro";
            // 
            // btnCadastrarPaciente
            // 
            this.btnCadastrarPaciente.Name = "btnCadastrarPaciente";
            this.btnCadastrarPaciente.Size = new System.Drawing.Size(180, 22);
            this.btnCadastrarPaciente.Text = "Pacientes";
            this.btnCadastrarPaciente.Click += new System.EventHandler(this.btnCadastrarPaciente_Click);
            // 
            // btnCadastrarMedico
            // 
            this.btnCadastrarMedico.Name = "btnCadastrarMedico";
            this.btnCadastrarMedico.Size = new System.Drawing.Size(180, 22);
            this.btnCadastrarMedico.Text = "Médicos(as)";
            this.btnCadastrarMedico.Click += new System.EventHandler(this.btnCadastrarMedico_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAgendarConsulta
            // 
            this.btnAgendarConsulta.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAgendarConsulta.Image = ((System.Drawing.Image)(resources.GetObject("btnAgendarConsulta.Image")));
            this.btnAgendarConsulta.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAgendarConsulta.Name = "btnAgendarConsulta";
            this.btnAgendarConsulta.Size = new System.Drawing.Size(106, 22);
            this.btnAgendarConsulta.Text = "Agendar Consulta";
            this.btnAgendarConsulta.Click += new System.EventHandler(this.btnAgendarConsulta_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "FrmPrincipal";
            this.Text = "Sistema Agenda Consulta";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem btnCadastrarPaciente;
        private System.Windows.Forms.ToolStripMenuItem btnCadastrarMedico;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnAgendarConsulta;
    }
}