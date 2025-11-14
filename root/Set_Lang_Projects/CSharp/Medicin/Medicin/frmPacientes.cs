using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Medicin
{
    public partial class frmPacientes : Form
    {
        public string accion { get; set; }

        public string id { get; set; }
        public frmPacientes()
        {
            InitializeComponent();
        }

        private void frmPacientes_Load(object sender, EventArgs e)
        {
            cmbListado.SelectedIndex = 0;
            SQL.ListarProcedureSQL("uspListarPacientesPrograma", dgvListado);
        }

        private void filtrar(object sender, EventArgs e)
        {
            string opcion = cmbListado.Text;
            string valor = txtValor.Text;
            if (opcion.Equals("Nombre"))
            {
                SQL.FiltradoDatos("uspConsultarPacientesProgramaPorNombre", "@nombre", valor, dgvListado);
            }else if (opcion.Equals("Apellido Paterno"))
            {
                SQL.FiltradoDatos("uspConsultarPacientesProgramaPorApPaterno", "@apPaterno", valor, dgvListado);
            }
            else
            {
                SQL.FiltradoDatos("uspConsultarPacientesProgramaPorApMaterno", "@apMaterno", valor, dgvListado);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPopUpPaciente ofrmPopUpPaciente = new frmPopUpPaciente();
            ofrmPopUpPaciente.accion = "Nuevo";
            ofrmPopUpPaciente.ShowDialog();
            if (ofrmPopUpPaciente.DialogResult.Equals(DialogResult.OK)){
                SQL.ListarProcedureSQL("uspListarPacientesPrograma", dgvListado);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmPopUpPaciente ofrmPopUpPaciente = new frmPopUpPaciente();
            ofrmPopUpPaciente.accion = "Editar";
            ofrmPopUpPaciente.ShowDialog();
        }
    }
}
