using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos
{
    /// <summary>
    /// Modelo de los datos de Contrato que sirve para guardar los datos que se guardaran en los registros
    /// de la base de datos de la tabla Contratos
    /// </summary>
    public class Contrato
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla Contratos de la base de datos
        /// </summary>
        public string idContrato { get; set; }
        public double precioServicio { get; set; }
        public string inicioContrato { get; set; }
        public string finContrato { get; set; }
        public string idCliente { get; set; }
        public String Estatus { get; set; }

        /// <summary>
        /// Constructor que hace referencias al modelo de Contrato el cual se utilizara para alamcenar los
        /// datos de un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="idContrato">
        /// Parametro que recivira un string con el id del contrato a almacenar en un registro.
        /// </param>
        /// <param name="precioServicio">
        /// Parametro que recivira un double con el precio del servicio del 
        /// contrato a almacenar en un registro.
        /// </param>
        /// <param name="inicioContrato">
        /// Parametro que recivira un string con la fecha de inicio
        /// del contrato a almacenar en un registro.
        /// </param>
        /// <param name="finContrato">
        /// Parametro que recivira un string con la fehca de finalizacion del contrato
        /// contrato a almacenar en un registro.
        /// </param>
        /// <param name="idCliente">
        /// Parametro que recivira un string con el id del cliente a almacenar en un registro.
        /// </param>
        /// <param name="estatus">
        /// Parametro que recivira un string con el estatus del Contrato a almacenar en un registro
        /// el estado solo puede ser activo o inactivo.
        /// </param>
        public Contrato(string idContrato, double precioServicio, string inicioContrato, string finContrato, string idCliente, string estatus)
        {
            this.idContrato = idContrato;
            this.precioServicio = precioServicio;
            this.inicioContrato = inicioContrato;
            this.finContrato = finContrato;
            this.idCliente = idCliente;
            Estatus = estatus;
        }

        /// <summary>
        /// Constructor del modelo que sirve para hacer referencia y crear instancias del modelo de Contrato
        /// lo cual permite usar los getters y setters en otras clases
        /// </summary>
        public Contrato() { }
    }
}
