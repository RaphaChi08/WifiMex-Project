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
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    public partial class frmAddModyCliente : Form
    {
        public Boolean modificado;
        public int Agregado;

        private bool resp=false;
        public bool Verificar()
        {
            if (!Regex.IsMatch(txtId.Text, "^[A-Za-z]{4}[0-9]{6}$"))
            {
                errorProvider1.SetError(txtId, "El formato debe contener 4 letras y 6 numeros en este orden");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtRfc.Text, @"^[A-Z]{4}\d{6}([A-Z0-9]{2}[A-Z0-9]{1})?$"))
            {
                errorProvider1.SetError(txtRfc, "Verifique que su RFC este correcto");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtCurp.Text, @"^[A-Z]{4}\d{6}[HM][A-Z]{5}[A-Z0-9]{2}$"))
            {
                errorProvider1.SetError(txtCurp, "Verifique que su CURP cumpla con el formato requerido");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtNom.Text, @"^[A-Za-z][A-Za-z .]{1,}[A-Za-z]$"))
            {
                errorProvider1.SetError(txtNom, "El nombre no puede contener números o caracteres especiales");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtDir.Text, @"^[A-Za-z][A-Za-z .]{1,}\s+#\d+(-\d+)?$"))
            {
                errorProvider1.SetError(txtDir, "Siga al formato adecuado , ejemplo : 'Calle #123', en caso de ser departamento agregue '-Número interior'");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtTel.Text, @"^[0-9]{10}?$"))
            {
                errorProvider1.SetError(txtTel, "Verifique el número contenga 10 dígitos");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }
            if (!Regex.IsMatch(txtCorr.Text, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                errorProvider1.SetError(txtCorr, "Verifique en correo este correctamente escrito y sin espacios");
                return false;
            }
            else
            {
                errorProvider1.Clear();
            }


            return true;
        }

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
            try
            {
                if (opcion == 1)
                {
                    Cliente cli = new Cliente();
                    cli.idCliente = txtId.Text;
                    cli.RFC = txtRfc.Text;
                    cli.CURP = txtCurp.Text;
                    cli.nomCliente = txtNom.Text;
                    cli.Direccion = txtDir.Text;
                    cli.Telefono = txtTel.Text;
                    cli.Correo = txtCorr.Text;
                    if (Verificar())
                    {
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
                    cli.Estatus = rbActivo.Checked == true ? "Activo" : "Inactivo";
                    if (Verificar())
                    {
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
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
