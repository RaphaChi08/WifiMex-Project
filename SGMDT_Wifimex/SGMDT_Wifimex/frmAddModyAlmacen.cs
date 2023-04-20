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
    public partial class frmAddModyAlmacen : Form
    {
        public Boolean modificado;
        public int Agregado;
        private int opcion;

        public frmAddModyAlmacen(string ID, int op)
        {
            InitializeComponent();
            cbxEmpleado.DataSource = new DAOEmpleados().ObtenerEmpleados();
            cbxEmpleado.DisplayMember = "nomEmpleados";
            cbxEmpleado.ValueMember = "idEmpleado";

            //cbxBarra.DataSource = new DAOProductos().ObtenerTodos();
            //cbxBarra.DisplayMember = "nomCliente";
            //cbxBarra.ValueMember = "idCLiente";

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
                    txtCant.Text = cli.cantProducto.ToString();
                    cbxBarra.SelectedValue = cli.idEmpleado.ToString();
                    //cbxEmpleado.SelectedValue = cli.idEmpleado.ToString();
                    if (cli.Estatus.ToString() == "Activo")
                    { rbActivo.Checked = true; }
                    else if (cli.Estatus.ToString() == "Inactivo")
                    { rbInactivo.Checked = true; }

                    break;
                default:
                    break;
            }
        }
    }
}
