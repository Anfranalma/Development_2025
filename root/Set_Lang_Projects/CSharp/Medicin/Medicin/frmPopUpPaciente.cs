using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO; //To be able to read the bytes in a file.

namespace Medicin
{
    public partial class frmPopUpPaciente : Form
    {
        public string accion { get; set; }

        public string id { get; set; }

        public frmPopUpPaciente()
        {
            InitializeComponent();
        }

        byte[] buffer = null;

        private void frmPopUpPaciente_Load(object sender, EventArgs e)
        {
            SQL.llenarComboBox("USPLLENARCOMBOSEXO", cmbSexo, "NOMBRE", "IIDSEXO",true);
            SQL.llenarComboBox("USPLLENARCOMBOTIPOSANGRE", cmbTipoSangre, "NOMBRE", "IIDTIPOSANGRE",true);
            if (accion.Equals("Nuevo"))
            {
                this.Text = "Ingrese Paciente";
            }
            else
            {
                this.Text = "Actualizar Paciente";
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            string nombre = txtName.Text;
            string apPaterno = txtApePaterno.Text;
            string apmaterno = txtApeMaterno.Text;
            string email = txtEmail.Text;
            string direccion = txtDireccion.Text;
            string telefonoFijo = txtTelfix.Text;
            string telefonoCell = txtCelular.Text;
            DateTime fechaNacimiento = dtNacimiento.Value;
            string idsexo = cmbSexo.SelectedValue.ToString();
            string idtiposangre = cmbTipoSangre.SelectedValue.ToString();
            string alergias = txtAlergias.Text;
            string enfermedades = txtEnfermedades.Text;
            string cuadroVacunas = txtVacunas.Text;
            string antecedentes = txtAntecedentes.Text;
            

            bool exito = SQL.validarRequeridos(this.Controls, ERRORDATOS);
            if (!exito)
            {
                this.DialogResult = DialogResult.None;
                return;
            }
            int n = SQL.registrarYActualizarYEliminar("USPINSERTARPACIENTE", new System.Collections.ArrayList
            {
                "@NOMBRE ",
                "@APPATERNO",
                "@APMATERNO",
                "@EMAIL",
                "@DIRECCION",
                "@TELEFONOFIJO",
                "@TELEFONOCELULAR",
                "@FECHANACIMIENTO",
                "@IIDSEXO",
                "@IIDTIPOSANGRE",
                "@ALERGIAS",
                "@ENFERMEDADESCRONICAS",
                "@CUADRODEVACUNAS",
                "@ANTECENTES",
                "@FOTO"
            }, new System.Collections.ArrayList
            {
                nombre,
                apPaterno ,
                apmaterno,
                email,
                direccion,
                telefonoFijo,
                telefonoCell,
                fechaNacimiento,
                idsexo,
                idtiposangre,
                alergias,
                enfermedades,
                cuadroVacunas,
                antecedentes,
                buffer
            }
            ) ;
            if (n == 1)
            {
                MessageBox.Show("Successfully completed!");
            }
            else
            {
                MessageBox.Show("Registry found already!");
                this.DialogResult = DialogResult.None;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Fichiere d'échange | *.jpeg";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                string ruta = ofd.FileName;
                buffer = File.ReadAllBytes(ruta);
                //For a Preview of the photo.
                using(MemoryStream ms = new MemoryStream(buffer))
                {
                    pictureBox1.Image = Image.FromStream(ms);
                }
            }
        }

        private void cmbSexo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
