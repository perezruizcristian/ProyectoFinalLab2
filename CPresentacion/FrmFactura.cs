using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoFinalLab.CLogica;

namespace ProyectoFinalLab.CPresentacion
{
    public partial class FrmFactura : Form
    {
        public FrmFactura()
        {
            InitializeComponent();
        }


        private void FrmFactura_Load(object sender, EventArgs e)
        {
            ClsFactura oCliente = new ClsFactura();
            txtCliente.Text = Convert.ToString(oCliente.NumCliente());
        }


        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            ClsFactura objFactura = new ClsFactura();
            dgvFactura.DataSource = objFactura.mostrarFacturaBuscada(int.Parse(txtCodigoFactura.Text));
            
        }
    }
}
