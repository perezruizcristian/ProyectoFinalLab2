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
    internal class ClsEmpleado
    {
        private int id;
        private string nombre;
        private string apellido;
        private string telefono;
        private string email;
        private string puesto;
        private double sueldo;
        private int faltas;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Email { get => email; set => email = value; }
        public string Puesto { get => puesto; set => puesto = value; }
        public double Sueldo { get => sueldo; set => sueldo = value; }
        public int Faltas { get => faltas; set => faltas = value; }


        public DataTable mostrar_tabla()
        {
            ClsDatosEmpleado empleadoD = new ClsDatosEmpleado();
            DataTable tabla = new DataTable();
            tabla = empleadoD.tabla_empleado();
            return tabla;
        }

        public void guardar(ClsEmpleado p_empleado)
        {
            ClsDatosEmpleado Empleadop = new ClsDatosEmpleado();
            Empleadop.cargar_en_Sql(PasarDatos(p_empleado));
        }

        public ClsEmpleado SelectEmpleado(int id)
        {
            ClsDatosEmpleado empleadoD = new ClsDatosEmpleado();
            ClsEmpleado oempleado = new ClsEmpleado();
            oempleado = empleadoD.selectorEmpleado(id);
            return oempleado;
        }

        public void CargarMod(ClsEmpleado p_empleado)
        {
            ClsDatosEmpleado EmpleadoD = new ClsDatosEmpleado();
            EmpleadoD.modificarDatos(PasarDatos(p_empleado));
        }

        public ClsDatosEmpleado PasarDatos(ClsEmpleado p_Empleado)
        {
            ClsDatosEmpleado empleadoD = new ClsDatosEmpleado();
            empleadoD.Id_D = p_Empleado.Id;
            empleadoD.Nombre_D = p_Empleado.Nombre;
            empleadoD.Apellido_D = p_Empleado.Apellido;
            empleadoD.Telefono_D = p_Empleado.Telefono;
            empleadoD.Email_D = p_Empleado.Email;
            empleadoD.Puesto_D = p_Empleado.Puesto;
            empleadoD.Sueldo_D = p_Empleado.Sueldo;
            empleadoD.Faltas_D = p_Empleado.Faltas;
            return empleadoD;
        }

        public void EliminarEmpleado(ClsEmpleado p_empleado)
        {
            ClsDatosEmpleado EmpleadoD = new ClsDatosEmpleado();
            EmpleadoD.eliminarEmpleado(PasarDatos(p_empleado));
        }

        public DataTable mostrarEmpleadoBuscado(int idp)
        {
            ClsDatosEmpleado empleadoD = new ClsDatosEmpleado();
            DataTable tabla = new DataTable();
            tabla = empleadoD.busquedaEmpleado(idp);
            return tabla;
        }
    }
}
