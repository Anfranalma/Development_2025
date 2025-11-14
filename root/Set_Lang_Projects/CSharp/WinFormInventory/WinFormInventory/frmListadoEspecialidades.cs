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

namespace WinFormInventory
{
    public partial class frmListadoEspecialidades : Form
    {
        public frmListadoEspecialidades()
        {
            InitializeComponent();
        }

        private void frmListadoEspecialidades_Load(object sender, EventArgs e)
        {
            SQL.ListarProcedureSQL("uspListarEspecialidades", dgvEspecialidad);

            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("uspListarEspecialidades", cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable table = new DataTable();
            //sda.Fill(table);
            //dgvEspecialidad.DataSource = table;

        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtFiltrar.Text;
            SQL.filtradosDatos("USPLISTARESPECIALIDADPORNOMBRE", "@NOMBRE", nombre, dgvEspecialidad);
        }
    }
}
