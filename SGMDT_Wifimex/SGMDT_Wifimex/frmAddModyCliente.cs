using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    public partial class frmAddModyCliente : Form
    {
        public Boolean modificado;
        public int Agregado;


        private int opcion;
        public frmAddModyCliente(string ID, int Opcion)
        {
            InitializeComponent();
            opcion= Opcion;
            switch (Opcion)
            {
                case 1:
                    this.Text = "Agregar";
                    gbxEstatus.Enabled = false;
                    break;
                case 2:
                    this.Text = "Actualizar";
                    txtId.Enabled = false;
                    Cliente cli = new DAOCliente().ObtenerUno(ID);

                    txtId.Text = cli.idCliente.ToString();
                    txtRfc.Text = cli.RFC.ToString();
                    txtCurp.Text = cli.CURP.ToString();
                    txtNom.Text = cli.nomCliente.ToString();
                    txtDir.Text = cli.Direccion.ToString();
                    txtTel.Text = cli.Telefono.ToString();
                    txtCorr.Text = cli.Correo.ToString();
                    if(cli.Estatus.ToString() == "Activo") 
                    { rbActivo.Checked = true; }   
                    else if (cli.Estatus.ToString() == "Inactivo")
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
                Cliente cli = new Cliente();
                cli.idCliente = txtId.Text;
                cli.RFC = txtRfc.Text;
                cli.CURP = txtCurp.Text;
                cli.nomCliente = txtNom.Text;
                cli.Direccion = txtDir.Text;
                cli.Telefono = txtTel.Text;
                cli.Correo = txtCorr.Text;
                Agregado = new DAOCliente().agregar(cli);
                if (Agregado > 0)
                {
                    MessageBox.Show("Cliente Agregado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El cliente no se a podido agregar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                Cliente cli = new Cliente();
                cli.idCliente = txtId.Text;
                cli.RFC = txtRfc.Text;
                cli.CURP = txtCurp.Text;
                cli.nomCliente = txtNom.Text;
                cli.Direccion = txtDir.Text;
                cli.Telefono = txtTel.Text;
                cli.Correo = txtCorr.Text;
                cli.Estatus = rbActivo.Checked==true? "Activo":"Inactivo";
                modificado = new DAOCliente().editar(cli);
                if (modificado)
                {
                    MessageBox.Show("Cliente modificado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("El cliente no se a podido modificar", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
