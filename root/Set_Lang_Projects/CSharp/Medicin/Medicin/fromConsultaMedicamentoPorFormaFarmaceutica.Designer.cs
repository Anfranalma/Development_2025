
namespace Medicin
{
    partial class fromConsultaMedicamentoPorFormaFarmaceutica
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbListado = new System.Windows.Forms.ComboBox();
            this.dgvMedicamento = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamento)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(161, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Listado";
            // 
            // cmbListado
            // 
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Location = new System.Drawing.Point(233, 25);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(334, 21);
            this.cmbListado.TabIndex = 1;
            this.cmbListado.SelectedIndexChanged += new System.EventHandler(this.Filtrar);
            // 
            // dgvMedicamento
            // 
            this.dgvMedicamento.AllowUserToAddRows = false;
            this.dgvMedicamento.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicamento.Location = new System.Drawing.Point(84, 67);
            this.dgvMedicamento.Name = "dgvMedicamento";
            this.dgvMedicamento.ReadOnly = true;
            this.dgvMedicamento.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicamento.Size = new System.Drawing.Size(606, 371);
            this.dgvMedicamento.TabIndex = 2;
            // 
            // fromConsultaMedicamentoPorFormaFarmaceutica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgvMedicamento);
            this.Controls.Add(this.cmbListado);
            this.Controls.Add(this.label1);
            this.Name = "fromConsultaMedicamentoPorFormaFarmaceutica";
            this.Text = "fromConsultaMedicamentoPorFormaFarmaceutica";
            this.Load += new System.EventHandler(this.fromConsultaMedicamentoPorFormaFarmaceutica_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamento)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbListado;
        private System.Windows.Forms.DataGridView dgvMedicamento;
    }
}