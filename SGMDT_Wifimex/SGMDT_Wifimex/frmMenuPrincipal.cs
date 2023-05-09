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
    /// Formulario de menu principal del programa el cual tiene varios boton
    /// que direccionaran a los diferentes menus de registros
    /// </summary>
    public partial class frmMenuPrincipal : Form
    {
        private String Idempelado,nombreCompleto;

        /// <summary>
        /// Evento del boton Empleados, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Empleados.
        /// </summary>
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = new frmEmpleados();
            frm.Show();
        }

        /// <summary>
        /// Evento del boton Instalaciones, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Instalaciones.
        /// </summary>
        private void btnInstalaciones_Click(object sender, EventArgs e)
        {
            frmInstalaciones frm = new frmInstalaciones();
            frm.Show();
        }

        /// <summary>
        /// Evento de cerrar el formulario, al cerrar el formulario
        /// se aplicacion o programa se cerrara.
        /// </summary>
        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Evento del boton Clientes, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Clientes.
        /// </summary>
        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.Show();
        }

        /// <summary>
        /// Evento del boton Contratos, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Contratos.
        /// </summary>
        private void btnContratos_Click(object sender, EventArgs e)
        {
            frmContratos frm = new frmContratos();
            frm.Show();
        }

        /// <summary>
        /// Evento del boton Alamacen, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Alamcen.
        /// </summary>
        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            frmAlmacen frm= new frmAlmacen();
            frm.Show();
        }

        /// <summary>
        /// Evento del boton Productos, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Productos.
        /// </summary>
        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.Show();
        }

        /// <summary>
        /// Evento del boton Proveedores, al dar click al boton
        /// abrira y direccionara al formulario principal de
        /// Proveedores.
        /// </summary>
        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frm = new frmProveedores();
            frm.Show();
        }

        /// <summary>
        /// Constructor del formulario que recibe dos parmaetros.
        /// </summary>
        /// <param name="idempleado">
        /// Parametro donde se alamcena el ID del empleado que esta usando el sistema.
        /// </param>
        /// <param name="nombrecompleto">
        /// Parametro donde se alamcena el ID del empleado que esta usando el sistema.
        /// </param>
        public frmMenuPrincipal(string idempleado, string nombrecompleto)
        {
            InitializeComponent();
                Idempelado = idempleado;
                nombreCompleto = nombrecompleto;
        }
    }
}
