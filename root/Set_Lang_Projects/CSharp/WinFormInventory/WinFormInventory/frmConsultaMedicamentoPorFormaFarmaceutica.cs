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
    public partial class frmConsultaMedicamentoPorFormaFarmaceutica : Form
    {
        public frmConsultaMedicamentoPorFormaFarmaceutica()
        {
            InitializeComponent();
        }

        private void frmConsultaMedicamentoPorFormaFarmaceutica_Load(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            SqlCommand cmd = new SqlCommand("USPLLENARCOMBOFORMAFARMACEUTICA", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tabla);
            cboFormaFarmaceutica.DataSource = tabla;
            cboFormaFarmaceutica.DisplayMember = "NOMBRE"; 
            cboFormaFarmaceutica.ValueMember = "IIDFORMAFARMACEUTICA";
        }
    }
}
