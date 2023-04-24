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
    public partial class frmAgregar_ModificarProveedores : Form
    {
        private int OP;
        private string ID;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }
        public frmAgregar_ModificarProveedores(int op, string id)
        {
            InitializeComponent();
            this.OP = op;
            if (op == 1)
            {
                this.Text = "Agregar";
                lblTitulo.Text = "Agregar proveedores";
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
            if (txtClave.Text.Length > 0 & txtCorreo.Text.Length > 0 & txtDireccion.Text.Length > 0 & txtNombre.Text.Length > 0 & txtRFC.Text.Length > 0 & txtTelefono.Text.Length > 0)
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
                    Guardado = new DAOProveedores().AgregarProveedor(Inst);
                    if (Guardado > 0)
                    {
                        MessageBox.Show("Proveedor agregada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Modificado = new DAOProveedores().ModificarProveedor(Inst);
                    if (Modificado)
                    {
                        MessageBox.Show("Proveedor modificada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
