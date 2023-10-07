using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalLab.CLogica;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ProyectoFinalLab.CDatos
{
    internal class ClsDatosLogin
    {
        string Conectar = "server=DESKTOP-IK1SH2C; database=TiendaZapatillas; integrated security=true";
        public int Validacion(string Usuariop, string Contraseñap)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(Conectar);
                conexion.Open();
                string cadena = $"Select * From Usuarios where Id = 1";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registroUsuario = comando.ExecuteReader();
                while (registroUsuario.Read())
                {
                    if (Usuariop == registroUsuario["Usuario"].ToString() && Contraseñap == registroUsuario["Contraseña"].ToString())
                    {
                        return 1;
                    }
                    else
                    {
                        MessageBox.Show("El Usuario o la Contraseña son incorrectos", "Usuario no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                conexion.Close();
                return 0;
            }
            catch
            {

                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }
    }
}
