
namespace WinFormInventory
{
    partial class frmListadoEspecialidades
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
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidad)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEspecialidad
            // 
            this.dgvEspecialidad.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEspecialidad.Location = new System.Drawing.Point(7, 78);
            this.dgvEspecialidad.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvEspecialidad.Name = "dgvEspecialidad";
            this.dgvEspecialidad.RowHeadersWidth = 51;
            this.dgvEspecialidad.RowTemplate.Height = 24;
            this.dgvEspecialidad.Size = new System.Drawing.Size(582, 309);
            this.dgvEspecialidad.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre de Especialidad";
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(182, 30);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(184, 20);
            this.txtFiltrar.TabIndex = 3;
            this.txtFiltrar.TextChanged += new System.EventHandler(this.txtFiltrar_TextChanged);
            // 
            // frmListadoEspecialidades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 398);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvEspecialidad);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmListadoEspecialidades";
            this.Text = "frmListadoEspecialidades";
            this.Load += new System.EventHandler(this.frmListadoEspecialidades_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEspecialidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEspecialidad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFiltrar;
    }
}