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
    /// <summary>
    /// Formulario de menu principal de Empleados, donde se daran las opciones de agregar, actulizar y
    /// Buscar registros de la tabla de Instalaciones.
    /// </summary>
    public partial class frmInstalaciones : Form
    {
        /// <summary>
        /// Constructor del formulario donde se cargaran los controles que estaran visibles en 
        /// el formulario, tambien cargara los datos de de la tabla de Instalaciones en una tabla para su
        /// visualizacion
        /// </summary>
        public frmInstalaciones()
        {
            InitializeComponent();
            CargarTablaAc();
        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Instalaciones en una tabla del sistema
        /// haciendo una instancia del DAO de Instalaciones al metodo obtener todos los registros
        /// que esten en estado activos.
        /// </summary>
        public void CargarTablaAc()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalacionesActivos();
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Instalaciones en una tabla del sistema
        /// haciendo una instancia del DAO de Instalaciones al metodo obtener todos los registros
        /// en estado inactivos.
        /// </summary>
        public void CargarTablaIn()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalacionesInactivos();
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Instalaciones en una tabla del sistema
        /// haciendo una instancia del DAO de Instalaciones al metodo obtener todos los registros.
        /// </summary>
        public void CargarTabla()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalaciones();
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Instalaciones en una tabla del sistema
        /// haciendo una instancia del DAO de Instalaciones al metodo obtener todos los registros.
        /// </summary>
        public void CargarTablaIns()
        {
            dgvInstalaciones.DataSource = new DAOInstalaciones().ObtenerInstalacion(txtBuscar.Text);
            dgvInstalaciones.Columns["IdInstalacion"].HeaderText = "ID Instalaciones";
            dgvInstalaciones.Columns["fechaInstalacin"].HeaderText = "Fecha de Instalacion";
            dgvInstalaciones.Columns["idEmpelado"].HeaderText = "ID Empleado";
            dgvInstalaciones.Columns["idContratos"].HeaderText = "ID Conntrato";
            dgvInstalaciones.Columns["Estatus"].Visible = false;
        }

        /// <summary>
        /// evento del boton Añadir, al dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Instalaciones. haciendo una instancia del
        /// formulario de agregar/modificar Instalaciones, cundo se finalice
        /// el tramite de añadir un nuevo registro se volvera a cargar la tabla
        /// con los nuevos registros
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificarInsta frm = new frmAgregarModificarInsta(1, "0");
            frm.ShowDialog();
            if (frm.Guardado == 0)
            {
                CargarTabla();
            }
        }

        /// <summary>
        /// evento del boton Modificar, al selecionar un registro
        /// de la tabla y dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Instalaciones. haciendo una instancia del
        /// formulario de agregar/modificar Instalaciones, cundo se finalice
        /// el tramite de modificar un registro se volvera a cargar la tabla
        /// con los registros actualizados.
        /// </summary>
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (dgvInstalaciones.SelectedRows.Count > 0)
            {
                string idCategoria = dgvInstalaciones.SelectedRows[0].Cells["IdInstalacion"].Value.ToString();
                frmAgregarModificarInsta frm = new frmAgregarModificarInsta(2, idCategoria);
                frm.ShowDialog();
                if (frm.Modificado)
                {
                    CargarTabla();
                }
            }
        }

        /// <summary>
        /// Evento de boton buscar, cuando se da click a este boton
        /// mostrara todos el registro que concida con lo que esta en la
        /// caja de texto de la tabla empleados sin importar
        /// si estan activos o inactivos
        /// </summary>
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarTablaIns();
        }
    }
}
