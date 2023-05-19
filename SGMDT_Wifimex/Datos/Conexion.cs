using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    /// <summary>
    /// Clase En la Cual se definen lass variales y un metodo que permitira la conexion hacia la base de datos del programa.
    /// </summary>
    public class Conexion
    {
        /// <summary>
        /// MySqlConnection variable que perimte la conexoin hacia la base de datos.
        /// usuario variable tipo string que almacena el nombre de usuario de la base de datos.
        /// password variable tipo string que alamacena la contraseña de la base de datos.
        /// bd variable de tipo string que almacena el nombre de la base de datos.
        /// servidor variable de tipo string que alamcena el nombre del servidor de la base de datos.
        /// puerto variable de tipo string que almacena el puerto en el que esta el servidor qe alamcena la base de datos.
        /// </summary>
        public static MySqlConnection conexion;
        public static MySqlTransaction transaccion;
        static string usuario = "root";
        static string password = "1234";
        static string bd = "dbwifimex";
        static string servidor = "localhost";
        static string puerto = "3306";

        /// <summary>
        /// Metedo de Conecxion en este metodo se define la conexion hacia la base de datos que contiene la informacion 
        /// sobre la empresa a la que se le realizo el programa
        /// </summary>
        /// <returns>
        /// Regresa un valor Booleano de verdadero en caso de que la conexion se pudiera realizar con exito.
        /// Regresa un valor Booleano de falso en caso de que la conexion  no se pudo extablecer.
        /// </returns>
        public static bool conectar()
        {
            try
            {
                conexion = new MySqlConnection("Database=" + bd + ";Data Source=" + servidor
                    + ";Port=" + puerto + ";User Id=" + usuario + ";Password=" + password);

                conexion.Open();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public static void desconectar()
        {
            try
            {
                conexion.Close();
            }
            catch (Exception)
            {

            }
        }
    }
}
