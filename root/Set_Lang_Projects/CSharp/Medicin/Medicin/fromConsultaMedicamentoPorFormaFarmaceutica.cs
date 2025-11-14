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
    public partial class fromConsultaMedicamentoPorFormaFarmaceutica : Form
    {
        public fromConsultaMedicamentoPorFormaFarmaceutica()
        {
            InitializeComponent();
        }

        private void fromConsultaMedicamentoPorFormaFarmaceutica_Load(object sender, EventArgs e)
        {
            SQL.llenarComboBox("spLlenarComboFormaFarmaceutica", cmbListado);
            SQL.ListarProcedureSQL("USPLISTARMEDICAMENTOS", dgvMedicamento);
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("spLlenarComboFormaFarmaceutica", cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //DataTable tabla = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(tabla);
            //cmbListado.DataSource = tabla;
            //cmbListado.DisplayMember = "NOMBRE";
            //cmbListado.ValueMember = "Id";
        }

        private void Filtrar(object sender, EventArgs e)
        {
            //string idforma = cmbListado.SelectedValue.ToString(); //Check this error later!!!!!
            SQL.FiltradoDatos("USPLCONSULTARMEDICAMENTOSPORFORMAFARMACEUTICA", "@IIDFORMAFARMACEUTICA", "2", dgvMedicamento);
        }
    }
}
