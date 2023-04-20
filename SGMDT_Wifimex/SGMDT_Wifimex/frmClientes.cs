using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace SGMDT_Wifimex
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
            cargarTabla();

        }
        public void cargarTabla()
        {
            DAOCliente dat = new DAOCliente();
            dgvClientes.DataSource = new DAOCliente().ObtenerTodos();
            dgvClientes.Columns["nomCliente"].HeaderText = "Nombre del cliente";
            dgvClientes.Columns["idCliente"].HeaderText = "Clave del Cliente";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModyCliente frm = new frmAddModyCliente("", 1);
            frm.ShowDialog();
            if (frm.modificado)
            {
                cargarTabla();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 1)
            {
                String idEmpleado = dgvClientes.SelectedRows[0].Cells["idCliente"].Value.ToString();
                frmAddModyCliente frm = new frmAddModyCliente(idEmpleado, 2);
                frm.ShowDialog();
                if (frm.modificado)
                {
                    cargarTabla();
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un elemento de la tabla editar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 1)
            {
                DialogResult dialog = MessageBox.Show("Estas a punto de eliminar al cliente \n\r" +
                                                     dgvClientes.SelectedRows[0].Cells["nomCliente"].Value.ToString() + ", ¿deseas contunuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes==dialog)
                {
                    bool resp = new DAOCliente().eliminar(dgvClientes.SelectedRows[0].Cells["idCliente"].Value.ToString());
                    if (resp) {
                        MessageBox.Show("Cliente eliminado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        cargarTabla();
                    }
                    else
                    {
                        MessageBox.Show("el cliente no se a podido eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un elemento de la tabla para continuar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtBus_TextChanged(object sender, EventArgs e)
        {
            if (txtBus.Text.Length >= 4)
            {
                DAOCliente dat = new DAOCliente();
                dgvClientes.DataSource = new DAOCliente().Buscar(txtBus.Text);
                dgvClientes.Columns["nomCliente"].HeaderText = "Nombre del cliente";
                dgvClientes.Columns["idCliente"].HeaderText = "Clave del Cliente";
            }
            else
            {
                cargarTabla();
            }
        }
    }
}
