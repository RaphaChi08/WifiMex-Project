using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos;
using MySql.Data.MySqlClient;
using System.Data;

namespace Datos
{
    /// <summary>
    /// Clase DAOIntalaciones que contiene los metodos para realizar consultas, inserciones y actulizaciones
    /// de registros de la tabla Instalaciones de la base de datos del programa.   
    /// </summary>
    public class DAOInstalaciones
    {
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Instalaciones.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Instalaciones con todos los registros de la tabla Instalaciones.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistema mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Instalaciones> ObtenerInstalaciones()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from instalaciones");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Instalaciones> lista = new List<Instalaciones>();
                    Instalaciones objInstalacion = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInstalacion = new Instalaciones();
                        objInstalacion.IdInstalacion = (fila["idInstalacion"].ToString());
                        objInstalacion.fechaInstalacin = fila["fechaInstalacion"].ToString();
                        objInstalacion.idEmpelado = fila["idEmpleado"].ToString();
                        objInstalacion.idContratos = fila["idContrato"].ToString();
                        objInstalacion.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objInstalacion);
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
                throw new Exception("No se pudo obtener la información de la instalacion");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Instalaciones que estan activos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Instalaciones con todos los registros de la tabla Instalaciones que esten
        /// en estado activo
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Instalaciones> ObtenerInstalacionesActivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from instalaciones where Estatus=true");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Instalaciones> lista = new List<Instalaciones>();
                    Instalaciones objInstalacion = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInstalacion = new Instalaciones();
                        objInstalacion.IdInstalacion = (fila["idInstalacion"].ToString());
                        objInstalacion.fechaInstalacin = fila["fechaInstalacion"].ToString();
                        objInstalacion.idEmpelado = fila["idEmpleado"].ToString();
                        objInstalacion.idContratos = fila["idContrato"].ToString();
                        objInstalacion.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objInstalacion);
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
                throw new Exception("No se pudo obtener la información de la instalacion");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Instalciones que estan inactivos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Instalaciones con todos los registros de la tabla Instalaciones que esten
        /// en estado inactivo
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Instalaciones> ObtenerInstalacionesInactivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from instalaciones where Estatus=false");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Instalaciones> lista = new List<Instalaciones>();
                    Instalaciones objInstalacion = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInstalacion = new Instalaciones();
                        objInstalacion.IdInstalacion = (fila["idInstalacion"].ToString());
                        objInstalacion.fechaInstalacin = fila["fechaInstalacion"].ToString();
                        objInstalacion.idEmpelado = fila["idEmpleado"].ToString();
                        objInstalacion.idContratos = fila["idContrato"].ToString();
                        objInstalacion.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objInstalacion);
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
                throw new Exception("No se pudo obtener la información de la instalacion");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Instalaciones que concidan con
        /// el ID propocionado.
        /// </summary>
        /// <param name="id">
        /// Parametro que recive un String con ID para buscar un registro en la tabla de Instalaciones
        /// </param>
        /// <returns>
        /// Regresa una lista de Tipo Instlaciones con todos los registros de la tabla Instalaciones que coincidan
        /// con el ID propocionado.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public List<Instalaciones> ObtenerInstalacion(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from instalaciones where idInstalacion=@id or idEmpleado=@id or idContrato=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Instalaciones> lista = new List<Instalaciones>();
                    Instalaciones objInstalacion = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objInstalacion = new Instalaciones();
                        objInstalacion.IdInstalacion = (fila["idInstalacion"].ToString());
                        objInstalacion.fechaInstalacin = fila["fechaInstalacion"].ToString();
                        objInstalacion.idEmpelado = fila["idEmpleado"].ToString();
                        objInstalacion.idContratos = fila["idContrato"].ToString();
                        objInstalacion.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objInstalacion);
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
                throw new Exception("No se pudo obtener la información de la instalacion");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        /// <summary>
        /// Metodo que obtiene un objeto con el registros de la tabla de Instalacciones que concidan con
        /// el ID propocionado.
        /// </summary>
        /// <param name="id">
        /// Parametro que recive un String con ID para buscar un registro en la tabla de Instalaciones
        /// </param>
        /// <returns>
        /// Regresa una objeto de Tipo Instalaciones con todos los registros de la tabla Instalaciones que coincidan
        /// con el ID propocionado.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
        public Instalaciones ObtenerUnaInstalacion(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from instalaciones where idInstalacion=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Instalaciones objInstalacion = null;
                    if (resultado.Rows.Count > 0)
                    {
                        objInstalacion = new Instalaciones();
                        DataRow fila = resultado.Rows[0];
                        objInstalacion = new Instalaciones();
                        objInstalacion.IdInstalacion = (fila["idInstalacion"].ToString());
                        objInstalacion.fechaInstalacin = fila["fechaInstalacion"].ToString();
                        objInstalacion.idEmpelado = fila["idEmpleado"].ToString();
                        objInstalacion.idContratos = fila["idContrato"].ToString();
                    }

                    return objInstalacion;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la informacion de la instalacion");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        /// <summary>
        /// Metodo para realiar un nuevo registro en la tabla de Instalaciones.
        /// </summary>
        /// <param name="ins">
        /// objeto de tipo Instalaciones que recibira todos los datos para el nuevo registro
        /// de la tabla Instalaciones.
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
        public int AgregarInstlacion(Instalaciones ins)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "INSERT INTO instalaciones VALUES(@idInstalacion,@fechaInstalacion,@idEmpleado,@idContrato,@State);");
                    comando.Parameters.AddWithValue("@idInstalacion", ins.IdInstalacion);
                    comando.Parameters.AddWithValue("@fechaInstalacion", ins.fechaInstalacin);
                    comando.Parameters.AddWithValue("@idEmpleado", ins.idEmpelado);
                    comando.Parameters.AddWithValue("@idContrato", ins.idContratos);
                    comando.Parameters.AddWithValue("@State", Convert.ToInt32(ins.Estatus));
                    comando.Connection = Conexion.conexion;
                    int filasAgregadas = Convert.ToInt32(comando.ExecuteScalar());
                    return filasAgregadas;
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
                    MySqlCommand comando = new MySqlCommand(
                        @"update instalaciones set Estatus=true where idInstalacion=@idInstalacion and Estatus=false");
                    comando.Parameters.AddWithValue("@idInstalacion", ins.IdInstalacion);
                    comando.Connection = Conexion.conexion;
                    comando.Connection = Conexion.conexion;
                    return comando.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("No se ha podido agregar la instalacion");
                }
            }
            finally
            {
                Conexion.desconectar();
            }

        }
        /// <summary>
        /// Metodo para actualizar un registro de la tabla de Instalaciones
        /// </summary>
        /// <param name="ins">
        /// objeto de tipo Instalaciones que recibira todos los datos para la actulizacion
        /// del registro de la tabla empleados.
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
        public bool ModificarInstalacion(Instalaciones ins)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "update instalaciones set idInstalacion=@idInstalacion,fechaInstalacion=@fechaInstalacion," +
                    "idEmpleado=@idEmpleado,idContrato=@idContrato where idInstalacion=@idInstalacion");
                    comando.Parameters.AddWithValue("@idInstalacion", ins.IdInstalacion);
                    comando.Parameters.AddWithValue("@fechaInstalacion", ins.fechaInstalacin);
                    comando.Parameters.AddWithValue("@idEmpleado", ins.idEmpelado);
                    comando.Parameters.AddWithValue("@idContrato", ins.idContratos);
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
                throw new Exception("No se pudo actualizar la información de la instalacion");
            }
            finally
            {
                Conexion.desconectar();
            }
        }


    }
}
