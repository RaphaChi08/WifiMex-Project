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
            }
        }
    }
}
