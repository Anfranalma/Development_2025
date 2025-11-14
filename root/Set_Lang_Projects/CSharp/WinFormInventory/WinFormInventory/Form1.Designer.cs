
namespace WinFormInventory
{
    partial class Form1
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
            this.dgvClinica = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIdClinica = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinica)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClinica
            // 
            this.dgvClinica.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClinica.Location = new System.Drawing.Point(11, 117);
            this.dgvClinica.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvClinica.Name = "dgvClinica";
            this.dgvClinica.RowHeadersWidth = 51;
            this.dgvClinica.RowTemplate.Height = 24;
            this.dgvClinica.Size = new System.Drawing.Size(653, 332);
            this.dgvClinica.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Id Clinica";
            // 
            // txtIdClinica
            // 
            this.txtIdClinica.Location = new System.Drawing.Point(130, 44);
            this.txtIdClinica.Name = "txtIdClinica";
            this.txtIdClinica.Size = new System.Drawing.Size(250, 20);
            this.txtIdClinica.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(406, 42);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(497, 42);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 479);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.txtIdClinica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvClinica);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClinica)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClinica;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdClinica;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

