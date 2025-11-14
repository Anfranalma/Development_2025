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

namespace WinFormInventory
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Inicializar();

            //string consulta = "select IIDCLINICA, NOMBRE ,DIRECCION from clinica WHERE BHABILITADO=1";
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd = new SqlCommand(consulta, cn);
            //DataTable table = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(table);
            //dgvClinica.DataSource = table;
        }

        private void Inicializar()
        {
            SQL.ListarConsultaSQL("select IIDCLINICA, NOMBRE ,DIRECCION from clinica WHERE BHABILITADO=1", dgvClinica);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string idclinica = txtIdClinica.Text;
            SQL.filtradosDatos("uspFiltrarClinicaPorId", "@idclinica", idclinica, dgvClinica);
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd =new SqlCommand("uspFiltrarClinicaPorId", cn);
            //cmd.CommandType = CommandType.StoredProcedure; //esto hara que se ejectue mucho mas rapido
            //cmd.Parameters.AddWithValue("idclinica", idclinica);
            //DataTable tabla = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(tabla);
            //dgvClinica.DataSource = tabla;

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Inicializar();
            txtIdClinica.Clear();
        }
    }
}
