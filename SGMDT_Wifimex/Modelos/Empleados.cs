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
    /// <summary>
    /// Modelo de los datos de Empleados que sirve para guardar los datos que se guardaran en los registros
    /// de la base de datos de la tabla Empleados
    /// </summary>
    public class Empleados
    {
        /// <summary>
        /// Parametros o getters y setters que resiven los valores para guardar los registros
        /// de la tabla Empleados de la base de datos
        /// </summary>
        public string Idempleado { get; set; }
        public string Nombrecompleto { get; set; }
        public string RFC { get; set; }
        public string CURP { get; set; }
        public int Edad { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string fechaContratacion { get; set; }
        public string Rol { get; set; }
        public string Password { get; set; }
        public bool Estatus { get; set; }

        /// <summary>
        /// Constructor del modelo que sirve para hacer referencia y crear instancias del modelo de Empleados
        /// lo cual permite usar los getters y setters en otras clases
        /// </summary>
        public Empleados(){}

        /// <summary>
        /// Constructor que hace referencias al modelo de Empleados el cual se utilizara para alamcenar los
        /// datos de un nuevo registro en la base de datos.
        /// </summary>
        /// <param name="IdEmpleado">
        /// Parametro que recivira un string con el id del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="nombreCompleto">
        /// Parametro que recivira un string con el nombre del Empleadoso a almacenar en un registro.
        /// </param>
        /// <param name="Rfc">
        /// Parametro que recivira un string con el RFC del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="Curp">
        /// Parametro que recivira un string con la CURP del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="edad">
        /// Parametro que recivira un int con la edad del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="direccion">
        /// Parametro que recivira un string con la direccion del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="telefono">
        /// Parametro que recivira un string con el telefono del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="correo">
        /// Parametro que recivira un string con el correro del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="fechacontra">
        /// Parametro que recivira un string con la fecha de contratacion
        /// del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="rol">
        /// Parametro que recivira un string con el Rol o puesto del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="password">
        /// Parametro que recivira un string con la contraseña del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="estatus">
        /// Parametro que recivira un Boolean con el estatus del Empleado a almacenar en un registro
        /// el estado solo puede ser activo o inactivo.
        /// </param>
        public Empleados(string IdEmpleado, string nombreCompleto, string Rfc, string Curp, int edad,
            string direccion, string telefono,string correo, string fechacontra, string rol, string password, bool estatus)
        {
            Idempleado = IdEmpleado;
            Nombrecompleto = nombreCompleto;
            RFC = Rfc;
            CURP = Curp;
            Edad = edad;
            Direccion = direccion;
            Telefono = telefono;
            Correo = correo;
            fechaContratacion = fechacontra;
            Rol = rol;
            Password = password;
            Estatus = estatus;
        }
        /// <summary>
        /// Constructor que recibe dos parametros los cuales sirven para hacer un login.
        /// </summary>
        /// <param name="idempleado">
        /// Parametro que recivira un string con el id del Empleado a almacenar en un registro.
        /// </param>
        /// <param name="nombreCompleto">
        /// Parametro que recivira un string con el nombre del Empleadoso a almacenar en un registro.
        /// </param>
        public Empleados(string idempleado, string nombreCompleto)
        {
            this.Idempleado = idempleado;
            Nombrecompleto = nombreCompleto;
        }
    }
}
