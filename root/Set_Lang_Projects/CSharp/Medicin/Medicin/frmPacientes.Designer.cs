
namespace Medicin
{
    partial class frmPacientes
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
            this.dgvListado = new System.Windows.Forms.DataGridView();
            this.lblCreterio = new System.Windows.Forms.Label();
            this.cmbListado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvListado
            // 
            this.dgvListado.AllowUserToAddRows = false;
            this.dgvListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListado.Location = new System.Drawing.Point(44, 155);
            this.dgvListado.Margin = new System.Windows.Forms.Padding(4);
            this.dgvListado.Name = "dgvListado";
            this.dgvListado.ReadOnly = true;
            this.dgvListado.RowHeadersWidth = 51;
            this.dgvListado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListado.Size = new System.Drawing.Size(1007, 353);
            this.dgvListado.TabIndex = 0;
            // 
            // lblCreterio
            // 
            this.lblCreterio.AutoSize = true;
            this.lblCreterio.Location = new System.Drawing.Point(115, 65);
            this.lblCreterio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreterio.Name = "lblCreterio";
            this.lblCreterio.Size = new System.Drawing.Size(222, 17);
            this.lblCreterio.TabIndex = 1;
            this.lblCreterio.Text = "Seleccione Criterio de Busquedad";
            // 
            // cmbListado
            // 
            this.cmbListado.FormattingEnabled = true;
            this.cmbListado.Items.AddRange(new object[] {
            "Nombre",
            "Apellido Paterno",
            "Apellido Materno"});
            this.cmbListado.Location = new System.Drawing.Point(384, 65);
            this.cmbListado.Margin = new System.Windows.Forms.Padding(4);
            this.cmbListado.Name = "cmbListado";
            this.cmbListado.Size = new System.Drawing.Size(235, 24);
            this.cmbListado.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 107);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ingrese Valor";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(384, 107);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(235, 22);
            this.txtValor.TabIndex = 4;
            this.txtValor.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(44, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1007, 36);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.Location = new System.Drawing.Point(4, 4);
            this.btnNew.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnEditar.Margin = new System.Windows.Forms.Padding(4);
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
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 28);
            this.btnEliminar.TabIndex = 8;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(328, 4);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(4);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(100, 28);
            this.btnPrint.TabIndex = 9;
            this.btnPrint.Text = "Imprimir";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // frmPacientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbListado);
            this.Controls.Add(this.lblCreterio);
            this.Controls.Add(this.dgvListado);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPacientes";
            this.Text = "frmPacientes";
            this.Load += new System.EventHandler(this.frmPacientes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListado)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListado;
        private System.Windows.Forms.Label lblCreterio;
        private System.Windows.Forms.ComboBox cmbListado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnPrint;
    }
}