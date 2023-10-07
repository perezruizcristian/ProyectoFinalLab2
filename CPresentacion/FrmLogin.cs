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
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {

        }

        

        private void butingresar_Click_1(object sender, EventArgs e)
        {
            //Boton Ingresar Login
            if (String.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Debe ingresar su Usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (String.IsNullOrEmpty(txtContraseña.Text))
                {
                    MessageBox.Show("Debe ingresar una Contraseña", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ClsLogin Verificar = new ClsLogin();
                    int valid = Verificar.logeo(txtUsuario.Text, txtContraseña.Text);
                    if (valid == 1)
                    {
                        Form menu = new FrmMenuAdmin();
                        menu.Show();
                        this.Hide();
                    }
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
