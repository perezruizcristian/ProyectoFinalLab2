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
    internal class ClsDatosFactura
    {
        string sqlconect = "server=DESKTOP-IK1SH2C; database=TiendaZapatillas; integrated security = true";
        public DataTable busquedaFactura(int id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                string cadena = $"Select Producto,Modelo,Cantidad,[Precio unitario],[Precio total] From Producto where Codigo = {id}";
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
