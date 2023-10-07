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
    public partial class FrmVentas : Form
    {
        public FrmVentas()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, EventArgs e)//Tabla
        {//Instanciamos el constructor que no recibe parametros, para solamente llamar al metrodo de mostrar tabla 
            ClsProducto objEmpleado = new ClsProducto();
            dgvVentas.DataSource = objEmpleado.mostrar_tabla();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {//Instanciamos el constructor que recibe parametros para cargarlos a la base de datos
            ClsProducto oProducto = new ClsProducto(
                0,
                txtProducto.Text,
                txtModelo.Text,
                Convert.ToInt32(txtCantidad.Text),
                Convert.ToDouble(txtPrecioUnitario.Text),
                Convert.ToDouble(txtPrecioTotal.Text));
            oProducto.registrarVenta(oProducto);
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtModelo.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            txtPrecioTotal.Text = "";
        }


        private void btnCalcular_Click(object sender, EventArgs e)
        {
            ClsProducto oProducto = new ClsProducto();
            txtPrecioTotal.Text= (oProducto.calculo(int.Parse(txtCantidad.Text),
                double.Parse(txtPrecioUnitario.Text))).ToString();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ClsProducto oproducto = new ClsProducto();
            ClsProducto oproducto1 = new ClsProducto();
            oproducto1 = oproducto.SelectProducto(Convert.ToInt32(txtCodigo.Text));
            txtCodigo.Enabled = false;
            txtCodigo.Text = oproducto1.Codigo.ToString();
            txtProducto.Text = oproducto1.Producto;
            txtModelo.Text = oproducto1.Modelo;
            txtPrecioUnitario.Text = oproducto1.PrecioUnitario.ToString();
        }

        private void btnModific_Click(object sender, EventArgs e)
        {
            ClsProducto produc = new ClsProducto(
                Convert.ToInt32(txtCodigo.Text),
                txtProducto.Text,
                txtModelo.Text,
                Convert.ToInt32(txtCantidad.Text),
                Convert.ToDouble(txtPrecioUnitario.Text),
                Convert.ToDouble(txtPrecioTotal.Text));
            produc.CargarMod(produc);
           
            txtCodigo.Enabled = true;
            txtCodigo.Text = "";
            txtProducto.Text = "";
            txtModelo.Text = "";
            txtCantidad.Text = "";
            txtPrecioUnitario.Text = "";
            txtPrecioTotal.Text = "";
        }

        private void btnFactura_Click(object sender, EventArgs e)
        {
            Form menuFactura = new FrmFactura();
            menuFactura.Show();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBusc_Registro_Click(object sender, EventArgs e)
        {
            ClsProducto oproducto = new ClsProducto();
            ClsProducto oproducto1 = new ClsProducto();
            oproducto1 = oproducto.SelectProductoVentas(Convert.ToInt32(txtCodigo.Text));
            txtCodigo.Enabled = false;
            txtCodigo.Text = oproducto1.Codigo.ToString();
            txtProducto.Text = oproducto1.Producto;
            txtModelo.Text = oproducto1.Modelo;
            txtCantidad.Text = oproducto1.Cantidad.ToString();
            txtPrecioUnitario.Text = oproducto1.PrecioUnitario.ToString();
            txtPrecioTotal.Text = oproducto1.PrecioTotal.ToString();
        }
        
    }
}
