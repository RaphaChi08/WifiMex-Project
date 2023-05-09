using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Modelo de los datos de Proveedores que sirve para alamacenar los datos que se guardaran en los registros
    /// de la base de datos de la tabla Empleados
    /// </summary>
    public class Proveedores
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla Proveedores de la base de datos
        /// </summary>
        public string idProveedores { get; set; }
        public string nomProveedores { get; set; }
        public string RFC { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string fechaRegistro { get; set; }
        public bool Estatus { get; set; }

        /// <summary>
        /// Constructor del modelo que sirve para hacer referencia y crear instancias del modelo de Proveedores
        /// lo cual permite usar los getters y setters en otras clases
        /// </summary>
        public Proveedores() { }

        /// <summary>
        /// Constructor que hace referencias al modelo de Proveedores el cual se utilizara para alamcenar los
        /// datos de un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="idProveedores">
        /// Parametro que recivira un string con el id del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="nomProveedores">
        /// Parametro que recivira un string con el nombre del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="RFC">
        /// Parametro que recivira un string con el RFC del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="Direccion">
        /// Parametro que recivira un string con la direccion del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="Telefono">
        /// Parametro que recivira un string con el telefono del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="Correo">
        /// Parametro que recivira un string con el correro del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="fechaRegistro">
        /// Parametro que recivira un string con la fecha de Registro
        /// del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="Estatus">
        /// Parametro que recivira un Boolean con el estatus del Proveedor a almacenar en un registro
        /// el estado solo puede ser activo o inactivo.
        /// </param>
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
