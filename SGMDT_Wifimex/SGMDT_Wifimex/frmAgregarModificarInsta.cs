using Datos;
using Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGMDT_Wifimex
{
    public partial class frmAgregarModificarInsta : Form
    {
        private int OP;
        private string ID;
        public int Guardado { get; set; }
        public bool Modificado { get; set; }
        public frmAgregarModificarInsta(int op, string id)
        {
            InitializeComponent();
            ID = id;
            OP = op;

            if (op == 1)
            {
                this.Text = "Agregar";
            }
            // se cargan los datos a actualizar
            else if (op == 2)
            {
                this.Text = "Modificar";
                Instalaciones ints = new DAOInstalaciones().ObtenerUnaInstalacion(id);
                txtInstalacion.Text = ints.IdInstalacion;
                txtEmpleado.Text = ints.idEmpelado;
                txtContrato.Text = ints.idContratos;
                dtpInstalacion.Text = ints.fechaInstalacin;
                dtpInstalacion.Enabled = false;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (txtContrato.Text.Length>0 & txtInstalacion.Text.Length>0 & txtEmpleado.Text.Length>0)
            {
                if (OP == 1)
                {
                    Instalaciones Inst = new Instalaciones();
                    Inst.IdInstalacion = txtInstalacion.Text;
                    Inst.idEmpelado = txtEmpleado.Text;
                    Inst.idContratos = txtContrato.Text;
                    Inst.Estatus = true;
                    Inst.fechaInstalacin = dtpInstalacion.Text;
                    Guardado = new DAOInstalaciones().AgregarInstlacion(Inst);
                    if (Guardado == 0)
                    {
                        MessageBox.Show("Instalacion agregada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("A surgido un problema, inténtelo de nuevo más tardé", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (OP == 2)
                {
                    Instalaciones Inst = new Instalaciones();
                    Inst.IdInstalacion = txtInstalacion.Text;
                    Inst.idEmpelado = txtEmpleado.Text;
                    Inst.idContratos = txtContrato.Text;
                    Inst.fechaInstalacin = dtpInstalacion.Text;
                    Modificado = new DAOInstalaciones().ModificarInstalacion(Inst);
                    if (Modificado)
                    {
                        MessageBox.Show("Instalacion modificada correctamente", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
