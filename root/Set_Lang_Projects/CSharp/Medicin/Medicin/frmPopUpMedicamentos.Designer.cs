
namespace Medicin
{
    partial class frmPopUpMedicamentos
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtConcentracion = new System.Windows.Forms.TextBox();
            this.cmbForma = new System.Windows.Forms.ComboBox();
            this.NumericPrecio = new System.Windows.Forms.NumericUpDown();
            this.txtPresentacion = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.ErrorDatos = new System.Windows.Forms.ErrorProvider(this.components);
            this.numericStock = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.NumericPrecio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Concentracion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Forma Farmaceutica";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, 191);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Precio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(93, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Stock";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(93, 289);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 5;
            this.label6.Text = "Presentacion";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(369, 43);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(232, 22);
            this.txtNombre.TabIndex = 6;
            this.txtNombre.Tag = "O";
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // txtConcentracion
            // 
            this.txtConcentracion.Location = new System.Drawing.Point(369, 88);
            this.txtConcentracion.Name = "txtConcentracion";
            this.txtConcentracion.Size = new System.Drawing.Size(232, 22);
            this.txtConcentracion.TabIndex = 7;
            this.txtConcentracion.Tag = "O";
            // 
            // cmbForma
            // 
            this.cmbForma.FormattingEnabled = true;
            this.cmbForma.Location = new System.Drawing.Point(369, 133);
            this.cmbForma.Name = "cmbForma";
            this.cmbForma.Size = new System.Drawing.Size(232, 24);
            this.cmbForma.TabIndex = 8;
            // 
            // NumericPrecio
            // 
            this.NumericPrecio.Location = new System.Drawing.Point(369, 189);
            this.NumericPrecio.Name = "NumericPrecio";
            this.NumericPrecio.Size = new System.Drawing.Size(232, 22);
            this.NumericPrecio.TabIndex = 9;
            // 
            // txtPresentacion
            // 
            this.txtPresentacion.Location = new System.Drawing.Point(369, 286);
            this.txtPresentacion.Name = "txtPresentacion";
            this.txtPresentacion.Size = new System.Drawing.Size(232, 22);
            this.txtPresentacion.TabIndex = 11;
            this.txtPresentacion.Tag = "O";
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Location = new System.Drawing.Point(183, 363);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(142, 23);
            this.btnAceptar.TabIndex = 12;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(415, 363);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(142, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // ErrorDatos
            // 
            this.ErrorDatos.ContainerControl = this;
            // 
            // numericStock
            // 
            this.numericStock.Location = new System.Drawing.Point(369, 241);
            this.numericStock.Name = "numericStock";
            this.numericStock.Size = new System.Drawing.Size(232, 22);
            this.numericStock.TabIndex = 14;
            this.numericStock.Tag = "O";
            // 
            // frmPopUpMedicamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numericStock);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.txtPresentacion);
            this.Controls.Add(this.NumericPrecio);
            this.Controls.Add(this.cmbForma);
            this.Controls.Add(this.txtConcentracion);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmPopUpMedicamentos";
            this.Text = "frmPopUpMedicamentos";
            this.Load += new System.EventHandler(this.frmPopUpMedicamentos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.NumericPrecio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericStock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtConcentracion;
        private System.Windows.Forms.ComboBox cmbForma;
        private System.Windows.Forms.NumericUpDown NumericPrecio;
        private System.Windows.Forms.TextBox txtPresentacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider ErrorDatos;
        private System.Windows.Forms.NumericUpDown numericStock;
    }
}