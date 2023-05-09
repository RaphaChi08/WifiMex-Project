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
    /// Formulario de menu principal de Empleados, donde se daran las opciones de agregar, actulizar,
    /// Buscar y elimnar registros de la tabla de Empleados.
    /// </summary>
    public partial class frmEmpleados : Form
    {
        /// <summary>
        /// Constructor del formulario donde se cargaran los controles que estaran visibles en 
        /// el formulario, tambien cargara los datos de de la tabla de Empleados en una tabla para su
        /// visualizacion
        /// </summary>
        public frmEmpleados()
        {
            InitializeComponent();
            CargarTabla();
        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Empleados en una tabla del sistema
        /// haciendo una instancia del DAO de Empleados al metodo obtener todos los registros
        /// que esten en estado activos.
        /// </summary>
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

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Empleados en una tabla del sistema
        /// haciendo una instancia del DAO de Empleados al metodo obtener todos los registros.
        /// </summary>
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
        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Empleados en una tabla del sistema
        /// haciendo una instancia del DAO de Empleados al metodo obtener todos los registros
        /// en estado inactivos.
        /// </summary>
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

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Empleados en una tabla del sistema
        /// haciendo una instancia del DAO de Empleados al metodo obtener todos los registros.
        /// </summary>
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

        /// <summary>
        /// evento del boton Añadir, al dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Empleados. haciendo una instancia del
        /// formulario de agregar/modificar Empleados, cundo se finalice
        /// el tramite de añadir un nuevo registro se volvera a cargar la tabla
        /// con los nuevos registros
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregarModificar frm = new frmAgregarModificar(1, "0");
            frm.ShowDialog();
            if (frm.Guardado == 0)
            {
                CargarTabla();
            }
        }

        /// <summary>
        /// evento del boton Modificar, al selecionar un registro
        /// de la tabla y dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Empleados. haciendo una instancia del
        /// formulario de agregar/modificar Empleados, cundo se finalice
        /// el tramite de modificar un registro se volvera a cargar la tabla
        /// con los registros actualizados.
        /// </summary>
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

        /// <summary>
        /// Evento de boton mostrar todo, cuando se da click a este boton
        /// mostrara todos los registros de la tabla empleados sin importar
        /// si estan activos o inactivos
        /// </summary>
        private void btnTodos_Click(object sender, EventArgs e)
        {
            CargarTabla();
        }

        /// <summary>
        /// Evento de boton buscar, cuando se da click a este boton
        /// mostrara todos el registro que concida con lo que esta en la
        /// caja de texto de la tabla empleados sin importar
        /// si estan activos o inactivos
        /// </summary>
        private void btnBusccar_Click(object sender, EventArgs e)
        {
            CargarTablaEm();
        }

        /// <summary>
        /// Evento del boton eliminar, al dar click a elminar se eliminara el registro selecionado
        /// de la tabla. Al selecionar un registro de la tabla y dar click a elimnar emergera un mensaje
        /// donde se pregunta si se quiere eliminar el registro, al selecionar si el registro se eliminara
        /// de la base de datos y cargara la tabla con los registros actializados, en caso de selecionar
        /// mo la accion se abortara y no habra  ningun cambio.
        /// </summary>
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

        /// <summary>
        /// Evento de boton mostrar todo, cuando se da click a este boton
        /// mostrara todos los registros de la tabla empleados inactivos
        /// </summary>
        private void btnInactivos_Click(object sender, EventArgs e)
        {
            CargarTablaAc();
        }

        /// <summary>
        /// Evento de boton mostrar todo, cuando se da click a este boton
        /// mostrara todos los registros de la tabla empleados inactivos
        /// </summary>
        private void btnActivos_Click(object sender, EventArgs e)
        {
            CargarTablaIn();
        }
    }
}
