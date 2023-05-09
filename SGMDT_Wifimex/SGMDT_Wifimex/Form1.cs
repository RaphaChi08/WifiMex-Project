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
    /// <summary>
    /// Formulario con el Longin del sistema
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>
        /// Constrcutor que inicializa el formulario cargando todos los controles en el formulario
        /// </summary>
        public frmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento del boton Ingresar, al dar click intentara ingresar al sisteama.
        /// en este evento se hace una referencia al DAO de Empleados y al modelo de Empleados
        /// para hacer una consulta y validacion con las cajas de texto del formulario
        /// en caso de que la informacion que este en las cajas de texto concida con un 
        /// registro de la tabla de Empleados dara acceso al sistema, en caso de lo contrario
        /// denegara el acceso al sistema.
        /// </summary>
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
