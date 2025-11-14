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
    public partial class frmListadoDoctor : Form
    {
        public frmListadoDoctor()
        {
            InitializeComponent();
        }

        private void frmListadoDoctor_Load(object sender, EventArgs e)
        {
            rdPaterno.Checked = true;
            SQL.ListarProcedureSQL("uspListarDoctorPrograma", dgvDoctor);
        }

        private void filtrar(object sender, EventArgs e)
        {
            string valor = txtValor.Text;
            if(rdPaterno.Checked == true)
            {
                SQL.FiltradoDatos("uspConsultaDoctorPorApPaterno", "@apPaterno", valor, dgvDoctor);
            }
            else
            {
                SQL.FiltradoDatos("uspConsultaDoctorPorApMaterno", "@apMaterno", valor, dgvDoctor);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            frmPopUpDoctor ofrmPopUpDoctor = new frmPopUpDoctor();
            ofrmPopUpDoctor.accion = "Nuevo";
            ofrmPopUpDoctor.ShowDialog();
            //if (ofrmPopUpDoctor.DialogResult.Equals(DialogResult.OK))
            //{
            //    SQL.ListarProcedureSQL("uspListarMedicamentoPrograma", dgvMedicamentos);
            //}
        }
    }
}
