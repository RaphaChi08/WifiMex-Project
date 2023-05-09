using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Modelo de los datos de Cliente que sirve para guardar los datos que se guardaran en los registros
    /// de la base de datos de la tabla clientes
    /// </summary>
    public class Cliente
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla clientes de la base de datos
        /// </summary>
        public string idCliente { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public string nomCliente { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Estatus { get; set; }

        /// <summary>
        /// Constructor del modelo que sirve para hacer referencia y crear instancias del modelo de clientes
        /// lo cual permite usar los getters y setters en otras clases
        /// </summary>
        public Cliente() { }

        /// <summary>
        /// Constructor que hace referencias al modelo de Cliente el cual se utilizara para alamcenar los
        /// datos de un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="idCliente">
        /// Parametro que recivira un string con el id del cliente a almacenar en un registro.
        /// </param>
        /// <param name="rFC">
        /// Parametro que recivira un string con el RFC del cliente a almacenar en un registro.
        /// </param>
        /// <param name="cURP">
        /// Parametro que recivira un string con la CURP del cliente a almacenar en un registro.
        /// </param>
        /// <param name="nomCliente">
        /// Parametro que recivira un string con el nombre del cliente a almacenar en un registro.
        /// </param>
        /// <param name="direccion">
        /// Parametro que recivira un string con la direccion del cliente a almacenar en un registro.
        /// </param>
        /// <param name="telefono">
        /// Parametro que recivira un string con el telefono del cliente a almacenar en un registro.
        /// </param>
        /// <param name="correo">
        /// Parametro que recivira un string con el correro del cliente a almacenar en un registro.
        /// </param>
        /// <param name="estatus">
        /// Parametro que recivira un string con el estatus del cliente a almacenar en un registro
        /// el estado solo puede ser activo o inactivo.
        /// </param>
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
