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
        // Metodos que cargan la tabla
        public void CargarTablaAc()
        {
            dgvEmpleados.DataSource = new DAOEmpleados().ObtenerEmpleadosActivos();
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
        public void CargarTablaIn()
        {
            dgvEmpleados.DataSource = new DAOEmpleados().ObtenerEmpleadosInactivos();
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
        public void CargarTablaEm()
        {
            dgvEmpleados.DataSource = new DAOEmpleados().ObtenerEmpleado(txtBuscar.Text);
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
        // Manda al formulario de agergar o modificar usuario
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificar frm = new frmAgregarModificar(1, "0");
            frm.ShowDialog();
            if (frm.Guardado == 0)
            {
                CargarTabla();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                string idCategoria = dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value.ToString();
                frmAgregarModificar frm = new frmAgregarModificar(2, idCategoria);
                frm.ShowDialog();
                if (frm.Modificado)
                {
                    CargarTabla();
                }
            }
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            CargarTabla();
        }

        private void btnBusccar_Click(object sender, EventArgs e)
        {
            CargarTablaEm();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvEmpleados.SelectedRows.Count > 0)
            {
                String idEmleado = dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value.ToString();
                DialogResult resp = MessageBox.Show("Estas a punto de eliminar a " +
                                    (new DAOEmpleados().ObtenerUnEmpleado(idEmleado).Nombrecompleto) +
                                    " de las listas, ¿Deseas continuar?", "",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    if (new DAOEmpleados().EliminarEmpleado(idEmleado))
                    {
                        MessageBox.Show("Se a eliminado el empleado seleccionada", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTabla();
                    }
                }
            }
        }

        private void btnInactivos_Click(object sender, EventArgs e)
        {
            CargarTablaAc();
        }

        private void btnActivos_Click(object sender, EventArgs e)
        {
            CargarTablaIn();
        }
    }
}
