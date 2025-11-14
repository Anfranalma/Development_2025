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
    public partial class frmListadoClinica : Form
    {
        public frmListadoClinica()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SQL.ListarConsultaSQL("select IIDCLINICA, NOMBRE, DIRECCION from clinica WHERE BHABILITADO = 1", dgv1);
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("select IIDCLINICA,NOMBRE,DIRECCION from clinica WHERE BHABILITADO =1", cn);
            //DataTable tabla = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd); //execute the script we send throught the sqlcommand
            //sda.Fill(tabla); //llena el dataAdapter
            //dgv1.DataSource = tabla;//save the dataTable on the datagrid view.
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string idclinica = txtIDClinica.Text;
            SQL.FiltradoDatos("uspFiltrarClinicaPorId", "@idclinica", idclinica, dgv1);
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            //SqlCommand cmd = new SqlCommand("uspFiltrarClinicaPorId",cn);
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@idclinica", idclinica);
            //DataTable tabla = new DataTable();
            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //sda.Fill(tabla);
            //dgv1.DataSource = tabla;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Listar();
            txtIDClinica.Text = "";
        }

        private void Listar()
        {
            SQL.ListarConsultaSQL("select IIDCLINICA, NOMBRE, DIRECCION from clinica WHERE BHABILITADO = 1", dgv1);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPopUpClinica ofrmPopUpClinica = new frmPopUpClinica();
            ofrmPopUpClinica.accion = "Nuevo";
            ofrmPopUpClinica.ShowDialog();
            if (ofrmPopUpClinica.DialogResult.Equals(DialogResult.OK))
            {
                Listar();
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmPopUpClinica ofrmPopUpClinica = new frmPopUpClinica();
            ofrmPopUpClinica.accion = "Editar";
            ofrmPopUpClinica.ShowDialog();
        }
    }
}
