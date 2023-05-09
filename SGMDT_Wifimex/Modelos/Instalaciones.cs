using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Modelo de los datos de Instalaciones que sirve para guardar los datos que se guardaran en los registros
    /// de la base de datos de la tabla Instalaciones
    /// </summary>
    public class Instalaciones
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla Instalaciones de la base de datos
        /// </summary>
        public string IdInstalacion { get; set; }
        public string fechaInstalacin { get; set; }
        public string idEmpelado { get; set; }

        public string idContratos { get; set; }
        public bool Estatus { get; set; }

        /// <summary>
        /// Constructor del modelo que sirve para hacer referencia y crear instancias del modelo de Empleados
        /// lo cual permite usar los getters y setters en otras clases
        /// </summary>
        public Instalaciones() { }

        /// <summary>
        /// Constructor que hace referencias al modelo de Instalaciones el cual se utilizara para alamcenar los
        /// datos de un registro en la base de datos.
        /// </summary>
        /// <param name="idInstalacion">
        /// Parametro que recivira un string con el id la Instalacion a almacenar en un registro.
        /// </param>
        /// <param name="fechaInstalacin">
        /// Parametro que recivira un string con la fecha de la Instlacion
        /// a almacenar en un registro.
        /// </param>
        /// <param name="idEmpelado">
        /// Parametro que recivira un string con el id del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="idContratos">
        /// Parametro que recivira un string con el id del Contrato a almacenar en un registro.
        /// </param>
        /// <param name="estatus">
        /// Parametro que recivira un Boolean con el estatus de la Instalacion a almacenar en un registro
        /// el estado solo puede ser activo o inactivo.
        /// </param>
        public Instalaciones(string idInstalacion, string fechaInstalacin, string idEmpelado, string idContratos, bool estatus)
        {
            IdInstalacion = idInstalacion;
            this.fechaInstalacin = fechaInstalacin;
            this.idEmpelado = idEmpelado;
            this.idContratos = idContratos;
            Estatus = estatus;
        }
    }
}
