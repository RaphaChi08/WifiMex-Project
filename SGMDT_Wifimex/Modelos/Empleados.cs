using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
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
        public Empleados(){}

        public Empleados(string IdEmpleado, string nombreCompleto, string Rfc, string Curp, int edad,
            string direccion, string telefono,string correo, string fechacontra, string rol, bool estatus)
        {
            idempleado = IdEmpleado;
            nombrecompleto = nombreCompleto;
            RFC = Rfc;
            CURP = Curp;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            fechaContratacion = fechacontra;
            Rol = rol;
            Estatus = estatus;
        }
    }
}
