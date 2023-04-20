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
    public class DAOContratos
    {


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
