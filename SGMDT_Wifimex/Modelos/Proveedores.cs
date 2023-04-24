using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    public class Proveedores
    {
        public string idProveedores { get; set; }
        public string nomProveedores { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string fechaRegistro { get; set; }
        public bool Estatus { get; set; }

        public Proveedores() { }

        public Proveedores(string idProveedores, string nomProveedores, string RFC, string Direccion, string Telefono, string Correo, string fechaRegistro, bool Estatus) 
        {
            this.idProveedores = idProveedores;
            this.nomProveedores = nomProveedores;
            this.RFC = RFC;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
            this.Correo = Correo;
            this.fechaRegistro = fechaRegistro;
            this.Estatus = Estatus;
        }
    }
}
