using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Modelo de los datos de Productos que sirve para almacenar los datos que se guardaran en los registros
    /// de la base de datos de la tabla Productos
    /// </summary>
    public class Productos
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla Productos de la base de datos
        /// </summary>
        public string codigoBarra { get; set; }
        public string nomProducto { get; set; }
        public string fechaRegistro { get; set; }
        public string idProveedores { get; set; }
        public string nomProveedor { get; set; }
        public bool Estatus { get; set; }

        /// <summary>
        /// Constructor del modelo que sirve para hacer referencia y crear instancias del modelo de Empleados
        /// lo cual permite usar los getters y setters en otras clases
        /// </summary>
        public Productos() { }

        /// <summary>
        /// Constructor que hace referencias al modelo de Productos el cual se utilizara para alamcenar los
        /// datos de un registro en la base de datos.
        /// </summary>
        /// <param name="codigoBarra">
        /// Parametro que recivira un string con el codigo de barras del producto a almacenar en un registro.
        /// </param>
        /// <param name="nomProducto">
        /// Parametro que recivira un string con el nombre del Prodcuto a almacenar en un registro.
        /// </param>
        /// <param name="fechaRegistro">
        /// Parametro que recivira un string con la fecha de registro de un producto a alamacenar
        /// </param>
        /// <param name="idProveedores">
        /// Parametro que recivira un string con el id del proveedor a almacenar en un registro.
        /// </param>
        /// <param name="nomProveedor">
        /// Parametro que recivira un string con el nombre del Proveedor a almacenar en un registro.
        /// </param>
        /// <param name="estatus">
        /// Parametro que recivira un Boolean con el estatus del producto a almacenar en un registro
        /// el estado solo puede ser activo o inactivo.
        /// </param>
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
