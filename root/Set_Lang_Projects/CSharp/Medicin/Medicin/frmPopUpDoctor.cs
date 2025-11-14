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
    public partial class frmPopUpDoctor : Form
    {
        public string accion { get; set; }
        public string id { get; set; }

        public frmPopUpDoctor()
        {
            InitializeComponent();
        }

        private void btnExplore_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo de Programa | *.pdf;*.png;*.jpg;*.jpeg;*.docx";
            if (ofd.ShowDialog().Equals(DialogResult.OK))
            {
                string ruta = ofd.FileName;
                wbArchivo.Navigate(ruta);
            }
        }
    }
}
