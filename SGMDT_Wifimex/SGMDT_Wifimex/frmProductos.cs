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
    // <summary>
    /// Formulario de menu principal de Productos, donde se daran las opciones de agregar, actulizar,
    /// Buscar y elimnar registros de la tabla de Productos.
    /// </summary>
    public partial class frmProductos : Form
    {
        /// <summary>
        /// Constructor del formulario donde se cargaran los controles que estaran visibles en 
        /// el formulario, tambien cargara los datos de de la tabla de Productos en una tabla para su
        /// visualizacion
        /// </summary>
        public frmProductos()
        {
            InitializeComponent();
            CargarTablaAc();
        }

        /// <summary>
        /// evento del boton Añadir, al dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Productos. haciendo una instancia del
        /// formulario de agregar/modificar Productos, cundo se finalice
        /// el tramite de añadir un nuevo registro se volvera a cargar la tabla
        /// con los nuevos registros
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            frmAgregar_ModificarProductos frm = new frmAgregar_ModificarProductos(1, "0");
            frm.ShowDialog();
            if (frm.Guardado > 0)
            {
                CargarTablaAc();
            }
        }

        /// <summary>
        /// evento del boton Modificar, al selecionar un registro
        /// de la tabla y dar click en este boton abrira la ventana de
        /// agrega/modificar un registro de Productos. haciendo una instancia del
        /// formulario de agregar/modificar Productos, cundo se finalice
        /// el tramite de modificar un registro se volvera a cargar la tabla
        /// con los registros actualizados.
        /// </summary>
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

        /// <summary>
        /// Evento del boton eliminar, al dar click a elminar se eliminara el registro selecionado
        /// de la tabla. Al selecionar un registro de la tabla y dar click a elimnar emergera un mensaje
        /// donde se pregunta si se quiere eliminar el registro, al selecionar si el registro se eliminara
        /// de la base de datos y cargara la tabla con los registros actializados, en caso de selecionar
        /// mo la accion se abortara y no habra  ningun cambio.
        /// </summary>
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

        /// <summary>
        /// Evento de boton buscar, cuando se da click a este boton
        /// mostrara todos el registro que concida con lo que esta en la
        /// caja de texto de la tabla Productos sin importar
        /// si estan activos o inactivos
        /// </summary>
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

        /// <summary>
        /// Mentodo que sirve para cargar los datos de la tabla Productos en una tabla del sistema
        /// haciendo una instancia del DAO de Productos al metodo obtener todos los registros
        /// que esten en estado activos.
        /// </summary>
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
