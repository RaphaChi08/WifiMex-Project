using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Cliente
    {
        public string idCliente { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string nomCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estatus { get; set; }
        public Cliente() { }

        public Cliente(string idCliente, string rFC, string cURP, string nomCliente, string direccion, string telefono, string correo, string estatus)
        {
            this.idCliente = idCliente;
            RFC = rFC;
            CURP = cURP;
            this.nomCliente = nomCliente;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            Estatus = estatus;
        }
    }
}
