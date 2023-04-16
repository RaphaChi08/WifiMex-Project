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

        public frmMenuPrincipal(string idempleado, string nombrecompleto)
        {
            InitializeComponent();
                Idempelado = idempleado;
                nombreCompleto = nombrecompleto;
        }
    }
}
