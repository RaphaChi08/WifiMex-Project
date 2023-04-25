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
    public partial class frmProductos : Form
    {
        public frmProductos()
        {
            InitializeComponent();
            CargarTablaAc();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar_ModificarProductos frm = new frmAgregar_ModificarProductos(1, "0");
            frm.ShowDialog();
            if (frm.Guardado > 0)
            {
                CargarTablaAc();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                string codigoBarra = dgvProductos.SelectedRows[0].Cells["codigoBarra"].Value.ToString();
                frmAgregar_ModificarProductos frm = new frmAgregar_ModificarProductos(2, codigoBarra);
                frm.ShowDialog();
                if (frm.Modificado)
                {
                    CargarTablaAc();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count > 0)
            {
                string codigo = dgvProductos.SelectedRows[0].Cells["codigoBarra"].Value.ToString();
                DialogResult resp = MessageBox.Show("Estas a punto de borrar a " +
                                    (new DAOProductos().ObtenerUnProducto(codigo).nomProducto) +
                                    " del registro, ¿Deseas continuar?", "",
                                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resp == DialogResult.Yes)
                {
                    if (new DAOProductos().EliminarProducto(codigo))
                    {
                        MessageBox.Show("Se ha borrado exitosamente el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarTablaAc();
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecciona un registro primero", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DAOProductos prov = new DAOProductos();
            dgvProductos.DataSource = new DAOProductos().Buscar(txtBuscar.Text);
            dgvProductos.Columns["codigoBarra"].Visible = false;
            dgvProductos.Columns["nomProducto"].HeaderText = "Producto";
            dgvProductos.Columns["fechaRegistro"].HeaderText = "Registro";
            dgvProductos.Columns["idProveedores"].Visible = false;
            dgvProductos.Columns["nomProveedor"].HeaderText = "Proveedor";
            dgvProductos.Columns["Estatus"].Visible = false;
            txtBuscar.Text = "";
            MessageBox.Show("Búsqueda exitosa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void CargarTablaAc()
        {
            dgvProductos.DataSource = new DAOProductos().ObtenerProductosActivos();
            dgvProductos.Columns["codigoBarra"].Visible = false;
            dgvProductos.Columns["nomProducto"].HeaderText = "Producto";
            dgvProductos.Columns["fechaRegistro"].HeaderText = "Registro";
            dgvProductos.Columns["idProveedores"].Visible = false;
            dgvProductos.Columns["nomProveedor"].HeaderText = "Proveedor";
            dgvProductos.Columns["Estatus"].Visible = false;
        }
    }
}
