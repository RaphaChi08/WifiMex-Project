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
    /// Formulario de menu principal de Almacen, donde se daran las opciones de agregar, actulizar,
    /// Buscar y elimnar registros de la tabla de almacen.
    /// </summary>
    public partial class frmAlmacen : Form
    {
        /// <summary>
        /// Constructor del formulario donde se cargaran los controles que estaran visibles en 
        /// el formulario, tambien cargara los datos de de la tabla de almacen en una tabla para su
        /// visualizacion
        /// </summary>
        public frmAlmacen()
        {
            InitializeComponent();
            cargarTabla();
        }

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla almacen en una tabla del sistema
        /// haciendo una instancia del DAO de almacen al metodo obtener todos los registros.
        /// </summary>
        public void cargarTabla()
        {
            dgvAlmacen.DataSource= new DAOAlmacen().ObtenerTodos();
            dgvAlmacen.Columns["idAlmacen"].HeaderText = "Clave Almacen";
            dgvAlmacen.Columns["cantProducto"].HeaderText = "Cantidad en almacen";
            dgvAlmacen.Columns["codigoBarra"].HeaderText = "Clave Recurso";
            dgvAlmacen.Columns["idEmpleado"].HeaderText = "Clave empleado Encargado";
        }

        /// <summary>
        /// evento del boton Añadir, al dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de alamacen. haciendo una instancia del
        /// formulario de agregar/modificar alamcen, cundo se finalice
        /// el tramite de añadir un nuevo registro se volvera a cargar la tabla
        /// con los nuevos registros
        /// </summary>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddModyAlmacen frm= new  frmAddModyAlmacen("", 1);
            frm.ShowDialog();
            if (frm.Agregado>0)
            {
                cargarTabla();
            }
        }

        /// <summary>
        /// evento del boton Modificar, al selecionar un registro
        /// de la tabla y dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de alamacen. haciendo una instancia del
        /// formulario de agregar/modificar alamcen, cundo se funalice
        /// el tramite de modificar un registro se volvera a cargar la tabla
        /// con los registros actualizados.
        /// </summary>
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

        /// <summary>
        /// Evento del boton eliminar, al dar click a elminar se eliminara el registro selecionado
        /// de la tabla. Al selecionar un registro de la tabla y dar click a elimnar emergera un mensaje
        /// donde se pregunta si se quiere eliminar el registro, al selecionar si el registro se eliminara
        /// de la base de datos y cargara la tabla con los registros actializados, en caso de selecionar
        /// mo la accion se abortara y no habra  ningun cambio.
        /// </summary>
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscar.Text.Length >= 4)
            {
                dgvAlmacen.DataSource = new DAOAlmacen().Buscar(txtBuscar.Text);
                dgvAlmacen.Columns["idAlmacen"].HeaderText = "Clave Almacen";
                dgvAlmacen.Columns["cantProducto"].HeaderText = "Cantidad en almacen";
                dgvAlmacen.Columns["codigoBarra"].HeaderText = "Clave Recurso";
                dgvAlmacen.Columns["idEmpleado"].HeaderText = "Clave empleado Encargado";
            }
            else
            {
                cargarTabla();
            }
        }
    }
}
