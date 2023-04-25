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
    public class DAOAlmacen
    {
        public List<Almacen> ObtenerTodos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"SELECT * FROM almacen");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Almacen> lista = new List<Almacen>();
                    Almacen objAlmacen = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objAlmacen = new Almacen();
                        objAlmacen.idAlmacen = fila["idAlmacen"].ToString();
                        objAlmacen.cantProducto = int.Parse(fila["cantProducto"].ToString());
                        objAlmacen.codigoBarra = fila["codigoBarra"].ToString();
                        objAlmacen.idEmpleado = fila["idEmpleado"].ToString();
                        objAlmacen.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";

                        lista.Add(objAlmacen);
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
                throw new Exception("No se pudo obtener la información de los almacenes");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<Almacen> Buscar(string text)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"select * from almacen 
	                    where
	                    codigoBarra like  CONCAT('%', @ref, '%') || 
	                    idEmpleado like  CONCAT('%', @ref, '%') || 
	                    idAlmacen like  CONCAT('%', @ref, '%') ||
	                    cantProducto like  CONCAT('%', @ref, '%');"
                    );
                    comando.Parameters.AddWithValue("@ref", text);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Almacen> lista = new List<Almacen>();
                    Almacen objAlmacen = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        objAlmacen = new Almacen();
                        objAlmacen.idAlmacen = fila["idAlmacen"].ToString();
                        objAlmacen.cantProducto = int.Parse(fila["cantProducto"].ToString());
                        objAlmacen.codigoBarra = fila["codigoBarra"].ToString();
                        objAlmacen.idEmpleado = fila["idEmpleado"].ToString();
                        objAlmacen.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";

                        lista.Add(objAlmacen);
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
                throw new Exception("No se pudo obtener la información de los almacenes");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Almacen ObtenerUno(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(@"SELECT * FROM almacen WHERE idAlmacen=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);

                    Almacen objAlmacen = null;
                    if (resultado.Rows.Count > 0)
                    {
                        DataRow fila = resultado.Rows[0];
                        objAlmacen = new Almacen();
                        objAlmacen.idAlmacen = fila["idAlmacen"].ToString();
                        objAlmacen.cantProducto = int.Parse(fila["cantProducto"].ToString());
                        objAlmacen.codigoBarra = fila["codigoBarra"].ToString();
                        objAlmacen.idEmpleado = fila["idEmpleado"].ToString();
                        objAlmacen.Estatus = fila["Estatus"].ToString() == "True" ? "Activo" : "Inactivo";
                    }

                    return objAlmacen;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la información del almacen");
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
                        @"DELETE FROM almacen
                        WHERE idAlmacen=@id");

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
                        @"update almacen set Estatus=0
                        WHERE idAlmacen=@id");

                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    int filasBorradas = comando.ExecuteNonQuery();
                    return (filasBorradas > 0);
                }
                else
                {
                    throw new Exception("Error al intentar eliminar el Almacen");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool editar(Almacen almacen)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"UPDATE `dbwifimex`.`almacen` SET 
                        `cantProducto` = @cant, 
                        `codigoBarra` = @codi, 
                        `idEmpleado` = @emp, 
                        `Estatus` = @estatus
                        WHERE (`idAlmacen` = @id);");

                    comando.Parameters.AddWithValue("@codi", almacen.codigoBarra);
                    comando.Parameters.AddWithValue("@cant", almacen.cantProducto);
                    comando.Parameters.AddWithValue("@emp", almacen.idEmpleado);
                    comando.Parameters.AddWithValue("@id", almacen.idAlmacen);
                    comando.Parameters.AddWithValue("@estatus", almacen.Estatus == "Activo" ? 1 : 0);

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
                throw new Exception("No se pudo editar la info del almacen");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public int agregar(Almacen almacen)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        "INSERT INTO `dbwifimex`.`almacen` " +
                        "(`idAlmacen`, `cantProducto`, `codigoBarra`, `idEmpleado`, `Estatus`) VALUES " +
                        "(@id, @cant, @codi, @emp, '1')");

                    comando.Parameters.AddWithValue("@id", almacen.idAlmacen);
                    comando.Parameters.AddWithValue("@cant", almacen.cantProducto);
                    comando.Parameters.AddWithValue("@codi", almacen.codigoBarra);
                    comando.Parameters.AddWithValue("@emp", almacen.idEmpleado);
                    comando.Connection = Conexion.conexion;

                    int filasAgregadas = comando.ExecuteNonQuery();

                    return filasAgregadas;
                }
                else
                {
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
