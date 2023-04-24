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
    public partial class frmAgregar_ModificarProductos : Form
    {
        private int OP;
        private string codigo;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }
        public frmAgregar_ModificarProductos(int op, string codigoBarra)
        {
            InitializeComponent();
            this.OP = op;
            this.codigo = codigoBarra;
            if (op == 1)
            {
                this.Text = "Agregar";
                lblTitulo.Text = "Agregar productos";
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
                    Inst.codigoBarra =txtCodigo.Text;
                    Inst.nomProducto = txtNombre.Text;
                    Inst.fechaRegistro = dtpFecha.Text;
                    Inst.idProveedores = cbxProveedor.SelectedValue.ToString();
                    Inst.nomProveedor = cbxProveedor.SelectedText;
                    Inst.Estatus = true;
                    Guardado = new DAOProductos().AgregarProducto(Inst);
                    if (Guardado > 0)
                    {
                        MessageBox.Show("Producto agregado correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Producto ya registrado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    Modificado = new DAOProductos().ModificarProducto(Inst);
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
    }
}
