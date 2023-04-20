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
    public partial class frmContratos : Form
    {
        public frmContratos()
        {
            InitializeComponent();
            CargarTabla();
        }

        public void CargarTabla()
        {
            dgvContratos.DataSource= new DAOContratos().ObtenerTodos();
            dgvContratos.Columns["idContrato"].HeaderText = "Clave del contrato";
            dgvContratos.Columns["precioServicio"].HeaderText = "Costo por el servicio";
            dgvContratos.Columns["inicioContrato"].HeaderText = "Inicio del contrato";
            dgvContratos.Columns["finContrato"].HeaderText = "Fin del contrato";
            dgvContratos.Columns["idCliente"].HeaderText = "Clave del cliente";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModyContratos frm = new frmAddModyContratos("", 1);
            frm.ShowDialog();
            if (frm.Agregado>0)
            {
                CargarTabla();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvContratos.SelectedRows.Count == 1)
            {
                String idEmpleado = dgvContratos.SelectedRows[0].Cells["idContrato"].Value.ToString();
                frmAddModyContratos frm = new frmAddModyContratos(idEmpleado, 2);
                frm.ShowDialog();
                if (frm.modificado)
                {
                    CargarTabla();
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un elemento de la tabla editar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvContratos.SelectedRows.Count == 1)
            {
                DialogResult dialog = MessageBox.Show("Estas a punto de eliminar el contrato \n\r" +
                                                     dgvContratos.SelectedRows[0].Cells["idContrato"].Value.ToString() + ", ¿deseas contunuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dialog)
                {
                    bool resp = new DAOContratos().eliminar(dgvContratos.SelectedRows[0].Cells["idContrato"].Value.ToString());
                    if (resp)
                    {
                        MessageBox.Show("Contrato eliminado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        CargarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El Contrato no se a podido eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                dgvContratos.DataSource = new DAOContratos().Buscar(txtBus.Text);
                dgvContratos.Columns["idContrato"].HeaderText = "Clave del contrato";
                dgvContratos.Columns["precioServicio"].HeaderText = "Costo por el servicio";
                dgvContratos.Columns["inicioContrato"].HeaderText = "Inicio del contrato";
                dgvContratos.Columns["finContrato"].HeaderText = "Fin del contrato";
                dgvContratos.Columns["idCliente"].HeaderText = "Clave del cliente";
            }
            else
            {
                CargarTabla();
            }
        }
    }
}
