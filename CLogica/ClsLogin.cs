using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinalLab.CDatos;
using System.Data;
using System.Windows.Forms;

namespace ProyectoFinalLab.CLogica
{
    internal class ClsLogin
    {
        public int logeo(string usuario, string contraseña)
        {
            ClsDatosLogin validarD = new ClsDatosLogin();
            int valid = validarD.Validacion(usuario, contraseña);
            return valid;
        }
    }
}
