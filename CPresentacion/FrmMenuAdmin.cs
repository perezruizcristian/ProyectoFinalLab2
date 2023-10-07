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
    public partial class FrmMenuAdmin : Form
    {
        public FrmMenuAdmin()
        {
            InitializeComponent();
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {

            ClsEmpleado objEmpleado = new ClsEmpleado();
            dgvPrincipal.DataSource = objEmpleado.mostrar_tabla();

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Form menuventas = new FrmVentas();
            menuventas.Show();
        }

      
        private void btnRegEmpleado_Click(object sender, EventArgs e)
        {
            Form Registrar = new FrmRegistro();
            Registrar.Show();
        }

        private void btnSalirSistema_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnStock_Click(object sender, EventArgs e)
        {
            ClsProducto objProducto = new ClsProducto();
            dgvPrincipal.DataSource = objProducto.mostrar_tablaStock();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClsEmpleado objEmpleado = new ClsEmpleado();
            dgvPrincipal.DataSource = objEmpleado.mostrarEmpleadoBuscado(int.Parse(txtBuscar.Text));
        }
    }
}
