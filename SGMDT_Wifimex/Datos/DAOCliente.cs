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
    /// <summary>
    /// Clase DAOCliente que contiene los metodos para realizar consultas, inserciones, actulizaciones y eliminacion
    /// de registros de la tabla Clientes de la base de datos del programa.    
    /// </summary>
    public class DAOCliente
    {
        /// <summary>
        /// Metodo que Realiza una consulta en la tabla de Clientes para obeneter todos los
        /// registros de la tabla.
        /// </summary>
        /// <returns>
        /// Regresa un Lista de tipo Cliente que contiene todos los regsitros de la tabla de clientes.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de clientes mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
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
        /// <summary>
        /// Metodo que Realiza consultas para obtener registros de la tabla clientes.
        /// </summary>
        /// <param name="text">
        /// Parametro de entrada que recive una variable de tipo String que contiene una cadena
        /// de texto que se utilizara para buscar concidencias con los registros de la tabla clientes.
        /// </param>
        /// <returns>
        /// Regresa una lista de registros de la tabla clientes que concidan con la cadena de texto que
        /// se proporciono.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de clientes mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
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
        /// <summary>
        /// Metodo que realiza una consulta para obtener un registro en base a id proporcionado
        /// </summary>
        /// <param name="id">
        /// Paramatro que recibe un variable de tipo String con la que se realizara una busqueda
        /// en la tabla de clientes
        /// </param>
        /// <returns>
        /// regresa una objeto de tipo cliente qe contendra toda la informacion del regristo
        /// que conicida con el id proporcionado.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de clientes mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
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
        /// <summary>
        /// Metodo que permite eliminar un registro de la tabla cliente medinte un id proporcionado.
        /// </summary>
        /// <param name="id">
        /// Parametro que recive una variable de tipo String que contiene un id para realizar un
        /// consulta que concida con el id proporcionado.
        /// </param>
        /// <returns>
        /// Regresara una variable de tipo Boolean con el valor 1 o true si el registro se elimino con exito.
        /// en caso de lo contrario regresara un valor 0 o false si no se logro eliminar el registro.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se ecnuentre el registro o no se pueda elimnar mandara un mensaje donde indica
        /// que no se pudo eliminar el registro.
        /// </exception>
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
        /// <summary>
        /// Metodo que permite Actulizar regsitros de la tabla clientes.
        /// </summary>
        /// <param name="cliente">
        /// Parametro de tipo cliente que recibira todos los datos del registro selecionado para su actulizacion.
        /// </param>
        /// <returns>
        /// Regresa una variable de tipo Boolean con un valor de 1 o true cuando el registro se pudo realar con exito,
        /// en caso de lo contrario regresara un valor 0 o false.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caos de que la actualizacion no se pudo realizar madara un mensaje que indique que no se pudo
        /// realizar la actulizacion del registro.
        /// </exception>
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
        /// <summary>
        /// Metodo que permite agregar registros a al tabla de clientes.
        /// </summary>
        /// <param name="cliente">
        /// Parametro tipo cliente que recibe todos los datos del nuevo registro para su posterior
        /// alamacenamiento de registro.
        /// </param>
        /// <returns>
        /// Regresa una variable de tipo int con el valor de 1 si el registro se realizo con exito
        /// y o en caso de que el registro no se logro realizar.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caos de que la incercion no se pudo realizar madara un mensaje que indique que no se pudo
        /// realizar la agrgacion del registro.
        /// </exception>
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
