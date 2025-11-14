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
    public partial class frmListadoMedicamentos : Form
    {
        public frmListadoMedicamentos()
        {
            InitializeComponent();
        }

        private void frmListadoMedicamentos_Load(object sender, EventArgs e)
        {
            rdNombre.Checked = true; //seleccionar uno por defecto
            SQL.ListarProcedureSQL("uspListarMedicamentoPrograma", dgvMedicamentos);
        }

        private void filtrar(object sender, EventArgs e)
        {
            string valor = txtValor.Text;
            if (rdNombre.Checked == true)
            {
                SQL.FiltradoDatos("uspConsultarMedicamentoProgramaPorNombre", "@nombre", valor, dgvMedicamentos);
            }
            else
            {
                SQL.FiltradoDatos("uspConsultarMedicamentoProgramaPorConcentracion", "@concentration", valor, dgvMedicamentos);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPopUpMedicamentos ofrmPopUpMedicmantos = new frmPopUpMedicamentos();
            ofrmPopUpMedicmantos.accion = "Nuevo";
            ofrmPopUpMedicmantos.ShowDialog();
            if (ofrmPopUpMedicmantos.DialogResult.Equals(DialogResult.OK))
            {
                SQL.ListarProcedureSQL("uspListarMedicamentoPrograma", dgvMedicamentos);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            frmPopUpMedicamentos ofrmPopUpMedicmantos = new frmPopUpMedicamentos();
            ofrmPopUpMedicmantos.accion = "Editar";
            ofrmPopUpMedicmantos.ShowDialog();
        }
    }
}
