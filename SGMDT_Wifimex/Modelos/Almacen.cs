using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Modelo de los datos de Alamacen que sirve para guardar los datos que se guardaran en los registros
    /// de la base de datos
    /// </summary>
    public class Almacen
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla Almacen de la base de datos
        /// </summary>
        public string idAlmacen { get; set; }
        public int cantProducto { get; set; }
        public string codigoBarra { get; set; }
        public string idEmpleado { get; set; }
        public string Estatus { get; set; }

        /// <summary>
        /// Constructor de la clase vacio que no recibe ningun parametro
        /// </summary>
        public Almacen() { }

        /// <summary>
        /// Constructor que recivira parametros para guardar algun registro.
        /// </summary>
        /// <param name="idAlmacen">
        /// Parametro que recibira un String con id del almacen a alamcenar en un registro
        /// </param>
        /// <param name="cantProducto">
        /// Parametro que recibira un int con la cantidad de productos a almacen un registro
        /// </param>
        /// <param name="codigoBarra">
        /// Parametro que recibira un string con el codigo de barra a almacen un registro
        /// </param>
        /// <param name="idEmpleado">
        /// Parametro que recibira un string con el id de un empleado a almacen un registro
        /// </param>
        /// <param name="estatus">
        /// Parametro que recibira un string que indica si el producto a almacenar esta activo o inactivo.
        /// </param>
        public Almacen(string idAlmacen, int cantProducto, string codigoBarra, string idEmpleado, string estatus)
        {
            this.idAlmacen = idAlmacen;
            this.cantProducto = cantProducto;
            this.codigoBarra = codigoBarra;
            this.idEmpleado = idEmpleado;
            Estatus = estatus;
        }
    }
}
