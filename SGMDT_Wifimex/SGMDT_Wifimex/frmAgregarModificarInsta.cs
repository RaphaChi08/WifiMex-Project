using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    /// <summary>
    /// Formulario que agrega y modifica los registros de la tabla Instalaciones
    /// </summary>
    public partial class frmAgregarModificarInsta : Form
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
        /// Metodo que sirve para validar que las cajas de texto del formulario tengan
        /// el formato correcto que se solicita
        /// </summary>
        /// <returns>
        /// regresa un true si los formatos de las cajas de texto son validos en caso de
        /// lo contrario regresa un false.
        /// </returns>
        public bool Verificar()
        {
            if (!Regex.IsMatch(txtInstalacion.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtInstalacion, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtEmpleado.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtEmpleado, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtContrato.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtContrato, "El formato debe contener 4 letras y 6 numeros en este orden");
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
        public frmAgregarModificarInsta(int op, string id)
        {
            InitializeComponent();
            ID = id;
            OP = op;

            if (op == 1)
            {
                this.Text = "Agregar";
            }
            // se cargan los datos a actualizar
            else if (op == 2)
            {
                this.Text = "Modificar";
                Instalaciones ints = new DAOInstalaciones().ObtenerUnaInstalacion(id);
                txtInstalacion.Text = ints.IdInstalacion;
                txtEmpleado.Text = ints.idEmpelado;
                txtContrato.Text = ints.idContratos;
                dtpInstalacion.Text = ints.fechaInstalacin;
                dtpInstalacion.Enabled = false;
                txtInstalacion.Enabled = false;
            }
        }

        /// <summary>
        /// Evento click de boton, al dar click mandara y guardara el nuevo registro o modificara
        /// un registro ya existente.
        /// En caso de que la opcion selecionada sea agregar se hace una referencia al modelo de Instalaciones
        /// asi como al DAO Instalaciones para poder utiliazar el metodo de agregar un nuevo registro.
        /// Si la opcion seleccionada es modificar tambien hara referencias a las mismas clases ya
        /// mencionadas, con el cambio de que ahora llamara al metodo de actulizar un registro.
        /// Al finalizar lanzar un mensaje de registro exitoso o fallo de regsitro, al cerrar
        /// el mensaje regresara al menu principal de Instalaciones.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {

                if (OP == 1)
                {
                    Instalaciones Inst = new Instalaciones();
                    Inst.IdInstalacion = txtInstalacion.Text;
                    Inst.idEmpelado = txtEmpleado.Text;
                    Inst.idContratos = txtContrato.Text;
                    Inst.Estatus = true;
                    Inst.fechaInstalacin = dtpInstalacion.Text;
                if (Verificar())
                {
                    Guardado = new DAOInstalaciones().AgregarInstlacion(Inst);
                    if (Guardado == 0)
                    {
                        MessageBox.Show("Instalacion agregada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    Instalaciones Inst = new Instalaciones();
                    Inst.IdInstalacion = txtInstalacion.Text;
                    Inst.idEmpelado = txtEmpleado.Text;
                    Inst.idContratos = txtContrato.Text;
                    Inst.fechaInstalacin = dtpInstalacion.Text;
                if (Verificar())
                {
                    Modificado = new DAOInstalaciones().ModificarInstalacion(Inst);
                    if (Modificado)
                    {
                        MessageBox.Show("Instalacion modificada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// de Instalaciones.
        /// </summary>
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
