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
    public partial class frmAgregarModificar : Form
    {
        private int OP;
        private string ID;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }
        

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
            }
        }

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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
