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
    public partial class frmInstalaciones : Form
    {
        public frmInstalaciones()
        {
            InitializeComponent();
            CargarTablaAc();
        }
        public void CargarTablaAc()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalacionesActivos();
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }
        public void CargarTablaIn()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalacionesInactivos();
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }
        public void CargarTabla()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalaciones();
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }
        public void CargarTablaIns()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalacion(txtBuscar.Text);
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificarInsta frm = new frmAgregarModificarInsta(1, "0");
            frm.ShowDialog();
            if (frm.Guardado > 0)
            {
                CargarTabla();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvInstalaciones.SelectedRows.Count > 0)
            {
                string idCategoria = dgvInstalaciones.SelectedRows[0].Cells["IdInstalacion"].Value.ToString();
                frmAgregarModificar frm = new frmAgregarModificar(2, idCategoria);
                frm.ShowDialog();
                if (frm.Modificado)
                {
                    CargarTabla();
                }
            }
        }
    }
}
