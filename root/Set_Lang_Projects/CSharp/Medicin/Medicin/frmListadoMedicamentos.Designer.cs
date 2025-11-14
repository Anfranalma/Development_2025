
namespace Medicin
{
    partial class frmListadoMedicamentos
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
            this.dgvMedicamentos = new System.Windows.Forms.DataGridView();
            this.rdNombre = new System.Windows.Forms.RadioButton();
            this.rdConcentracion = new System.Windows.Forms.RadioButton();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMedicamentos
            // 
            this.dgvMedicamentos.AllowUserToAddRows = false;
            this.dgvMedicamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMedicamentos.Location = new System.Drawing.Point(101, 154);
            this.dgvMedicamentos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMedicamentos.Name = "dgvMedicamentos";
            this.dgvMedicamentos.ReadOnly = true;
            this.dgvMedicamentos.RowHeadersWidth = 51;
            this.dgvMedicamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMedicamentos.Size = new System.Drawing.Size(873, 342);
            this.dgvMedicamentos.TabIndex = 0;
            // 
            // rdNombre
            // 
            this.rdNombre.AutoSize = true;
            this.rdNombre.Location = new System.Drawing.Point(185, 81);
            this.rdNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdNombre.Name = "rdNombre";
            this.rdNombre.Size = new System.Drawing.Size(79, 21);
            this.rdNombre.TabIndex = 1;
            this.rdNombre.TabStop = true;
            this.rdNombre.Text = "Nombre";
            this.rdNombre.UseVisualStyleBackColor = true;
            // 
            // rdConcentracion
            // 
            this.rdConcentracion.AutoSize = true;
            this.rdConcentracion.Location = new System.Drawing.Point(345, 81);
            this.rdConcentracion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdConcentracion.Name = "rdConcentracion";
            this.rdConcentracion.Size = new System.Drawing.Size(120, 21);
            this.rdConcentracion.TabIndex = 3;
            this.rdConcentracion.TabStop = true;
            this.rdConcentracion.Text = "Concentracion";
            this.rdConcentracion.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(503, 81);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(287, 22);
            this.txtValor.TabIndex = 4;
            this.txtValor.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(29, 14);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1007, 60);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(4, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(100, 28);
            this.btnNew.TabIndex = 6;
            this.btnNew.Text = "Nuevo";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(112, 4);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(100, 28);
            this.btnEditar.TabIndex = 7;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(220, 4);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(328, 4);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // frmListadoMedicamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.rdConcentracion);
            this.Controls.Add(this.rdNombre);
            this.Controls.Add(this.dgvMedicamentos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListadoMedicamentos";
            this.Text = "frmListadoMedicamentos";
            this.Load += new System.EventHandler(this.frmListadoMedicamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMedicamentos)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMedicamentos;
        private System.Windows.Forms.RadioButton rdNombre;
        private System.Windows.Forms.RadioButton rdConcentracion;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnPrint;
    }
}