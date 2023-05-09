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
    /// <summary>
    /// Formulario de menu principal de Clientes, donde se daran las opciones de agregar, actulizar,
    /// Buscar y elimnar registros de la tabla de Clientes.
    /// </summary>
    public partial class frmClientes : Form
    {
        /// <summary>
        /// Constructor del formulario donde se cargaran los controles que estaran visibles en 
        /// el formulario, tambien cargara los datos de de la tabla de almacen en una tabla para su
        /// visualizacion
        /// </summary>
        public frmClientes()
        {
            InitializeComponent();
            cargarTabla();

        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Clientes en una tabla del sistema
        /// haciendo una instancia del DAO de Clientes al metodo obtener todos los registros.
        /// </summary>
        public void cargarTabla()
        {
            DAOCliente dat = new DAOCliente();
            dgvClientes.DataSource = new DAOCliente().ObtenerTodos();
            dgvClientes.Columns["nomCliente"].HeaderText = "Nombre del cliente";
            dgvClientes.Columns["idCliente"].HeaderText = "Clave del Cliente";
        }

        /// <summary>
        /// evento del boton Añadir, al dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Clientes. haciendo una instancia del
        /// formulario de agregar/modificar Clientes, cundo se finalice
        /// el tramite de añadir un nuevo registro se volvera a cargar la tabla
        /// con los nuevos registros
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModyCliente frm = new frmAddModyCliente("", 1);
            frm.ShowDialog();
            if (frm.Agregado>0)
            {
                cargarTabla();
            }
        }

        /// <summary>
        /// evento del boton Modificar, al selecionar un registro
        /// de la tabla y dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Clientes. haciendo una instancia del
        /// formulario de agregar/modificar Clientes, cundo se finalice
        /// el tramite de modificar un registro se volvera a cargar la tabla
        /// con los registros actualizados.
        /// </summary>
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

        /// <summary>
        /// Evento del boton eliminar, al dar click a elminar se eliminara el registro selecionado
        /// de la tabla. Al selecionar un registro de la tabla y dar click a elimnar emergera un mensaje
        /// donde se pregunta si se quiere eliminar el registro, al selecionar si el registro se eliminara
        /// de la base de datos y cargara la tabla con los registros actializados, en caso de selecionar
        /// mo la accion se abortara y no habra  ningun cambio.
        /// </summary>
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

        /// <summary>
        /// Evento de caja de texto, cuando se escribe en la caja de texto,
        /// al escribir en la caja de texto llamara al metodo de buscar
        /// del DAO de clientes, si encuentra concidencias con algun registro
        /// de la base de datos de la tabla Clientes, cargara los registros que coicidan 
        /// en la tabla de sistema.
        /// </summary>
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
