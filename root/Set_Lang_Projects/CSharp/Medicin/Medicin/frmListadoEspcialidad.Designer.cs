
namespace Medicin
{
    partial class frmListadoEspcialidad
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
            this.dgvEspecialidad = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidad)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEspecialidad
            // 
            this.dgvEspecialidad.AllowUserToAddRows = false;
            this.dgvEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidad.Location = new System.Drawing.Point(16, 160);
            this.dgvEspecialidad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEspecialidad.Name = "dgvEspecialidad";
            this.dgvEspecialidad.ReadOnly = true;
            this.dgvEspecialidad.RowHeadersWidth = 51;
            this.dgvEspecialidad.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEspecialidad.Size = new System.Drawing.Size(1035, 379);
            this.dgvEspecialidad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(143, 91);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Listado Especialidad:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(321, 91);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(364, 22);
            this.txtNombre.TabIndex = 2;
            this.txtNombre.TextChanged += new System.EventHandler(this.filtrar);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnNew);
            this.flowLayoutPanel1.Controls.Add(this.btnEditar);
            this.flowLayoutPanel1.Controls.Add(this.btnEliminar);
            this.flowLayoutPanel1.Controls.Add(this.btnPrint);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(31, 15);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1007, 41);
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
            // frmListadoEspcialidad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEspecialidad);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmListadoEspcialidad";
            this.Text = "frmListadoEspcialidad";
            this.Load += new System.EventHandler(this.frmListadoEspcialidad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidad)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnPrint;
    }
}