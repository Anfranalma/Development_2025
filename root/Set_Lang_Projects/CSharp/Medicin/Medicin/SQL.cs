using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Collections;

namespace Medicin
{
    public class SQL
    {
        //clase utilitaria para ahorrar tiempo de logica
        private static SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
        public  static void ListarConsultaSQL(string consulta, DataGridView grilla)
        {
            SqlCommand cmd = new SqlCommand(consulta,cn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            sda.Fill(tabla);
            grilla.DataSource = tabla;
        }

        public static void ListarProcedureSQL(string nombreProcedure, DataGridView grilla)
        {
            
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable tabla = new DataTable();
            sda.Fill(tabla);
            grilla.DataSource = tabla;
        }

        public static void FiltradoDatos(string nombreProcedure, string nombreParametro, string valorParametro, DataGridView grilla)
        {
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue(nombreParametro,valorParametro);
            DataTable tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tabla);
            grilla.DataSource = tabla;
        }

        public static void llenarComboBox(string nombreProcedure, ComboBox combo, string displayMemeber="NOMBRE", string valueMemeber="Id", bool primerValor = false)
        {
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable tabla = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(tabla);
            if (primerValor == true)
            {
                DataRow fila=tabla.NewRow();
                fila[0] = 0;
                fila[1] = "--Slectione--";
                tabla.Rows.InsertAt(fila, 0);

            }
            combo.DataSource = tabla;
            combo.DisplayMember = displayMemeber;
            combo.ValueMember = valueMemeber;
        }

        public static int registrarYActualizarYEliminar(string nombreProcedure, ArrayList parametros,ArrayList valores)
        {
            SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["cnx"].ConnectionString);
            cn.Open();
            SqlCommand cmd = new SqlCommand(nombreProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            for(int i =0; i< parametros.Count; i++)
            {
                cmd.Parameters.AddWithValue(parametros[i].ToString(), valores[i]);
            }
            int result = cmd.ExecuteNonQuery();
            cn.Close();
            return result;
        }

        public static bool validarRequeridos(Control.ControlCollection controles, ErrorProvider error)
        {
            bool exito = true;
            int ncontroles = controles.Count;
            Control control;
            for(int i=0; i < ncontroles; i++)
            {
                control = controles[i];
                if(control is TextBox)
                {
                    if(control.Tag != null && control.Tag.ToString().Equals("O")){
                        if (((TextBox)control).Text.Equals(""))
                        {
                            error.SetError(control, "INGRESE  DATOS");
                            exito = false;
                        }
                        else
                        {
                            error.SetError(control, "");
                        }
                    } 
                }
                else if (control is NumericUpDown)
                {
                    if (control.Tag != null && control.Tag.ToString().Equals("O"))
                    {
                        if (((NumericUpDown)control).Value.Equals(0))
                        {
                            error.SetError(control, "INGRESE  DATOS");
                            exito = false;
                        }
                        else
                        {
                            error.SetError(control, "");
                        }
                    }
                }
                else if (control is PictureBox)
                {
                    if (control.Tag != null && control.Tag.ToString().Equals("O"))
                    {
                        if (((PictureBox)control).Image==null)
                        {
                            error.SetError(control, "INGRESE  DATOS");
                            exito = false;
                        }
                        else
                        {
                            error.SetError(control, "");
                        }
                    }
                }
                else if (control is ComboBox)
                {
                    if (control.Tag != null && control.Tag.ToString().Equals("O"))
                    {
                        if (((ComboBox)control).SelectedValue.ToString().Equals("0"))
                        {
                            error.SetError(control, "INGRESE  DATOS");
                            exito = false;
                        }
                        else
                        {
                            error.SetError(control, "");
                        }
                    }
                }
            }
            return exito;
        }
    }
}
