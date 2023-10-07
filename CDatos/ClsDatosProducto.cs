using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using ProyectoFinalLab.CLogica;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProyectoFinalLab.CDatos
{
    internal class ClsDatosProducto
    {
        string sqlconect = "server=DESKTOP-IK1SH2C; database=TiendaZapatillas; integrated security = true";
        public void cargar_produc_Sql(ClsProducto productop)
        {  
            try
            {  
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                string producto = productop.Producto;
                string modelo= productop.Modelo;
                int cantidad = productop.Cantidad;
                double precioU = productop.PrecioUnitario;
                double precioTotal = productop.PrecioTotal;
                string cadena = "INSERT INTO Producto(Producto,Modelo,Cantidad,[Precio unitario],[Precio total])" +
                    "VALUES('" + producto + "','" +modelo + "','" + cantidad + "','" + precioU + "','" + precioTotal + "')";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro cargado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public DataTable tabla_producto()
        {//Creamos una funcion de tipo tabla
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                string cadena = "Select * From Producto";
                SqlDataReader leer_filasSQL; //SqlDataReader <-- Lee un flujo de filas unicamente de SQL
                DataTable tabla_SQL = new DataTable();// Creamos un objeto te tipo tabla
                SqlCommand comando = new SqlCommand(cadena, conexion);
                leer_filasSQL = comando.ExecuteReader();//<-- se guarda el comando executado la variable leer Filas
                tabla_SQL.Load(leer_filasSQL);//<-- Se lee las filas guardadas en la variable 
                conexion.Close();
                return tabla_SQL;//<-- Retornamos la tabla cargada
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }


        public ClsProducto selectorProductoStock(int id)
        {  
            try
            {
                ClsProducto productoSelecionado = new ClsProducto();
                SqlConnection conexion = new SqlConnection(sqlconect);
                string cadena = $"select * from StockProducto where Codigo = {id}";
                conexion.Open();
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registroProducto = comando.ExecuteReader();
                while (registroProducto.Read())//<-- Mientras tenga filas almacenadas va a continuar dentro del while
                {   //cada una de estas lineas lee un registro de la fila selecionada
                    productoSelecionado.Codigo = Convert.ToInt32(registroProducto["Codigo"].ToString());
                    productoSelecionado.Producto = registroProducto["Producto"].ToString();
                    productoSelecionado.Modelo = registroProducto["Modelo"].ToString();
                    productoSelecionado.PrecioUnitario = Convert.ToDouble(registroProducto["PrecioUnitario"].ToString());
                   // productoSelecionado.PrecioTotal = Convert.ToDouble(registroProducto["Precio total"].ToString());
                }
                conexion.Close();
                return productoSelecionado;
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }


        public ClsProducto selectorProductoRegistroVentas(int id)
        {
            try
            {
                ClsProducto productoSelecionado = new ClsProducto();
                SqlConnection conexion = new SqlConnection(sqlconect);
                string cadena = $"select * from Producto where Codigo = {id}";
                conexion.Open();
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registroProducto = comando.ExecuteReader();
                while (registroProducto.Read())//<-- Mientras tenga filas almacenadas va a continuar dentro del while
                {   //cada una de estas lineas lee un registro de la fila selecionada
                    productoSelecionado.Codigo = Convert.ToInt32(registroProducto["Codigo"].ToString());
                    productoSelecionado.Producto = registroProducto["Producto"].ToString();
                    productoSelecionado.Modelo = registroProducto["Modelo"].ToString();
                    productoSelecionado.Cantidad = int.Parse(registroProducto["Cantidad"].ToString());
                    productoSelecionado.PrecioUnitario = Convert.ToDouble(registroProducto["Precio unitario"].ToString());
                    productoSelecionado.PrecioTotal = Convert.ToDouble(registroProducto["Precio total"].ToString());
                }
                conexion.Close();
                return productoSelecionado;
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }


        public void modificarDatosP(ClsProducto p_empleado)
        {

            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                int SelecId = p_empleado.Codigo;
                string producto = p_empleado.Producto;
                string modelo = p_empleado.Modelo;
                int cantidad = p_empleado.Cantidad;
                double precioUnitario = p_empleado.PrecioUnitario;
                double precioTotal = p_empleado.PrecioTotal;
                string cadena = "UPDATE Producto SET Producto ='" + producto + "', Modelo ='" + modelo +
                    "',Cantidad ='" + cantidad + "',[Precio unitario] ='" + precioUnitario + "',[Precio total] =" +
                    "'"+precioTotal+"' where Codigo =" + SelecId + " ";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
                MessageBox.Show("Registro modificado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public DataTable tablaStock()
        {//Creamos una funcion de tipo tabla
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                string cadena = "Select * From StockProducto";
                SqlDataReader leer_filasSQL; //SqlDataReader <-- Lee un flujo de filas unicamente de SQL
                DataTable tabla_SQL = new DataTable();// Creamos un objeto te tipo tabla
                SqlCommand comando = new SqlCommand(cadena, conexion);
                leer_filasSQL = comando.ExecuteReader();//<-- se guarda el comando executado la variable leer Filas
                tabla_SQL.Load(leer_filasSQL);//<-- Se lee las filas guardadas en la variable 
                conexion.Close();
                return tabla_SQL;//<-- Retornamos la tabla cargada
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }



    }
}
