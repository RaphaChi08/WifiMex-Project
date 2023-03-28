using Modelos;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
     public class DAOEmpleados
    {
        public Empleados IniciarSeccion(string usuario, string password)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("SELECT * FROM Empleados WHERE idEmpleado=@Usuario AND password=sha1(@Password) and StatusEmployee=1");
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Password", password);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Empleados objUsuario = null;
                    if (resultado.Rows.Count > 0 && resultado.Rows.Count == 1)
                    {
                        objUsuario = new Empleados(
                            resultado.Rows[0]["idEmpleado"].ToString(),
                            resultado.Rows[0]["nombrecompleto"].ToString()
                            );
                    }
                    return objUsuario;
                }
                else
                {
                    throw new Exception("No se a podido conectar con el servidor");
                }
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
