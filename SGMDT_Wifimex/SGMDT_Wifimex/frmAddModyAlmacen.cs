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
    public partial class frmAddModyAlmacen : Form
    {
        public Boolean modificado;
        public int Agregado;
        private int opcion;

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
