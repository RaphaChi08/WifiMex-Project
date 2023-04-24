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
    public partial class frmProveedores : Form
    {
        public frmProveedores()
        {
            InitializeComponent();
            CargarTablaAc();
        }

        public void CargarTablaAc()
        {
            dgvProveedores.DataSource = new DAOProveedores().ObtenerProveedoresActivos();
            dgvProveedores.Columns["idProveedores"].Visible = false;
            dgvProveedores.Columns["nomProveedores"].HeaderText = "Proveedor";
            dgvProveedores.Columns["fechaRegistro"].HeaderText = "Registro";
            dgvProveedores.Columns["Estatus"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar_ModificarProveedores frm = new frmAgregar_ModificarProveedores(1, "0");
            frm.ShowDialog();
            if (frm.Guardado > 0)
            {
                CargarTablaAc();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                string idProveedor = dgvProveedores.SelectedRows[0].Cells["idProveedores"].Value.ToString();
                frmAgregar_ModificarProveedores frm = new frmAgregar_ModificarProveedores(2, idProveedor);
                frm.ShowDialog();
                if (frm.Modificado)
                {
                    CargarTablaAc();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProveedores.SelectedRows.Count > 0)
            {
                String idProveedor = dgvProveedores.SelectedRows[0].Cells["idProveedores"].Value.ToString();
                DialogResult resp = MessageBox.Show("Estas a punto de eliminar a " +
                                    (new DAOProveedores().ObtenerUnProveedor(idProveedor).nomProveedores) +
                                    " del registro, ¿Deseas continuar?", "",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    if (new DAOProveedores().EliminarProveedor(idProveedor))
                    {
                        MessageBox.Show("Se a eliminado el proveedor seleccionado", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTablaAc();
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DAOProveedores prov = new DAOProveedores();
            dgvProveedores.DataSource = new DAOProveedores().Buscar(txtBuscar.Text);
            dgvProveedores.Columns["idProveedores"].Visible = false;
            dgvProveedores.Columns["nomProveedores"].HeaderText = "Proveedor";
            dgvProveedores.Columns["fechaRegistro"].HeaderText = "Registro";
            dgvProveedores.Columns["Estatus"].Visible = false;
            txtBuscar.Text = "";
        }
    }
}
