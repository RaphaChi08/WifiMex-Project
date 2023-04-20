using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;
using Modelos;

namespace SGMDT_Wifimex
{
    public partial class frmAddModyContratos : Form
    {
        public Boolean modificado;
        public int Agregado;


        private int opcion;
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
                    gbxEstatus.Enabled = false;
                    break;
                case 2:
                    this.Text = "Actualizar";
                    txtIdCo.Enabled = false;
                    Contrato con = new DAOContratos().ObtenerUno(ID);

                    txtIdCo.Text = con.idContrato.ToString();
                    txtPrecio.Text = con.precioServicio.ToString();
                    dtpIni.Text = con.inicioContrato.ToString();
                    dtpFin.Text = con.finContrato.ToString();
                    cbxCliente.SelectedValue = con.idCliente.ToString();
                    Console.WriteLine(con.Estatus.ToString());
                    if (con.Estatus.ToString() == "Activo")
                    { rbActivo.Checked = true; }
                    else if (con.Estatus.ToString() == "Inactivo")
                    { rbInactivo.Checked = true; }

                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (opcion==1)
            {
                Contrato con = new Contrato();
                con.idContrato= txtIdCo.Text;
                con.precioServicio = double.Parse(txtPrecio.Text);
                con.inicioContrato= dtpIni.Text;
                con.idCliente = cbxCliente.SelectedValue.ToString();
                con.finContrato= dtpFin.Text;
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
            else
            {
                Contrato con = new Contrato();
                con.idContrato = txtIdCo.Text;
                con.precioServicio = double.Parse(txtPrecio.Text);
                con.inicioContrato = dtpIni.Text;
                con.idCliente = cbxCliente.SelectedValue.ToString();
                con.finContrato = dtpFin.Text;
                con.Estatus = rbActivo.Checked == true ? "Activo" : "Inactivo";
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
