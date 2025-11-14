using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;

namespace WinFormInventory
{
    public class SQL
    {
        private static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);

        public static void ListarConsultaSQL(string consulta, DataGridView grilla)
        {
            SqlCommand cmd = new SqlCommand(consulta,cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            sda.Fill(table);
            grilla.DataSource = table;
        }

        public static void ListarProcedureSQL(string nombreProcedure, DataGridView grilla)
        {
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable table = new DataTable();
            sda.Fill(table);
            grilla.DataSource = table;
        }

        public static void filtradosDatos(string nombreProcedure, string nombreParametro, string valorParametro, DataGridView grilla)
        {
            //SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure; //esto hara que se ejectue mucho mas rapido
            cmd.Parameters.AddWithValue(nombreParametro, valorParametro);
            DataTable tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tabla);
            grilla.DataSource = tabla;
        }
    }
}
