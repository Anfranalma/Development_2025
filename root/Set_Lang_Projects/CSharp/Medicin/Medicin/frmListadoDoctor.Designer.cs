
namespace Medicin
{
    partial class frmListadoDoctor
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
            this.dgvDoctor = new System.Windows.Forms.DataGridView();
            this.rdPaterno = new System.Windows.Forms.RadioButton();
            this.rdMaterno = new System.Windows.Forms.RadioButton();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDoctor
            // 
            this.dgvDoctor.AllowUserToAddRows = false;
            this.dgvDoctor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoctor.Location = new System.Drawing.Point(16, 119);
            this.dgvDoctor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvDoctor.Name = "dgvDoctor";
            this.dgvDoctor.ReadOnly = true;
            this.dgvDoctor.RowHeadersWidth = 51;
            this.dgvDoctor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoctor.Size = new System.Drawing.Size(1035, 420);
            this.dgvDoctor.TabIndex = 0;
            // 
            // rdPaterno
            // 
            this.rdPaterno.AutoSize = true;
            this.rdPaterno.Location = new System.Drawing.Point(76, 71);
            this.rdPaterno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdPaterno.Name = "rdPaterno";
            this.rdPaterno.Size = new System.Drawing.Size(138, 21);
            this.rdPaterno.TabIndex = 1;
            this.rdPaterno.TabStop = true;
            this.rdPaterno.Text = "Appelido Paterno";
            this.rdPaterno.UseVisualStyleBackColor = true;
            // 
            // rdMaterno
            // 
            this.rdMaterno.AutoSize = true;
            this.rdMaterno.Location = new System.Drawing.Point(225, 71);
            this.rdMaterno.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rdMaterno.Name = "rdMaterno";
            this.rdMaterno.Size = new System.Drawing.Size(135, 21);
            this.rdMaterno.TabIndex = 2;
            this.rdMaterno.TabStop = true;
            this.rdMaterno.Text = "Apellido Materno";
            this.rdMaterno.UseVisualStyleBackColor = true;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(393, 71);
            this.txtValor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(348, 22);
            this.txtValor.TabIndex = 3;
            this.txtValor.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(16, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1007, 37);
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
            // frmListadoDoctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.rdMaterno);
            this.Controls.Add(this.rdPaterno);
            this.Controls.Add(this.dgvDoctor);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListadoDoctor";
            this.Text = "frmListadoDoctor";
            this.Load += new System.EventHandler(this.frmListadoDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoctor)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoctor;
        private System.Windows.Forms.RadioButton rdPaterno;
        private System.Windows.Forms.RadioButton rdMaterno;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnPrint;
    }
}