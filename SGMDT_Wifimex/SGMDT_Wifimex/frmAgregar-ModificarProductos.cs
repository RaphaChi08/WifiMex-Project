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
    public partial class frmAgregar_ModificarProductos : Form
    {
        private int OP;
        private string codigo;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }
        public bool Verificar()
        {
            if (!Regex.IsMatch(txtCodigo.Text, "^[0-9]{12}$"))
            {
                errorProvider1.SetError(txtCodigo, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtNombre.Text, @"^[A-Za-z][A-Za-z .0-9]{1,}$"))
            {
                errorProvider1.SetError(txtNombre, "El nombre no puede contener números o caracteres especiales");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }


            return true;
        }
        public frmAgregar_ModificarProductos(int op, string codigoBarra)
        {
            InitializeComponent();
            this.OP = op;
            this.codigo = codigoBarra;
            if (op == 1)
            {
                this.Text = "Registrar";
                lblTitulo.Text = "Registrar productos";
                List<Proveedores> prov = new DAOProveedores().ObtenerProveedoresActivos();
                cbxProveedor.DataSource = prov;
                cbxProveedor.DisplayMember = "nomProveedores";
                cbxProveedor.ValueMember = "idProveedores";
                //cbxProveedor.SelectedIndex = 1;
            }
            else if (op == 2)
            {
                this.Text = "Modificar";
                Productos ints = new DAOProductos().ObtenerUnProducto(codigo);
                lblTitulo.Text = "Modificar productos";
                txtCodigo.Text = ints.codigoBarra.ToString();
                txtCodigo.Enabled = false;
                txtNombre.Text = ints.nomProducto;
                dtpFecha.Enabled = false;
                List<Proveedores> prov = new DAOProveedores().ObtenerProveedoresActivos();
                cbxProveedor.DataSource = prov;
                cbxProveedor.DisplayMember = "nomProveedores";
                cbxProveedor.ValueMember = "idProveedores";
                cbxProveedor.SelectedValue=ints.idProveedores;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtCodigo.Text.Length > 0 & txtNombre.Text.Length > 0)
            {
                if (OP == 1)
                {
                    Productos Inst = new Productos();
                    Inst.codigoBarra = txtCodigo.Text;
                    Inst.nomProducto = txtNombre.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.idProveedores = cbxProveedor.SelectedValue.ToString();
                    Inst.nomProveedor = cbxProveedor.SelectedText;
                    Inst.Estatus = true;
                    if (Verificar())
                    {
                        Guardado = new DAOProductos().AgregarProducto(Inst);
                        if (Guardado > 0)
                        {
                            MessageBox.Show("Se ha guardado exitosamente el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Producto ya registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (OP == 2)
                {
                    Productos Inst = new Productos();
                    Inst.codigoBarra = txtCodigo.Text;
                    Inst.nomProducto = txtNombre.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.idProveedores = cbxProveedor.SelectedValue.ToString();
                    Inst.nomProveedor = cbxProveedor.SelectedText;
                    Inst.Estatus = true;
                    if (Verificar())
                    {
                        Modificado = new DAOProductos().ModificarProducto(Inst);
                        if (Modificado)
                        {
                            MessageBox.Show("Se ha actualizado exitosamente el producto", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Rellene todos los campos", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
