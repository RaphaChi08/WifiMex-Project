using Datos;
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
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
            CargarTabla();
        }
        public void CargarTabla()
        {
            dgvEmpleados.DataSource = new DAOEmpleados().ObtenerEmpleados();
            dgvEmpleados.Columns["idEmpleado"].Visible = false;
            dgvEmpleados.Columns["Nombrecompleto"].HeaderText = "Nombre Empleado";
            dgvEmpleados.Columns["RFC"].HeaderText = "RFC";
            dgvEmpleados.Columns["CURP"].HeaderText = "CURP";
            dgvEmpleados.Columns["Edad"].Visible = false;
            dgvEmpleados.Columns["Direccion"].Visible = false;
            dgvEmpleados.Columns["Telefono"].HeaderText = "Telefono";
            dgvEmpleados.Columns["Correo"].HeaderText = "Correo";
            dgvEmpleados.Columns["fechaContratacion"].HeaderText = "Fecha de Contratacion";
            dgvEmpleados.Columns["Rol"].HeaderText = "Rol";
            dgvEmpleados.Columns["Password"].Visible = false;
            dgvEmpleados.Columns["Estatus"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}
