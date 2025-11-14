using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Medicin
{
    public partial class frmPopUpMedicamentos : Form
    {
        public string accion { get; set; }
        public string id { get; set; }

        public frmPopUpMedicamentos()
        {
            InitializeComponent();
        }

        private void frmPopUpMedicamentos_Load(object sender, EventArgs e)
        {
            SQL.llenarComboBox("USPLLENARCOMBOFORMAFARMACEUTICA", cmbForma, "NOMBRE", "Id");
            if (accion.Equals("Nuevo"))
            {
                this.Text = "Ingrese Medicamento";
            }
            else
            {
                this.Text = "Actualize Medicamento";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string concentracion = txtConcentracion.Text;
            string iidformaFarmaceutica = cmbForma.SelectedValue.ToString();
            decimal precio = NumericPrecio.Value;
            int stock = int.Parse(numericStock.Text);
            string presentacion = txtPresentacion.Text;
            bool exito = SQL.validarRequeridos(this.Controls, ErrorDatos);
            if (!exito)
            {
                this.DialogResult = DialogResult.None;
                return;
            }
            if (accion.Equals("Nuevo"))
            {
                int n =SQL.registrarYActualizarYEliminar("USPINSERTARMEDICAMENTOS", new ArrayList { "@NOMBRE", "@CONCENTRACION", "@IIDFORMAFARMACEUTICA", "@PRECIO", "@STOCK","PRESENTACION" },
                    new ArrayList { nombre, concentracion, iidformaFarmaceutica, precio, stock, presentacion });

                if(n==1)
                {
                    MessageBox.Show("Well Done!");
                }
                else
                {
                    MessageBox.Show("Already Exists!");
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
