using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Empleados
    {
        public string idempleado { get; set; }
        public string nombrecompleto { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string fechaContratacion { get; set; }
        public string Rol { get; set; }
        public bool Estatus { get; set; }
    }
}
