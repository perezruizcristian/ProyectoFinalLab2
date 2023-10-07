using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoFinalLab.CDatos;
using System.Windows.Forms;

namespace ProyectoFinalLab.CLogica
{
    internal class ClsProducto
    {
        private int codigo;
        private string producto;
        private string modelo;
        private int cantidad;
        private double precioUnitario;
        private double precioTotal;

        public int Codigo { get => codigo; set => codigo = value; }
        public string Producto { get => producto; set => producto = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double PrecioUnitario { get => precioUnitario; set => precioUnitario = value; }
        public double PrecioTotal { get => precioTotal; set => precioTotal = value; }
        //Constructor
        public ClsProducto(int codigo, string producto, string modelo, int cantidad, double precioUnitario, double precioTotal)
        {
            Codigo = codigo;
            Producto = producto;
            Modelo = modelo;
            Cantidad = cantidad;
            PrecioUnitario = precioUnitario;
            PrecioTotal = precioTotal;
        }
                        //Vamos a tener 2 Constructores uno que recibe parametros y otro que no
                        //A esto se le llama sobrecarga de constructores
        //Costructor 2   
        public ClsProducto(){}//<-- este 2do constructor lo creo para poder instanciar
                              //la clase sin necesidad de pasarle parametros

        public void registrarVenta(ClsProducto producto_)
        {
            ClsDatosProducto productoD = new ClsDatosProducto();
            productoD.cargar_produc_Sql(producto_);
        }

        public DataTable mostrar_tabla()
        {
            ClsDatosProducto empleadoD = new ClsDatosProducto();
            DataTable tabla = new DataTable();
            tabla = empleadoD.tabla_producto();
            return tabla;
        }

        public ClsProducto SelectProducto(int id)//Seleciona un producto de la tabla stock 
        {
            ClsDatosProducto productoD = new ClsDatosProducto();
            ClsProducto oproducto = new ClsProducto();
            oproducto = productoD.selectorProductoStock(id);
            return oproducto;
        }


        public ClsProducto SelectProductoVentas(int id)
        {
            ClsDatosProducto productoD = new ClsDatosProducto();
            ClsProducto oproducto = new ClsProducto();
            oproducto = productoD.selectorProductoRegistroVentas(id);
            return oproducto;
        }


        public void CargarMod(ClsProducto p_empleado)
        {
            ClsDatosProducto ProductoD = new ClsDatosProducto();
            ProductoD.modificarDatosP(p_empleado);
        }

        public DataTable mostrar_tablaStock()
        {
            ClsDatosProducto empleadoD = new ClsDatosProducto();
            DataTable tabla = new DataTable();
            tabla = empleadoD.tablaStock();
            return tabla;
        }


        public double calculo(int cantidad,double precio)
        {
            return cantidad * precio;
        }


    }
}
