using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Productos
    {
        public string codigoBarra { get; set; }
        public string nomProducto { get; set; }
        public string fechaRegistro { get; set; }
        public string idProveedores { get; set; }
        public string nomProveedor { get; set; }
        public bool Estatus { get; set; }

        public Productos() { }

        public Productos(string codigoBarra, string nomProducto, string fechaRegistro, string idProveedores, string nomProveedor, bool estatus)
        {
            this.codigoBarra = codigoBarra;
            this.nomProducto = nomProducto;
            this.fechaRegistro = fechaRegistro;
            this.idProveedores = idProveedores;
            this.nomProveedor = nomProveedor;
            Estatus = estatus;
        }
    }
}
