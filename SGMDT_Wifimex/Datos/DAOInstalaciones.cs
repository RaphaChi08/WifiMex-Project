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
    public class DAOInstalaciones
    {
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
                        @"update instalaciones set Estatus=1 where idInstalacion=@idInstalacion and Estatus=0");
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

        public bool EliminarEmpleado(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"delete from instalaciones where idInstalacion=@Id");
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
                        @"update instalaciones set Estatus=false where idInstalacion=@Id");
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Connection = Conexion.conexion;
                        int filasBorradas = comando.ExecuteNonQuery();
                        return (filasBorradas > 0);
                    }
                    catch
                    {
                        throw new Exception("Instalacion ya eliminado");
                    }
                }
                else
                {
                    throw new Exception("Error al intentar eliminar la Instalacion");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }

    }
}
