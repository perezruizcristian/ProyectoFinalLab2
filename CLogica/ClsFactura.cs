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
    public class ClsFactura
    {
        public DataTable mostrarFacturaBuscada(int idp)
        {
            ClsDatosFactura facturaD = new ClsDatosFactura();
            DataTable tabla = new DataTable();
            tabla = facturaD.busquedaFactura(idp);
            return tabla;
        }



        public int NumCliente()
        {
            Random r = new Random();
            int geneRand = r.Next(50000,60000);            
            return geneRand;
        }
    }
}
