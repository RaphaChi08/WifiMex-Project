using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;

namespace Datos
{
    /// <summary>
    /// Clase DAOContratos que contiene los metodos para realizar consultas, inserciones, actulizaciones y eliminacion
    /// de registros de la tabla Contratos de la base de datos del programa.   
    /// </summary>
    public class DAOContratos
    {

        /// <summary>
        /// Metodo que Obtiene todos los registros de la tabla de Contratos.
        /// </summary>
        /// <returns>
        /// Regresa una lista con todos los registros de la tabla de Contratos
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se puede conctar al servidor de la base de datos se madara un mensaje
        /// que indica que no se pudo conectar al servidro.
        /// En caso de que no se pueda encotrar los registros mandara un mensaje indicando donde
        /// indica que no se ecnontraron registros.
        /// </exception>
        public List<Contrato> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM contratos");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Contrato> lista = new List<Contrato>();
                    Contrato objContrato = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objContrato = new Contrato();
                        objContrato.idContrato = fila["idContrato"].ToString();
                        objContrato.precioServicio = double.Parse(fila["precioServicio"].ToString());
                        objContrato.inicioContrato = fila["inicioContrato"].ToString();
                        objContrato.finContrato = fila["finContrato"].ToString();
                        objContrato.idCliente = fila["idCliente"].ToString();
                        objContrato.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";

                        lista.Add(objContrato);
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
                throw new Exception("No se pudo obtener la información de los contratos");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que Realiza consultas para obtener registros de la tabla Contratos.
        /// </summary>
        /// <param name="text">
        /// Parametro de entrada que recive una variable de tipo String que contiene una cadena
        /// de texto que se utilizara para buscar concidencias con los registros de la tabla Contratos.
        /// </param>
        /// <returns>
        /// Regresa una lista de registros de la tabla Contratos que concidan con la cadena de texto que
        /// se proporciono.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de Contratos mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
        public List<Contrato> Buscar(string text)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"select * from contratos 
	                    where
	                    idContrato like  CONCAT('%', @ref, '%') || 
	                    precioServicio like  CONCAT('%', @ref, '%') || 
	                    inicioContrato like  CONCAT('%', @ref, '%') ||
	                    finContrato like  CONCAT('%', @ref, '%') || 
	                    idCliente like  CONCAT('%', @ref, '%');"
                    );
                    comando.Parameters.AddWithValue("@ref", text);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Contrato> lista = new List<Contrato>();
                    Contrato objContrato = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objContrato = new Contrato();
                        objContrato.idContrato = fila["idContrato"].ToString();
                        objContrato.precioServicio = double.Parse(fila["precioServicio"].ToString());
                        objContrato.inicioContrato = fila["inicioContrato"].ToString();
                        objContrato.finContrato = fila["finContrato"].ToString();
                        objContrato.idCliente = fila["idCliente"].ToString();
                        objContrato.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";

                        lista.Add(objContrato);
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
                throw new Exception("No se pudo obtener la información de los contratos");
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
        /// en la tabla de Contratos
        /// </param>
        /// <returns>
        /// regresa una objeto de tipo Contrato qe contendra toda la informacion del regristo
        /// que conicida con el id proporcionado.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de Contratos mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
        public Contrato ObtenerUno(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(@"SELECT * FROM contratos WHERE idContrato=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Contrato objContrato = null;
                    if (resultado.Rows.Count > 0)
                    {
                        DataRow fila = resultado.Rows[0];
                        objContrato = new Contrato();
                        objContrato.idContrato = fila["idContrato"].ToString();
                        objContrato.precioServicio = double.Parse(fila["precioServicio"].ToString());
                        objContrato.inicioContrato = fila["inicioContrato"].ToString();
                        objContrato.finContrato = fila["finContrato"].ToString();
                        objContrato.idCliente = fila["idCliente"].ToString();
                        Console.WriteLine(fila["Estatus"].ToString());
                        objContrato.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";
                    }

                    return objContrato;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del contrato");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que permite eliminar un registro de la tabla Contratos medinte un id proporcionado.
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
                        @"DELETE FROM contratos
                        WHERE idContrato=@id");

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
                        @"update contratos set Estatus=0
                        WHERE idContrato=@id");

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("Error al intentar eliminar el contrato");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que permite Actulizar regsitros de la tabla Contratos.
        /// </summary>
        /// <param name="contrato">
        /// Parametro de tipo Contrato que recibira todos los datos del registro selecionado para su actulizacion.
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
        public bool editar(Contrato contrato)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE `dbwifimex`.`contratos` SET 
                        `precioServicio` = @cost, 
                        `inicioContrato` = @ini,
                        `idCliente` = @idc,
                        `finContrato` = @fin, 
                        `Estatus` = @estatus WHERE (`idContrato` = @id);"
                    );
                    comando.Parameters.AddWithValue("@id", contrato.idContrato);
                    comando.Parameters.AddWithValue("@cost", contrato.precioServicio);
                    comando.Parameters.AddWithValue("@ini", contrato.inicioContrato);
                    comando.Parameters.AddWithValue("@fin", contrato.finContrato);
                    comando.Parameters.AddWithValue("@idc", contrato.idCliente);
                    comando.Parameters.AddWithValue("@estatus", contrato.Estatus == "Activo" ? 1 : 0);

                    comando.Connection = Conexion.conexion;

                    int filasBorradas = comando.ExecuteNonQuery();

                    return (filasBorradas > 0);
                }
                else
                {
                    return false;
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo editar la info del contrato");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que permite agregar registros a al tabla de Contratos.
        /// </summary>
        /// <param name="contrato">
        /// Parametro tipo Contrato que recibe todos los datos del nuevo registro para su posterior
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
        public int agregar(Contrato contrato)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        "INSERT INTO `dbwifimex`.`contratos` " +
                        "(`idContrato`, `precioServicio`, `inicioContrato`, `finContrato`, `idCliente`, `Estatus`) VALUES " +
                        "(@id,@cost , @ini, @fin, @idc, '1')");

                    comando.Parameters.AddWithValue("@id", contrato.idContrato);
                    comando.Parameters.AddWithValue("@cost", contrato.precioServicio);
                    comando.Parameters.AddWithValue("@ini", contrato.inicioContrato);
                    comando.Parameters.AddWithValue("@fin", contrato.finContrato);
                    comando.Parameters.AddWithValue("@idc", contrato.idCliente);
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
