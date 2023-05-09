using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    /// <summary>
    /// Formulario que agrega y modifica los registros de la tabla clientes
    /// </summary>
    public partial class frmAddModyCliente : Form
    {
        /// <summary>
        /// Variables que sirven para validar la opcion que se mostrara en el formulario
        /// ya se Agregar o modificar.
        /// </summary>
        public Boolean modificado;
        public int Agregado;

        private bool resp=false;

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
            if (!Regex.IsMatch(txtId.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtId, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtRfc.Text, @"^[A-Z]{4}\d{6}([A-Z0-9]{2}[A-Z0-9]{1})?$"))
            {
                errorProvider1.SetError(txtRfc, "Verifique que su RFC este correcto");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtCurp.Text, @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z0-9]{2}$"))
            {
                errorProvider1.SetError(txtCurp, "Verifique que su CURP cumpla con el formato requerido");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtNom.Text, @"^[A-Za-z][A-Za-z .]{1,}[A-Za-z]$"))
            {
                errorProvider1.SetError(txtNom, "El nombre no puede contener números o caracteres especiales");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtDir.Text, @"^[A-Za-z][A-Za-z .]{1,}\s+#\d+(-\d+)?$"))
            {
                errorProvider1.SetError(txtDir, "Siga al formato adecuado , ejemplo : 'Calle #123', en caso de ser departamento agregue '-Número interior'");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtTel.Text, @"^[0-9]{10}?$"))
            {
                errorProvider1.SetError(txtTel, "Verifique el número contenga 10 dígitos");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtCorr.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(txtCorr, "Verifique en correo este correctamente escrito y sin espacios");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }


            return true;
        }

        private int opcion;

        /// <summary>
        /// Costrcutor del formulario donde cargan todos los controles que
        /// estan dentro del formulario.
        /// </summary>
        /// <param name="ID">
        /// Parametro que resive el constructor en caso de que se de la opcion de modificar
        /// un registro para buscar el registro a modificar
        /// </param>
        /// <param name="Opcion">
        /// Parametro que indica cuales controles tiene que cargar el formulario
        /// este indica si el fomulario tiene que ponerse en modo de agregar un
        /// nuevo registro o en mode de modificar un registro ya existente.
        /// </param>
        public frmAddModyCliente(string ID, int Opcion)
        {
            InitializeComponent();
            opcion= Opcion;
            switch (Opcion)
            {
                case 1:
                    this.Text = "Agregar";
                    gbxEstatus.Enabled = false;
                    break;
                case 2:
                    this.Text = "Actualizar";
                    txtId.Enabled = false;
                    Cliente cli = new DAOCliente().ObtenerUno(ID);

                    txtId.Text = cli.idCliente.ToString();
                    txtRfc.Text = cli.RFC.ToString();
                    txtCurp.Text = cli.CURP.ToString();
                    txtNom.Text = cli.nomCliente.ToString();
                    txtDir.Text = cli.Direccion.ToString();
                    txtTel.Text = cli.Telefono.ToString();
                    txtCorr.Text = cli.Correo.ToString();
                    if(cli.Estatus.ToString() == "Activo") 
                    { rbActivo.Checked = true; }   
                    else if (cli.Estatus.ToString() == "Inactivo")
                    { rbInactivo.Checked = true; } 

                    break;
                default:
                    break;
            }

        }

        /// <summary>
        /// Evento click de boton, al dar click mandara y guardara el nuevo registro o modificara
        /// un registro ya existente.
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de Clientes
        /// asi como al DAO Clientes para poder utiliazar el metodo de agregar un nuevo registro.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de Clientes.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (opcion == 1)
                {
                    Cliente cli = new Cliente();
                    cli.idCliente = txtId.Text;
                    cli.RFC = txtRfc.Text;
                    cli.CURP = txtCurp.Text;
                    cli.nomCliente = txtNom.Text;
                    cli.Direccion = txtDir.Text;
                    cli.Telefono = txtTel.Text;
                    cli.Correo = txtCorr.Text;
                    if (Verificar())
                    {
                        Agregado = new DAOCliente().agregar(cli);
                        if (Agregado > 0)
                        {
                            MessageBox.Show("Cliente Agregado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El cliente no se a podido agregar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    Cliente cli = new Cliente();
                    cli.idCliente = txtId.Text;
                    cli.RFC = txtRfc.Text;
                    cli.CURP = txtCurp.Text;
                    cli.nomCliente = txtNom.Text;
                    cli.Direccion = txtDir.Text;
                    cli.Telefono = txtTel.Text;
                    cli.Correo = txtCorr.Text;
                    cli.Estatus = rbActivo.Checked == true ? "Activo" : "Inactivo";
                    if (Verificar())
                    {
                        modificado = new DAOCliente().editar(cli);
                        if (modificado)
                        {
                            MessageBox.Show("Cliente modificado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El cliente no se a podido modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Evento de boton cancer, al dar click al boton cierra la ventan y regresa al menu principal
        /// de Clientes.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
