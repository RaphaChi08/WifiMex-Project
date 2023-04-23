using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            DAOEmpleados dao = new DAOEmpleados();
            Empleados empleados = dao.IniciarSeccion(txtUsuario.Text, txtPassword.Text);
            if (empleados != null)
            {
                MessageBox.Show("Bienvenido usuario " + empleados.Idempleado);
                frmMenuPrincipal ini = new frmMenuPrincipal(empleados.Idempleado, empleados.Nombrecompleto);
                ini.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario y/o Contraseña incorrectos");
            }
        }
    }
}
