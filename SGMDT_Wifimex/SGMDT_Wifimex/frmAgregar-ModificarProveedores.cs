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
    /// Formulario que agrega y modifica los registros de la tabla Proveedores
    /// </summary>
    public partial class frmAgregar_ModificarProveedores : Form
    {
        /// Variables que sirven para validar la opcion que se mostrara en el formulario
        /// ya se Agregar o modificar.
        /// </summary>
        private int OP;
        private string ID;
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
            if (!Regex.IsMatch(txtClave.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtClave, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtNombre.Text, @"^[A-Za-z][A-Za-z .]{1,}[A-Za-z]$"))
            {
                errorProvider1.SetError(txtNombre, "El nombre no puede contener números o caracteres especiales");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtRFC.Text, @"^[A-Z]{4}\d{6}([A-Z0-9]{2}[A-Z0-9]{1})?$"))
            {
                errorProvider1.SetError(txtRFC, "Verifique que su RFC este correcto");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtDireccion.Text, @"^[A-Za-z][A-Za-z .]{1,}\s+#\d+(-\d+)?$"))
            {
                errorProvider1.SetError(txtDireccion, "Siga al formato adecuado , ejemplo : 'Calle #123', en caso de ser departamento agregue '-Número interior'");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtTelefono.Text, @"^[0-9]{10}?$"))
            {
                errorProvider1.SetError(txtTelefono, "Verifique el número contenga 10 dígitos");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtCorreo.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(txtCorreo, "Verifique en correo este correctamente escrito y sin espacios");
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
        /// <param name="id">
        /// Parametro que resive el constructor en caso de que se de la opcion de modificar
        /// un registro para buscar el registro a modificar
        /// </param>
        /// <param name="op">
        /// Parametro que indica cuales controles tiene que cargar el formulario
        /// este indica si el fomulario tiene que ponerse en modo de agregar un
        /// nuevo registro o en mode de modificar un registro ya existente.
        /// </param>
        public frmAgregar_ModificarProveedores(int op, string id)
        {
            InitializeComponent();
            this.OP = op;
            if (op == 1)
            {
                this.Text = "Registrar";
                lblTitulo.Text = "Registrar proveedores";
            }
            else if (op == 2)
            {
                this.Text = "Modificar";
                lblTitulo.Text = "Modificar proveedores";
                Proveedores ints = new DAOProveedores().ObtenerUnProveedor(id);
                txtClave.Text = ints.idProveedores;
                txtClave.Enabled = false;
                txtNombre.Text = ints.nomProveedores;
                txtRFC.Text = ints.RFC;
                txtDireccion.Text = ints.Direccion;
                txtTelefono.Text = ints.Telefono;
                txtCorreo.Text = ints.Correo;
                dtpFecha.Enabled = false;
            }
        }

        /// <summary>
        /// Evento click de boton, al dar click mandara y guardara el nuevo registro o modificara
        /// un registro ya existente.
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de Proveedores
        /// asi como al DAO Proveedores para poder utiliazar el metodo de agregar un nuevo registro.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de Proveedores.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

                if (OP == 1)
                {
                    Proveedores Inst = new Proveedores();
                    Inst.idProveedores = txtClave.Text;
                    Inst.nomProveedores = txtNombre.Text;
                    Inst.RFC = txtRFC.Text;
                    Inst.Direccion = txtDireccion.Text;
                    Inst.Telefono = txtTelefono.Text;
                    Inst.Correo = txtCorreo.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.Estatus = true;
                    if (Verificar())
                    {
                    Guardado = new DAOProveedores().AgregarProveedor(Inst);
                    if (Guardado > 0)
                    {
                        MessageBox.Show("Se ha guardado exitosamente el proveedor", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                    else
                {
                    MessageBox.Show("Rellene todos los campos correctamente","", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
                else if (OP == 2)
                {
                    Proveedores Inst = new Proveedores();
                    Inst.idProveedores = txtClave.Text;
                    Inst.nomProveedores = txtNombre.Text;
                    Inst.RFC = txtRFC.Text;
                    Inst.Direccion = txtDireccion.Text;
                    Inst.Telefono = txtTelefono.Text;
                    Inst.Correo = txtCorreo.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.Estatus = true;
                if (Verificar())
                {
                    Modificado = new DAOProveedores().ModificarProveedor(Inst);
                    if (Modificado)
                    {
                        MessageBox.Show("Se ha actualizado exitosamente el proveedor.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Rellene todos los campos correctamente", "",MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                }
            
        }

        /// <summary>
        /// Evento de boton cancer, al dar click al boton cierra la ventan y regresa al menu principal
        /// de Proveedores.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
