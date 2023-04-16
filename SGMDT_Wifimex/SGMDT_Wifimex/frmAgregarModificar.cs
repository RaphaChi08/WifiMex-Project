using Datos;
using Modelos;
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
            }
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
                txtEdad.Text = (emp.Edad).ToString();
                txtDireccion.Text = emp.Direccion;
                txtTelefono.Text = emp.Telefono;
                txtRol.Text = emp.Rol;
                dtpContrato.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtNumEmpleado.Text.Length>0 & txtNombre.Text.Length > 0 & txtRFC.Text.Length > 0 & txtCURP.Text.Length > 0
                & txtEdad.Text.Length > 0 & txtCorreo.Text.Length > 0 & txtDireccion.Text.Length > 0
                & txtDireccion.Text.Length > 0 & txtRol.Text.Length > 0 & txtTelefono.Text.Length > 0)
            {
                if (OP == 1)
                {
                    Empleados emp = new Empleados();
                    emp.Idempleado = txtNumEmpleado.Text;
                    emp.Nombrecompleto = txtNombre.Text;
                    emp.RFC = txtRFC.Text;
                    emp.CURP = txtCURP.Text;
                    emp.Edad =  Convert.ToInt32(txtEdad.Text);
                    emp.Password = txtContrasena.Text;
                    emp.Correo = txtCorreo.Text;
                    emp.Direccion = txtDireccion.Text;
                    emp.Rol = txtRol.Text;
                    emp.Telefono = txtTelefono.Text;
                    emp.Estatus = true;
                    emp.fechaContratacion = dtpContrato.Text;
                    Guardado = new DAOEmpleados().AgregarEmpleado(emp);
                    if (Guardado > 0)
                    {
                        MessageBox.Show("Usuario agregado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (OP == 2)
                {
                    Empleados emp = new Empleados();
                    emp.Idempleado = txtNumEmpleado.Text;
                    emp.Nombrecompleto = txtNombre.Text;
                    emp.RFC = txtRFC.Text;
                    emp.CURP = txtCURP.Text;
                    emp.Edad = Convert.ToInt32(txtEdad.Text);
                    emp.Password = txtContrasena.Text;
                    emp.Correo = txtCorreo.Text;
                    emp.Direccion = txtDireccion.Text;
                    emp.Rol = txtRol.Text;
                    emp.Telefono = txtTelefono.Text;
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
