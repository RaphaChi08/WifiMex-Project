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
    /// Formulario que agrega y modifica los registros de la tabla Empleados
    /// </summary>
    public partial class frmAgregarModificar : Form
    {
        /// <summary>
        /// Variables que sirven para validar la opcion que se mostrara en el formulario
        /// ya se Agregar o modificar.
        /// </summary>
        private int OP;
        private string ID;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }

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
        public frmAgregarModificar(int op, string id)
        {
            InitializeComponent();
            ID = id;
            OP = op;

            if (op==1)
            {
                this.Text = "Agregar";
                cbxRol.SelectedIndex = 0;
            }
            // Aquie se carga los datos para cuando se actualizan
            else if (op == 2)
            {
                this.Text = "Modificar";
                txtContrasena.Visible = false;
                label11.Visible = false;
                Empleados emp = new DAOEmpleados().ObtenerUnEmpleado(id);
                txtNumEmpleado.Text = emp.Idempleado;
                txtNombre.Text = emp.Nombrecompleto;
                txtCorreo.Text = emp.Correo;
                txtRFC.Text = emp.RFC;
                txtCURP.Text = emp.CURP;
                nudEdad.Text = (emp.Edad).ToString();
                txtDireccion.Text = emp.Direccion;
                txtTelefono.Text = emp.Telefono;
                cbxRol.SelectedItem = emp.Rol;
                dtpContrato.Enabled = false;
                txtNumEmpleado.Enabled = false;
            }
        }

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
            if (!Regex.IsMatch(txtNumEmpleado.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                erpVerificar.SetError(txtNumEmpleado, "El formato debe contener 4 letras y 6 numeros en este orden");
                Console.WriteLine("Falla");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }
            if (!Regex.IsMatch(txtRFC.Text, @"^[A-Z]{4}\d{6}([A-Z0-9]{2}[A-Z0-9]{1})?$"))
            {
                erpVerificar.SetError(txtRFC, "Verifique que su RFC este correcto");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }
            if (!Regex.IsMatch(txtCURP.Text, @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z0-9]{2}$"))
            {
                erpVerificar.SetError(txtCURP, "Verifique que su CURP cumpla con el formato requerido");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }
            if (!Regex.IsMatch(txtNombre.Text, @"^[A-Za-z][A-Za-z .]{1,}[A-Za-z]$"))
            {
                erpVerificar.SetError(txtNombre, "El nombre no puede contener números o caracteres especiales");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }
            if (!Regex.IsMatch(txtDireccion.Text, @"^[A-Za-z][A-Za-z .]{1,}\s+#\d+(-\d+)?$"))
            {
                erpVerificar.SetError(txtDireccion, "Siga al formato adecuado , ejemplo : 'Calle #123', en caso de ser departamento agregue '-Número interior'");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }
            if (!Regex.IsMatch(txtTelefono.Text, @"^[0-9]{10}?$"))
            {
                erpVerificar.SetError(txtTelefono, "Verifique el número contenga 10 dígitos");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }
            if (!Regex.IsMatch(txtCorreo.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                erpVerificar.SetError(txtCorreo, "Verifique en correo este correctamente escrito y sin espacios");
                return false;
            }
            else
            {
                erpVerificar.Clear();
            }


            return true;
        }

        /// <summary>
        /// Evento click de boton, al dar click mandara y guardara el nuevo registro o modificara
        /// un registro ya existente.
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de Empleados
        /// asi como al DAO Empleados para poder utiliazar el metodo de agregar un nuevo registro.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de Empleados.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            
                if (OP == 1)
                {
                    Empleados emp = new Empleados();
                    emp.Idempleado = txtNumEmpleado.Text;
                    emp.Nombrecompleto = txtNombre.Text;
                    emp.RFC = txtRFC.Text;
                    emp.CURP = txtCURP.Text;
                    emp.Edad =  Convert.ToInt32(nudEdad.Value);
                    emp.Password = txtContrasena.Text;
                    emp.Correo = txtCorreo.Text;
                    emp.Direccion = txtDireccion.Text;
                    emp.Rol = cbxRol.SelectedItem.ToString();
                    emp.Telefono = txtTelefono.Text;
                    emp.Estatus = true;
                    emp.fechaContratacion = dtpContrato.Text;
                    if (Verificar())
                    {
                        Guardado = new DAOEmpleados().AgregarEmpleado(emp);
                        if (Guardado == 0)
                        {
                            MessageBox.Show("Usuario agregado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                else if (OP == 2)
                {
                    Empleados emp = new Empleados();
                    emp.Idempleado = txtNumEmpleado.Text;
                    emp.Nombrecompleto = txtNombre.Text;
                    emp.RFC = txtRFC.Text;
                    emp.CURP = txtCURP.Text;
                    emp.Edad = Convert.ToInt32(nudEdad.Value);
                    emp.Password = txtContrasena.Text;
                    emp.Correo = txtCorreo.Text;
                    emp.Direccion = txtDireccion.Text;
                    emp.Rol = cbxRol.SelectedItem.ToString();
                    emp.Telefono = txtTelefono.Text;
                    if (Verificar())
                    {
                        Modificado = new DAOEmpleados().ModificarEmpleado(emp);
                        if (Modificado)
                        {
                            MessageBox.Show("Usuario modificado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            
        }

        /// <summary>
        /// Evento de boton cancer, al dar click al boton cierra la ventan y regresa al menu principal
        /// de Empleados.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
