using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    /// <summary>
    /// Formulario que agrega y modifica los registros de la tabla Productos
    /// </summary>
    public partial class frmAgregar_ModificarProductos : Form
    {
        /// <summary>
        /// Variables que sirven para validar la opcion que se mostrara en el formulario
        /// ya se Agregar o modificar.
        /// </summary>
        private int OP;
        private string codigo;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }

        /// <summary>
        /// Metodo que sirve para validar que las cajas de texto del formulario tengan
        /// el formato correcto que se solicita
        /// </summary>
        /// <returns>
        /// regresa un true si los formatos de las cajas de texto son validos en caso de
        /// lo contrario regresa un false.
        /// </returns>
        public bool Verificar()
        {
            if (!Regex.IsMatch(txtCodigo.Text, "^[0-9]{12}$"))
            {
                errorProvider1.SetError(txtCodigo, "El formato debe contener 12 numeros");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtNombre.Text, @"^[A-Za-z][A-Za-z .0-9]{1,}$"))
            {
                errorProvider1.SetError(txtNombre, "El nombre no puede contener números o caracteres especiales");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }


            return true;
        }

        /// <summary>
        /// Costrcutor del formulario donde cargan todos los controles que
        /// estan dentro del formulario.
        /// </summary>
        /// <param name="codigoBarra">
        /// Parametro que resive el constructor en caso de que se de la opcion de modificar
        /// un registro para buscar el registro a modificar
        /// </param>
        /// <param name="op">
        /// Parametro que indica cuales controles tiene que cargar el formulario
        /// este indica si el fomulario tiene que ponerse en modo de agregar un
        /// nuevo registro o en mode de modificar un registro ya existente.
        /// </param>
        public frmAgregar_ModificarProductos(int op, string codigoBarra)
        {
            InitializeComponent();
            this.OP = op;
            this.codigo = codigoBarra;
            if (op == 1)
            {
                this.Text = "Registrar";
                lblTitulo.Text = "Registrar productos";
                List<Proveedores> prov = new DAOProveedores().ObtenerProveedoresActivos();
                cbxProveedor.DataSource = prov;
                cbxProveedor.DisplayMember = "nomProveedores";
                cbxProveedor.ValueMember = "idProveedores";
                //cbxProveedor.SelectedIndex = 1;
            }
            else if (op == 2)
            {
                this.Text = "Modificar";
                Productos ints = new DAOProductos().ObtenerUnProducto(codigo);
                lblTitulo.Text = "Modificar productos";
                txtCodigo.Text = ints.codigoBarra.ToString();
                txtCodigo.Enabled = false;
                txtNombre.Text = ints.nomProducto;
                dtpFecha.Enabled = false;
                List<Proveedores> prov = new DAOProveedores().ObtenerProveedoresActivos();
                cbxProveedor.DataSource = prov;
                cbxProveedor.DisplayMember = "nomProveedores";
                cbxProveedor.ValueMember = "idProveedores";
                cbxProveedor.SelectedValue=ints.idProveedores;
            }
        }

        /// <summary>
        /// Evento click de boton, al dar click mandara y guardara el nuevo registro o modificara
        /// un registro ya existente.
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de Productos
        /// asi como al DAO Productos para poder utiliazar el metodo de agregar un nuevo registro.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de Productos.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0 & txtNombre.Text.Length > 0)
            {
                if (OP == 1)
                {
                    Productos Inst = new Productos();
                    Inst.codigoBarra = txtCodigo.Text;
                    Inst.nomProducto = txtNombre.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.idProveedores = cbxProveedor.SelectedValue.ToString();
                    Inst.nomProveedor = cbxProveedor.SelectedText;
                    Inst.Estatus = true;
                    if (Verificar())
                    {
                        Guardado = new DAOProductos().AgregarProducto(Inst);
                        if (Guardado > 0)
                        {
                            MessageBox.Show("Se ha guardado exitosamente el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Producto ya registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (OP == 2)
                {
                    Productos Inst = new Productos();
                    Inst.codigoBarra = txtCodigo.Text;
                    Inst.nomProducto = txtNombre.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.idProveedores = cbxProveedor.SelectedValue.ToString();
                    Inst.nomProveedor = cbxProveedor.SelectedText;
                    Inst.Estatus = true;
                    if (Verificar())
                    {
                        Modificado = new DAOProductos().ModificarProducto(Inst);
                        if (Modificado)
                        {
                            MessageBox.Show("Se ha actualizado exitosamente el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        /// <summary>
        /// Evento de boton cancer, al dar click al boton cierra la ventan y regresa al menu principal
        /// de Productos.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
