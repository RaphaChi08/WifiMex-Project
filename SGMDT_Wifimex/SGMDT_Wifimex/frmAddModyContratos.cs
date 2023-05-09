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
using Datos;
using Modelos;

namespace SGMDT_Wifimex
{
    /// <summary>
    /// Formulario que agrega y modifica los registros de la tabla Contratos
    /// </summary>
    public partial class frmAddModyContratos : Form
    {
        /// <summary>
        /// Variables que sirven para validar la opcion que se mostrara en el formulario
        /// ya se Agregar o modificar.
        /// </summary>
        public Boolean modificado;
        public int Agregado;

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

            if (!Regex.IsMatch(txtIdCo.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtIdCo, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtPrecio.Text, "^[0-9]{1,3}([.][0-9]{1,2})?$"))
            {
                errorProvider1.SetError(txtPrecio, "El valor debe ser menor o igual a 999.99");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            };

            if (dtpFin.Value<dtpIni.Value)
            {
                errorProvider1.SetError(dtpFin, "La fecha de fin debe de ser despues de la de inicio");
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
        public frmAddModyContratos(string ID, int Opcion)
        {
            InitializeComponent();
            cbxCliente.DataSource = new DAOCliente().ObtenerTodos();
            cbxCliente.DisplayMember= "nomCliente";
            cbxCliente.ValueMember= "idCLiente";
            
            opcion= Opcion;
            switch (Opcion)
            {
                case 1:
                    this.Text = "Agregar";
                    lblTitulo.Text = "Crear Contrato";
                    gbxEstatus.Enabled = false;
                    cbxCliente.SelectedIndex = 0;
                    break;
                case 2:
                    this.Text = "Actualizar";
                    lblTitulo.Text = "Actualizar Contrato";
                    txtIdCo.Enabled = false;
                    Contrato con = new DAOContratos().ObtenerUno(ID);

                    txtIdCo.Text = con.idContrato.ToString();
                    txtPrecio.Text = con.precioServicio.ToString();
                    dtpIni.Text = con.inicioContrato.ToString();
                    dtpFin.Text = con.finContrato.ToString();
                    cbxCliente.SelectedValue = con.idCliente.ToString();
                    if (con.Estatus.ToString() == "Activo")
                    { rbActivo.Checked = true; }
                    else if (con.Estatus.ToString() == "Inactivo")
                    { rbInactivo.Checked = true; }

                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Evento click de boton, al dar click mandara y guardara el nuevo registro o modificara
        /// un registro ya existente.
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de Contratos
        /// asi como al DAO Contratos para poder utiliazar el metodo de agregar un nuevo registro.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de Contratos.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (opcion == 1)
                {
                    Contrato con = new Contrato();
                    con.idContrato = txtIdCo.Text;
                    con.precioServicio = double.Parse(txtPrecio.Text);
                    con.inicioContrato = dtpIni.Text;
                    con.idCliente = cbxCliente.SelectedValue.ToString();
                    con.finContrato = dtpFin.Text;
                    if (Verificar())
                    {
                        Agregado = new DAOContratos().agregar(con);
                        if (Agregado > 0)
                        {
                            MessageBox.Show("Contrato Agregado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El contrato no se a podido agregar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    Contrato con = new Contrato();
                    con.idContrato = txtIdCo.Text;
                    con.precioServicio = double.Parse(txtPrecio.Text);
                    con.inicioContrato = dtpIni.Text;
                    con.idCliente = cbxCliente.SelectedValue.ToString();
                    con.finContrato = dtpFin.Text;
                    con.Estatus = rbActivo.Checked == true ? "Activo" : "Inactivo";
                    if (Verificar())
                    {
                        modificado = new DAOContratos().editar(con);
                        if (modificado)
                        {
                            MessageBox.Show("Contrato modificado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El contrato no se a podido modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// de Contratos.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
