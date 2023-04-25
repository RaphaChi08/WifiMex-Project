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
    public partial class frmAgregar_ModificarProveedores : Form
    {
        private int OP;
        private string ID;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
