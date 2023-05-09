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
    /// Formulario para la agregar y modificar los registros de la tabla de Almacen
    /// </summary>
    public partial class frmAddModyAlmacen : Form
    {
        /// <summary>
        /// Variaibles que sirven para validar la opcion que se mostrara en el formulario
        /// ya se Agregar o modificar.
        /// </summary>
        public Boolean modificado;
        public int Agregado;
        private int opcion;

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
            return true;
        }


        /// <summary>
        /// Costrcutor del formulario donde cargan todos los controles que
        /// estan dentro del formulario.
        /// </summary>
        /// <param name="ID">
        /// Parametro que resive el constructor en caso de que se de la opcion de modificar
        /// un registro para buscar el registro a modificar
        /// </param>
        /// <param name="op">
        /// Parametro que indica cuales controles tiene que cargar el formulario
        /// este indica si el fomulario tiene que ponerse en modo de agregar un
        /// nuevo registro o en mode de modificar un registro ya existente.
        /// </param>
        public frmAddModyAlmacen(string ID, int op)
        {
            InitializeComponent();
            cbxEmpleado.DataSource = new DAOEmpleados().ObtenerEmpleados();
            cbxEmpleado.DisplayMember = "nomEmpleados";
            cbxEmpleado.ValueMember = "idEmpleado";
            cbxEmpleado.SelectedIndex= 0;


            cbxBarra.DataSource = new DAOProductos().ObtenerProductos();
            cbxBarra.DisplayMember = "nomProducto";
            cbxBarra.ValueMember = "codigoBarra";
            cbxBarra.SelectedIndex = 0;

            opcion = op;
            switch (op)
            {
                case 1:
                    this.Text = "Agregar";
                    gbxEstatus.Enabled = false;
                    break;
                case 2:
                    this.Text = "Actualizar";
                    txtClave.Enabled = false;
                    Almacen cli = new DAOAlmacen().ObtenerUno(ID);

                    txtClave.Text = cli.idAlmacen.ToString();
                    nudCant.Text = cli.cantProducto.ToString();
                    cbxBarra.SelectedValue = cli.codigoBarra.ToString();
                    cbxEmpleado.SelectedValue = cli.idEmpleado.ToString();
                    if (cli.Estatus.ToString() == "Activo")
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
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de almacen
        /// asi como al DAO alamcen para poder utiliazar el metodo de agregar un nuevo registr.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de almacen.
        /// </summary>
        private void btnAcep_Click(object sender, EventArgs e)
        {
            try
            {
                if (opcion==1)
                {
                    Almacen almacen = new Almacen();
                    almacen.idAlmacen = txtClave.Text;
                    almacen.cantProducto = int.Parse(nudCant.Value.ToString());
                    almacen.codigoBarra = cbxBarra.SelectedValue.ToString();
                    almacen.idEmpleado = cbxEmpleado.SelectedValue.ToString();
                    if (Verificar())
                    {
                        Agregado = new DAOAlmacen().agregar(almacen);
                        if (Agregado > 0)
                        {
                            MessageBox.Show("Almacen agregado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El almacen no se a podido agregar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    Almacen almacen = new Almacen();
                    almacen.idAlmacen = txtClave.Text;
                    almacen.cantProducto = int.Parse(nudCant.Value.ToString());
                    almacen.codigoBarra = cbxBarra.SelectedValue.ToString();
                    almacen.idEmpleado = cbxEmpleado.SelectedValue.ToString();
                    almacen.Estatus = rbActivo.Checked == true ? "Activo" : "Inactivo";
                if (Verificar())
                    {
                        modificado = new DAOAlmacen().editar(almacen);
                        if (modificado)
                        {
                            MessageBox.Show("Almacen modificado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("El almacen no se a podido modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
        }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
}
        /// <summary>
        /// Evento de boton cancer, al dar click al boton cierra la ventan y regresa al menu principal
        /// de Almacen.
        /// </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
