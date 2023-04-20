using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Almacen
    {
        public string idAlmacen { get; set; }
        public int cantProducto { get; set; }
        public int codigoBarra { get; set; }
        public string idEmpleado { get; set; }
        public bool Estatus { get; set; }

        public Almacen() { }

        public Almacen(string idAlmacen, int cantProducto, int codigoBarra, string idEmpleado, bool estatus)
        {
            this.idAlmacen = idAlmacen;
            this.cantProducto = cantProducto;
            this.codigoBarra = codigoBarra;
            this.idEmpleado = idEmpleado;
            Estatus = estatus;
        }
    }
}
