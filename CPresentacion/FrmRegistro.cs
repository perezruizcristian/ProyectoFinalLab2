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
    public partial class FrmRegistro : Form
    {
        public FrmRegistro()
        {
            InitializeComponent();
        }

        //------------------------FUNCIONES------------------------------

        private ClsEmpleado guardarEmpleado()
        {
            ClsEmpleado oempleado = new ClsEmpleado();
            oempleado.Nombre = txtNombre.Text;
            oempleado.Apellido = txtApellido.Text;
            oempleado.Telefono = txtTelefono.Text;
            oempleado.Email = txtEmail.Text;
            oempleado.Puesto = txtPuesto.Text;
            oempleado.Sueldo = Convert.ToDouble(txtSueldo.Text);
            oempleado.Faltas = Convert.ToInt32(txtFaltas.Text);
            return oempleado;
        }

        private ClsEmpleado pasarClogica()
        {
            ClsEmpleado oempleado = new ClsEmpleado();
            oempleado.Id = Convert.ToInt32(txtLegajo.Text);
            oempleado.Nombre = txtNombre.Text;
            oempleado.Apellido = txtApellido.Text;
            oempleado.Telefono = txtTelefono.Text;
            oempleado.Email = txtEmail.Text;
            oempleado.Puesto = txtPuesto.Text;
            oempleado.Sueldo = Convert.ToDouble(txtSueldo.Text);
            oempleado.Faltas = Convert.ToInt32(txtFaltas.Text);
            return oempleado;
        }

        private void butcancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmRegistro_Load(object sender, EventArgs e)
        {

        }


        private void btnGuardarEmpleado_Click(object sender, EventArgs e)
        {
            ClsEmpleado oempleado = new ClsEmpleado();
            oempleado.guardar(guardarEmpleado());
            guardarEmpleado();
            txtLegajo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtPuesto.Text = "";
            txtSueldo.Text = "";
            txtFaltas.Text = "";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClsEmpleado oempleado = new ClsEmpleado();
            ClsEmpleado oempleado1 = new ClsEmpleado();
            oempleado1 = oempleado.SelectEmpleado(Convert.ToInt32(txtLegajo.Text));
            txtLegajo.Enabled = false;
            txtLegajo.Text = oempleado1.Id.ToString();
            txtNombre.Text = oempleado1.Nombre;
            txtApellido.Text = oempleado1.Apellido;
            txtTelefono.Text = oempleado1.Telefono;
            txtEmail.Text = oempleado1.Email;
            txtPuesto.Text = oempleado1.Puesto;
            txtSueldo.Text = oempleado1.Sueldo.ToString();
            txtFaltas.Text = oempleado1.Faltas.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            ClsEmpleado empleado = new ClsEmpleado();
            empleado.CargarMod(pasarClogica());
            pasarClogica();
            txtLegajo.Enabled = true;
            txtLegajo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtPuesto.Text = "";
            txtSueldo.Text = "";
            txtFaltas.Text = "";
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            ClsEmpleado oEmpleado = new ClsEmpleado();
            oEmpleado.EliminarEmpleado(pasarClogica());
            pasarClogica();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtLegajo.Enabled=true;
            txtLegajo.Text = "";
            txtNombre.Text = "";
            txtApellido.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtPuesto.Text = "";
            txtSueldo.Text = "";
            txtFaltas.Text = "";
        }
    }
}
