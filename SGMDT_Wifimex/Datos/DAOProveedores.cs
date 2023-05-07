using Modelos;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    /// <summary>
    /// Clase DAOProveedores que contiene los metodos para realizar consultas, inserciones, actulizaciones y eliminacion
    /// de registros de la tabla Empleados de la base de datos del programa.   
    /// </summary>
    public class DAOProveedores
    {
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Proveedores.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Proveedores con todos los registros de la tabla Proveedores
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Proveedores> ObtenerProveedores() 
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from proveedores");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Proveedores> lista = new List<Proveedores>();
                    Proveedores objProveedores = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProveedores = new Proveedores();
                        objProveedores.idProveedores = (fila["idProveedores"].ToString());
                        objProveedores.nomProveedores = fila["nomProveedor"].ToString();
                        objProveedores.RFC = fila["RFC"].ToString();
                        objProveedores.Direccion = fila["Direccion"].ToString();
                        objProveedores.Telefono = fila["Telefono"].ToString();
                        objProveedores.Correo = fila["Correo"].ToString();
                        objProveedores.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProveedores.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objProveedores);
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
                throw new Exception("No se pudo obtener la información de los proveedores");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Proveedores que estan activos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Proveedores con todos los registros de la tabla Proveedores que esten
        /// en estado activo
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Proveedores> ObtenerProveedoresActivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from proveedores where Estatus=true");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Proveedores> lista = new List<Proveedores>();
                    Proveedores objProveedores = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProveedores = new Proveedores();
                        objProveedores.idProveedores = (fila["idProveedores"].ToString());
                        objProveedores.nomProveedores = fila["nomProveedor"].ToString();
                        objProveedores.RFC = fila["RFC"].ToString();
                        objProveedores.Direccion = fila["Direccion"].ToString();
                        objProveedores.Telefono = fila["Telefono"].ToString();
                        objProveedores.Correo = fila["Correo"].ToString();
                        objProveedores.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProveedores.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objProveedores);
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
                throw new Exception("No se pudo obtener la información de los proveedores");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Proveedores que estan inactivos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Proveedreos con todos los registros de la tabla Proveedores que esten
        /// en estado inactivo
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Proveedores> ObtenerProveedoresInactivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from proveedores where Estatus=false");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Proveedores> lista = new List<Proveedores>();
                    Proveedores objProveedores = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProveedores = new Proveedores();
                        objProveedores.idProveedores = (fila["idProveedores"].ToString());
                        objProveedores.nomProveedores = fila["nomProveedor"].ToString();
                        objProveedores.RFC = fila["RFC"].ToString();
                        objProveedores.Direccion = fila["Direccion"].ToString();
                        objProveedores.Telefono = fila["Telefono"].ToString();
                        objProveedores.Correo = fila["Correo"].ToString();
                        objProveedores.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProveedores.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objProveedores);
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
                throw new Exception("No se pudo obtener la información de los proveedores");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un objeto con el registros de la tabla de Proveedores que concidan con
        /// el ID propocionado.
        /// </summary>
        /// <param name="id">
        /// Parametro que recive un String con ID para buscar un registro en la tabla de Proveedores
        /// </param>
        /// <returns>
        /// Regresa una objeto de Tipo Provvedores con todos los registros de la tabla Proveedores que concidan
        /// con el ID propocionado.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public Proveedores ObtenerUnProveedor(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from proveedores where idProveedores=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Proveedores objProveedores = null;
                    if (resultado.Rows.Count > 0)
                    {
                        objProveedores = new Proveedores();
                        DataRow fila = resultado.Rows[0];
                        objProveedores = new Proveedores();

                        objProveedores.idProveedores = (fila["idProveedores"].ToString());
                        objProveedores.nomProveedores = (fila["nomProveedor"].ToString());
                        objProveedores.RFC = (fila["RFC"].ToString());
                        objProveedores.Direccion = (fila["Direccion"].ToString());
                        objProveedores.Telefono = (fila["Telefono"].ToString());
                        objProveedores.Correo = (fila["Correo"].ToString());
                        objProveedores.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProveedores.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                    }

                    return objProveedores;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la informacion del proveedor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo para realiar un nuevo registro en la tabla de Proveedores.
        /// </summary>
        /// <param name="ins">
        /// objeto de tipo Proveedores que recibira todos los datos para el nuevo registro
        /// de la tabla Proveedores.
        /// </param>
        /// <returns>
        /// Regresa una int con un valor de 1 si el registro se pudo realizar y un o si no se realizo el registro
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de que no se el registro no se pudo realizar mandara un mensaje donde indica
        /// quue no se pudo realizar el registro.
        /// </exception>
        public int AgregarProveedor(Proveedores ins)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "INSERT INTO proveedores VALUES(@idProveedores, @nomProveedor, @RFC, @Direccion, @Telefono, @Correo, @fechaRegistro, @Estatus);");
                    comando.Parameters.AddWithValue("@idProveedores", ins.idProveedores);
                    comando.Parameters.AddWithValue("@nomProveedor", ins.nomProveedores);
                    comando.Parameters.AddWithValue("@RFC", ins.RFC);
                    comando.Parameters.AddWithValue("@Direccion", ins.Direccion);
                    comando.Parameters.AddWithValue("@Telefono", ins.Telefono);
                    comando.Parameters.AddWithValue("@Correo", ins.Correo);
                    comando.Parameters.AddWithValue("@fechaRegistro", ins.fechaRegistro);
                    comando.Parameters.AddWithValue("@Estatus", Convert.ToInt32(ins.Estatus));
                    comando.Connection = Conexion.conexion;
                    return comando.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    Proveedores enf = new Proveedores();
                    enf = this.ObtenerUnProveedor(ins.idProveedores);
                    if (enf.Estatus.Equals(0))
                    {
                        MySqlCommand comando = new MySqlCommand(
                        "update proveedores set nomProveedor=@nomProveedor,RFC=@RFC,Direccion=@Direccion,Telefono=@Telefono,Correo=@Correo,fechaRegistro=@fechaRegistro,Estatus=1 " +
                        "where idProveedores=@idProveedores");
                        comando.Parameters.AddWithValue("@idProveedores", ins.idProveedores);
                        comando.Parameters.AddWithValue("@nomProveedor", ins.nomProveedores);
                        comando.Parameters.AddWithValue("@RFC", ins.RFC);
                        comando.Parameters.AddWithValue("@Direccion", ins.Direccion);
                        comando.Parameters.AddWithValue("@Telefono", ins.Telefono);
                        comando.Parameters.AddWithValue("@Correo", ins.Correo);
                        comando.Parameters.AddWithValue("@fechaRegistro", ins.fechaRegistro);
                        comando.Connection = Conexion.conexion;
                        return comando.ExecuteNonQuery();
                    }
                    else
                    {
                        return 0;
                    }
                }                
                else
                {
                    throw new Exception("No se ha podido agregar al proveedor");
                }
            }
            finally
            {
                Conexion.desconectar();
            }

        }
        /// <summary>
        /// Metodo para actualizar un registro de la tabla de Proveedores
        /// </summary>
        /// <param name="ins">
        /// objeto de tipo Proveedores que recibira todos los datos para la actulizacion
        /// del registro de la tabla Productos.
        /// </param>
        /// <returns>
        /// Regresa una variable de tipo Boolean con valor 1 0 true si el registro se pudo actulizar,
        /// y un valor de 0 o false si no se pudo actualizar el registro
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de que no se el registro no se pudo actulizar mandara un mensaje donde indica
        /// quue no se pudo realizar el registro.
        /// </exception>
        public bool ModificarProveedor(Proveedores ins)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "update proveedores set nomProveedor=@nomProveedor,RFC=@RFC,Direccion=@Direccion,Telefono=@Telefono,Correo=@Correo " +
                    "where idProveedores=@idProveedores");
                    comando.Parameters.AddWithValue("@idProveedores", ins.idProveedores);
                    comando.Parameters.AddWithValue("@nomProveedor", ins.nomProveedores);
                    comando.Parameters.AddWithValue("@RFC", ins.RFC);
                    comando.Parameters.AddWithValue("@Direccion", ins.Direccion);
                    comando.Parameters.AddWithValue("@Telefono", ins.Telefono);
                    comando.Parameters.AddWithValue("@Correo", ins.Correo);
                    comando.Connection = Conexion.conexion;
                    int filasEditadas = comando.ExecuteNonQuery();
                    return (filasEditadas > 0);
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo actualizar al proveedor");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que elimna un registro de la tabla de Proveedores
        /// </summary>
        /// <param name="id">
        /// Parametro que recive un String con un ID proporcionado para buscar un registro
        /// para su posterior eliminacion.
        /// </param>
        /// <returns>
        /// Regresa una variable de tipo Boolean con valor 1 0 true si el registro se pudo eliminar,
        /// y un valor de 0 o false si no se pudo elimnar el registro
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de que no el registro no se pudo eliminar mandara un mensaje donde indica
        /// quue no se pudo realizar el registro.
        /// </exception>
        public bool EliminarProveedor(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"delete from proveedores where idProveedores=@Id");
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
                    try
                    {
                        MySqlCommand comando = new MySqlCommand(
                        @"update proveedores set Estatus=false where idProveedores=@Id");
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Connection = Conexion.conexion;
                        int filasBorradas = comando.ExecuteNonQuery();
                        return (filasBorradas > 0);
                    }
                    catch
                    {
                        throw new Exception("Proveedor ya eliminado");
                    }
                }
                else
                {
                    throw new Exception("Error al intentar eliminar al proveedor");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que Realiza consultas para obtener registros de la tabla Proveedores.
        /// </summary>
        /// <param name="text">
        /// Parametro de entrada que recive una variable de tipo String que contiene una cadena
        /// de texto que se utilizara para buscar concidencias con los registros de la tabla Proveedores.
        /// </param>
        /// <returns>
        /// Regresa una lista de registros de la tabla Proveedores que concidan con la cadena de texto que
        /// se proporciono.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de Proveedores mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
        public List<Proveedores> Buscar(string text)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"select * from proveedores 
	                    where
	                    idProveedores like  CONCAT('%', @ref, '%') || 
	                    nomProveedor like  CONCAT('%', @ref, '%') || 
	                    RFC like  CONCAT('%', @ref, '%') ||
	                    Direccion like  CONCAT('%', @ref, '%') || 
	                    Telefono like  CONCAT('%', @ref, '%') || 
	                    Correo like  CONCAT('%', @ref, '%') || 
	                    fechaRegistro like  CONCAT('%', @ref, '%');"
                    );
                    comando.Parameters.AddWithValue("@ref", text);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Proveedores> lista = new List<Proveedores>();
                    Proveedores objProveedor = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        if (Convert.ToInt32(fila["Estatus"]).Equals(1)) 
                        {
                            objProveedor = new Proveedores();
                            objProveedor.idProveedores = fila["idProveedores"].ToString();
                            objProveedor.nomProveedores = fila["nomProveedor"].ToString();
                            objProveedor.RFC = fila["RFC"].ToString();
                            objProveedor.Direccion = fila["Direccion"].ToString();
                            objProveedor.Telefono = fila["Telefono"].ToString();
                            objProveedor.Correo = fila["Correo"].ToString();
                            objProveedor.fechaRegistro = fila["fechaRegistro"].ToString();
                            objProveedor.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);

                            lista.Add(objProveedor);
                        }
                        
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
                throw new Exception("No se pudo obtener la información de los proveedores");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
