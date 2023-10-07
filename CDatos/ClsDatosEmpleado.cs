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
    internal class ClsDatosEmpleado
    {
        private int id_D;
        private string nombre_D;
        private string apellido_D;
        private string telefono_D;
        private string email_D;
        private string puesto_D;
        private double sueldo_D;
        private int faltas_D;
        public int Id_D { get => id_D; set => id_D = value; }
        public string Nombre_D { get => nombre_D; set => nombre_D = value; }
        public string Apellido_D { get => apellido_D; set => apellido_D = value; }
        public string Telefono_D { get => telefono_D; set => telefono_D = value; }
        public string Email_D { get => email_D; set => email_D = value; }
        public string Puesto_D { get => puesto_D; set => puesto_D = value; }
        public double Sueldo_D { get => sueldo_D; set => sueldo_D = value; }
        public int Faltas_D { get => faltas_D; set => faltas_D = value; }

        //creamos una variable de tipo string para guardar en la misma 
        //La conexion con SQL server de esta manera no sera necesario escribirla todo el tiempo
        string sqlconect = "server=DESKTOP-IK1SH2C; database=TiendaZapatillas; integrated security = true";
        public void cargar_en_Sql(ClsDatosEmpleado empleadoD)
        {   // Se crea una funcion void, que recibe parametros 
            //En el cual el parametro es el objeto con los datos ya cargados
            try//<-- try: se utiliza para intentar conectarse a la base de datos si no se conecta, no entra al try
            {   //va por el "catch"

                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                //Abrimos la conexion y guardamos dentro de variables locale
                //Los datos del objeto de ta capa logica
                string nombre = empleadoD.nombre_D;
                string apellido = empleadoD.apellido_D;
                string telefono = empleadoD.telefono_D;
                string email = empleadoD.email_D;
                string puesto = empleadoD.puesto_D;
                double sueldo = empleadoD.sueldo_D;
                int faltas = empleadoD.faltas_D;
                //Creamos una variable En la cual almacenamos una texto el cual en este caso es el 
                //comando SQL para Insertar un nuevo Empleado
                string cadena = "INSERT INTO Empleados(Nombre,Apellido,Telefono,Email,Puesto,Sueldo,Faltas)" +
                    "VALUES('" + nombre + "','" + apellido + "','" + telefono + "','" + email + "','" + puesto + "','" + sueldo + "','" + faltas + "')";
                SqlCommand comando = new SqlCommand(cadena, conexion);//<--Envia el comando y la conexion
                comando.ExecuteNonQuery();//<-- Executa el comando enviado
                conexion.Close();//Cerramos conexion
                MessageBox.Show("Empleado registrado exitosamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {//si la conexion no es exitosa :
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }// El catch es una función que se utiliza para identificar errores en código, al intentar ejecutar cierto código,
             // en el caso de ocurrir un error, se ejecuta el catch, el cual ejecutará una excepción que nos avisará del error,
             // pudiendo así identificar con más facilidad el lugar donde ocurrió.
        }

        //Muestra tabla de empleados
        public DataTable tabla_empleado()
        {//Creamos una funcion de tipo tabla
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                string cadena = "Select * From Empleados";
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


        //Selecciona un Empleado de la tabla y lo envia a una funcion de capa logica, la cual envia por parametros 
        //el objeto con los atributos, para insertar c/u de los atributos en los txt
        public ClsEmpleado selectorEmpleado(int id)
        {   //Este metodo recibe un entero como paramentro
            //Creamos un metodo de tipo empleado para retornarle un objeto
            try
            {
                ClsEmpleado empleadoSelecionado = new ClsEmpleado();
                SqlConnection conexion = new SqlConnection(sqlconect);
                //El parametro el cual se recibio es el id del empleado seleccionado
                string cadena = $"Select * From Empleados where Id ={id}";
                conexion.Open();
                SqlCommand comando = new SqlCommand(cadena, conexion);
                SqlDataReader registroEmpleado = comando.ExecuteReader();
                while (registroEmpleado.Read())//<-- Mientras tenga filas almacenadas va a continuar dentro del while
                {   //cada una de estas lineas lee un registro de la fila selecionada
                    empleadoSelecionado.Id = Convert.ToInt32(registroEmpleado["Id"].ToString());
                    empleadoSelecionado.Nombre = registroEmpleado["Nombre"].ToString();
                    empleadoSelecionado.Apellido = registroEmpleado["Apellido"].ToString();
                    empleadoSelecionado.Telefono = registroEmpleado["Telefono"].ToString();
                    empleadoSelecionado.Email = registroEmpleado["Email"].ToString();
                    empleadoSelecionado.Puesto = registroEmpleado["Puesto"].ToString();
                    empleadoSelecionado.Sueldo = Convert.ToDouble(registroEmpleado["Sueldo"].ToString());
                    empleadoSelecionado.Faltas = Convert.ToInt32(registroEmpleado["Faltas"].ToString());
                }
                conexion.Close();
                return empleadoSelecionado;
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }


        public void modificarDatos(ClsDatosEmpleado p_empleado)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                int SelectorId = p_empleado.id_D;
                string nombre = p_empleado.Nombre_D;
                string apellido = p_empleado.Apellido_D;
                string telefono = p_empleado.Telefono_D;
                string email = p_empleado.Email_D;
                string puesto = p_empleado.Puesto_D;
                double sueldo = p_empleado.Sueldo_D;
                int faltas = p_empleado.Faltas_D;
                string cadena = "UPDATE Empleados SET Nombre ='" + nombre + "', Apellido ='" + apellido +
                    "',Telefono ='" + telefono + "',Email ='" + email + "',Puesto ='" + puesto +
                    "',Sueldo =" + sueldo + ",Faltas =" + faltas + " where Id =" + SelectorId + " ";
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

        public void eliminarEmpleado(ClsDatosEmpleado EmpleadoDp)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                int id = EmpleadoDp.id_D;
                string nombre = EmpleadoDp.nombre_D;
                string apellido = EmpleadoDp.apellido_D;
                string telefono = EmpleadoDp.telefono_D;
                string email = EmpleadoDp.email_D;
                string puesto = EmpleadoDp.puesto_D;
                double sueldo = EmpleadoDp.sueldo_D;
                int faltas = EmpleadoDp.faltas_D;
                string cadena = $"delete from Empleados where Id = {id} and Nombre='{nombre}'" +
                    $" and Apellido ='{apellido}' and Telefono = '{telefono}' and Email = '{email}'" +
                    $" and Puesto ='{puesto}' and Sueldo = {sueldo} and Faltas= {faltas}";
                SqlCommand comando = new SqlCommand(cadena, conexion);
                comando.ExecuteNonQuery();
                conexion.Close();
            }
            catch
            {
                MessageBox.Show("Hubo un error en el intento de Conexion", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable busquedaEmpleado(int id)
        {
            try
            {
                SqlConnection conexion = new SqlConnection(sqlconect);
                conexion.Open();
                string cadena = $"Select * From Empleados where Id = {id}";
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
