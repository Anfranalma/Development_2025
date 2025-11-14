using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Medicin
{
    public partial class frmListadoEspcialidad : Form
    {
        public frmListadoEspcialidad()
        {
            InitializeComponent();
        }

        private void frmListadoEspcialidad_Load(object sender, EventArgs e)
        {
            SQL.ListarProcedureSQL("uspListarEspecialidades", dgvEspecialidad);
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("uspListarEspecialidades",cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable tabla = new DataTable();
            //sda.Fill(tabla);
            //dgvEspecialidad.DataSource = tabla;
        }

        private void filtrar(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text;
            SQL.FiltradoDatos("spListarEspecialidadPorNombre", "@NOMBRE", nombre, dgvEspecialidad);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }
    }
}
