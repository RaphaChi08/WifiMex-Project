using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class DAOCliente
    {
        public List<Cliente> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM clientes");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Cliente> lista = new List<Cliente>();
                    Cliente objCliente = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objCliente = new Cliente();
                        objCliente.idCliente = fila["idCliente"].ToString();
                        objCliente.RFC = fila["RFC"].ToString();
                        objCliente.CURP = fila["CURP"].ToString();
                        objCliente.nomCliente = fila["nomCliente"].ToString();
                        objCliente.Direccion = fila["Direccion"].ToString();
                        objCliente.Telefono = fila["Telefono"].ToString();
                        objCliente.Correo = fila["Correo"].ToString();
                        objCliente.Estatus = fila["Estatus"].ToString()=="True"?"Activo":"Inactivo";

                        lista.Add(objCliente);
                    }

                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información de los clientes");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<Cliente> Buscar( string text)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"select * from clientes 
	                    where
	                    idCliente like  CONCAT('%', @ref, '%') || 
	                    RFC like  CONCAT('%', @ref, '%') || 
	                    CURP like  CONCAT('%', @ref, '%') ||
	                    nomCliente like  CONCAT('%', @ref, '%') || 
	                    Direccion like  CONCAT('%', @ref, '%') || 
	                    Telefono like  CONCAT('%', @ref, '%') || 
	                    Correo like  CONCAT('%', @ref, '%');"
                    );
                    comando.Parameters.AddWithValue("@ref", text);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Cliente> lista = new List<Cliente>();
                    Cliente objCliente = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objCliente = new Cliente();
                        objCliente.idCliente = fila["idCliente"].ToString();
                        objCliente.RFC = fila["RFC"].ToString();
                        objCliente.CURP = fila["CURP"].ToString();
                        objCliente.nomCliente = fila["nomCliente"].ToString();
                        objCliente.Direccion = fila["Direccion"].ToString();
                        objCliente.Telefono = fila["Telefono"].ToString();
                        objCliente.Correo = fila["Correo"].ToString();
                        objCliente.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";

                        lista.Add(objCliente);
                    }

                    return lista;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información de los clientes");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Cliente ObtenerUno(String id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(@"SELECT * FROM clientes WHERE idCliente=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Cliente objCliente = null;
                    if (resultado.Rows.Count > 0)
                    {
                        DataRow fila = resultado.Rows[0];
                        objCliente = new Cliente();
                        objCliente.idCliente = fila["idCliente"].ToString();
                        objCliente.RFC = fila["RFC"].ToString();
                        objCliente.CURP = fila["CURP"].ToString();
                        objCliente.nomCliente = fila["nomCliente"].ToString();
                        objCliente.Direccion = fila["Direccion"].ToString();
                        objCliente.Telefono = fila["Telefono"].ToString();
                        objCliente.Correo = fila["Correo"].ToString();
                        objCliente.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";
                    }

                    return objCliente;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del cliente");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool eliminar(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"DELETE FROM clientes
                        WHERE idCliente=@id");

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"update clientes set Estatus=0
                        WHERE idCliente=@id");

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("Error al intentar eliminar al cliente");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool editar(Cliente cliente)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE `dbwifimex`.`clientes` SET 
                        `RFC` = @rfc, 
                        `CURP` = @curp, 
                        `nomCliente` = @name, 
                        `Direccion` = @dir, 
                        `Telefono` = @num, 
                        `Correo` = @corr, 
                        `Estatus` = @estatus
                        WHERE (`idCliente` = @id);");

                    comando.Parameters.AddWithValue("@id", cliente.idCliente);
                    comando.Parameters.AddWithValue("@rfc", cliente.RFC);
                    comando.Parameters.AddWithValue("@curp", cliente.CURP);
                    comando.Parameters.AddWithValue("@name", cliente.nomCliente);
                    comando.Parameters.AddWithValue("@dir", cliente.Direccion);
                    comando.Parameters.AddWithValue("@num", cliente.Telefono);
                    comando.Parameters.AddWithValue("@corr", cliente.Correo);
                    comando.Parameters.AddWithValue("@estatus", cliente.Estatus=="Activo"?1:0);

                    comando.Connection = Conexion.conexion;

                    int filasBorradas = comando.ExecuteNonQuery();

                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo editar la info del cliente");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public int agregar(Cliente cliente)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        "INSERT INTO `dbwifimex`.`clientes` " +
                        "(`idCliente`, `RFC`, `CURP`, `nomCliente`, `Direccion`, `Telefono`, `Correo`, `Estatus`) VALUES" +
                        "(@id, @rfc, @curp, @name, @dir, @num, @corr, '1');");

                    comando.Parameters.AddWithValue("@id", cliente.idCliente);
                    comando.Parameters.AddWithValue("@rfc", cliente.RFC);
                    comando.Parameters.AddWithValue("@curp", cliente.CURP);
                    comando.Parameters.AddWithValue("@name", cliente.nomCliente);
                    comando.Parameters.AddWithValue("@dir", cliente.Direccion);
                    comando.Parameters.AddWithValue("@num", cliente.Telefono);
                    comando.Parameters.AddWithValue("@corr", cliente.Correo);
                    comando.Connection = Conexion.conexion;

                    int filasAgregadas = comando.ExecuteNonQuery();

                    return filasAgregadas;
                }
                else
                {
                    return -1;
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo agregar, intentelo de nuevo o comuniquese con el administrador");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

    }
}
