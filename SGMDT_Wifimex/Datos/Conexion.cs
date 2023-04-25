using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class Conexion
    {
        public static MySqlConnection conexion;
        public static MySqlTransaction transaccion;
        static string usuario = "root";
        static string password = "1234";
        static string bd = "dbwifimex";
        static string servidor = "localhost";
        static string puerto = "3306";

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
