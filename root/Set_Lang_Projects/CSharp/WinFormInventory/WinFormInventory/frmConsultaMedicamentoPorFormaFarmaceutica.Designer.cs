
namespace WinFormInventory
{
    partial class frmConsultaMedicamentoPorFormaFarmaceutica
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
            this.cboFormaFarmaceutica = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese Forma Farmaceutica";
            // 
            // cboFormaFarmaceutica
            // 
            this.cboFormaFarmaceutica.FormattingEnabled = true;
            this.cboFormaFarmaceutica.Location = new System.Drawing.Point(226, 25);
            this.cboFormaFarmaceutica.Name = "cboFormaFarmaceutica";
            this.cboFormaFarmaceutica.Size = new System.Drawing.Size(275, 21);
            this.cboFormaFarmaceutica.TabIndex = 1;
            // 
            // frmConsultaMedicamentoPorFormaFarmaceutica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cboFormaFarmaceutica);
            this.Controls.Add(this.label1);
            this.Name = "frmConsultaMedicamentoPorFormaFarmaceutica";
            this.Load += new System.EventHandler(this.frmConsultaMedicamentoPorFormaFarmaceutica_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboFormaFarmaceutica;
    }
}