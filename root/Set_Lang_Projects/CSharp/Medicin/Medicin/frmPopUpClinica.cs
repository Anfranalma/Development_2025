using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace Medicin
{
    public partial class frmPopUpClinica : Form
    {
        public string accion { get; set; }

        public string id { get; set; }

        public frmPopUpClinica()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPopUpClinica_Load(object sender, EventArgs e)
        {
            if (accion.Equals("Nuevo"))
            {
                this.Text = "Agregar Clinica";
            }
            else
            {
                this.Text = "Editar Clinica";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            string direccion = txtDireccion.Text;
            bool exito = SQL.validarRequeridos(this.Controls, ErrorDatos);
            if (!exito)
            {
                this.DialogResult = DialogResult.None;
                return;
            }

            //if (nombre.Equals(""))
            //{
            //    ErrorDatos.SetError(txtNombre, "Ingrese Datos");
            //    this.DialogResult = DialogResult.None;
            //    return;
            //}
            //else
            //{
            //    ErrorDatos.SetError(txtNombre, "");
            //}

            //if (direccion.Equals(""))
            //{
            //    ErrorDatos.SetError(txtDireccion, "Ingrese Datos");
            //    this.DialogResult = DialogResult.None;
            //    return;
            //}
            //else
            //{
            //    ErrorDatos.SetError(txtDireccion, "");
            //}

            if (accion.Equals("Nuevo"))
            {
                //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
                //cn.Open();
                //SqlCommand cmd = new SqlCommand("uspInsertarClinica", cn);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@nombre",nombre);
                //cmd.Parameters.AddWithValue("@direccion", direccion);
                //int result = cmd.ExecuteNonQuery();
                int result = SQL.registrarYActualizarYEliminar("uspInsertarClinica",new ArrayList {"@nombre","@direccion" }, new ArrayList { nombre, direccion });
                if(result == 1)
                {
                    MessageBox.Show("Agregado Correctamente");
                    this.DialogResult = DialogResult.None;
                }
                else
                {
                    MessageBox.Show("ERROR");
                    this.DialogResult = DialogResult.None;
                }
                //cn.Close();
            }
        }
    }
}
