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
    public partial class frmAlmacen : Form
    {
        public frmAlmacen()
        {
            InitializeComponent();
            cargarTabla();
        }

        public void cargarTabla()
        {
            dgvAlmacen.DataSource= new DAOAlmacen().ObtenerTodos();
            dgvAlmacen.Columns["idAlmacen"].HeaderText = "Clave Almacen";
            dgvAlmacen.Columns["cantProducto"].HeaderText = "Cantidad en almacen";
            dgvAlmacen.Columns["codigoBarra"].HeaderText = "Clave Recurso";
            dgvAlmacen.Columns["idEmpleado"].HeaderText = "Clave empleado Encargado";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModyAlmacen frm= new  frmAddModyAlmacen("", 1);
            frm.ShowDialog();
            if (frm.Agregado>0)
            {
                cargarTabla();
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            if (dgvAlmacen.SelectedRows.Count == 1)
            {
                String idEmpleado = dgvAlmacen.SelectedRows[0].Cells["idAlmacen"].Value.ToString();
                frmAddModyAlmacen frm = new frmAddModyAlmacen(idEmpleado, 2);
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
            if (dgvAlmacen.SelectedRows.Count == 1)
            {
                DialogResult dialog = MessageBox.Show("Estas a punto de eliminar al Almacen con clave  \n\r" +
                                                     dgvAlmacen.SelectedRows[0].Cells["idAlmacen"].Value.ToString() + ", ¿deseas contunuar?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == dialog)
                {
                    bool resp = new DAOAlmacen().eliminar(dgvAlmacen.SelectedRows[0].Cells["idAlmacen"].Value.ToString());
                    if (resp)
                    {
                        MessageBox.Show("Almacen eliminado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Question);
                        cargarTabla();
                    }
                    else
                    {
                        MessageBox.Show("El Almacen no se a podido eliminar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Se debe seleccionar un elemento de la tabla para continuar", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
