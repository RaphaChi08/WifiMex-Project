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
    public partial class frmMenuPrincipal : Form
    {
        private String Idempelado,nombreCompleto;

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            frmEmpleados frm = new frmEmpleados();
            frm.Show();
        }

        private void btnInstalaciones_Click(object sender, EventArgs e)
        {
            frmInstalaciones frm = new frmInstalaciones();
            frm.Show();
        }

        private void frmMenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            frmClientes frm = new frmClientes();
            frm.Show();
        }

        private void btnContratos_Click(object sender, EventArgs e)
        {
            frmContratos frm = new frmContratos();
            frm.Show();
        }

        private void btnAlmacen_Click(object sender, EventArgs e)
        {
            frmAlmacen frm= new frmAlmacen();
            frm.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            frmProductos frm = new frmProductos();
            frm.Show();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            frmProveedores frm = new frmProveedores();
            frm.Show();
        }

        public frmMenuPrincipal(string idempleado, string nombrecompleto)
        {
            InitializeComponent();
                Idempelado = idempleado;
                nombreCompleto = nombrecompleto;
        }
    }
}
