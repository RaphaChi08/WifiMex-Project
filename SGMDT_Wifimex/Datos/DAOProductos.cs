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
    public class DAOProductos
    {
        public List<Productos> ObtenerProductos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from productos");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Productos> lista = new List<Productos>();
                    Productos objProductos = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProductos = new Productos();
                        objProductos.codigoBarra = fila["codigoBarra"].ToString();
                        objProductos.nomProducto = fila["nomProducto"].ToString();
                        objProductos.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProductos.idProveedores = fila["idProveedores"].ToString();
                        objProductos.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objProductos);
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
                throw new Exception("No se pudo obtener la información de los productos");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public List<Productos> ObtenerProductosActivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from productos where Estatus=true");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Productos> lista = new List<Productos>();
                    Productos objProductos = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProductos = new Productos();
                        objProductos.codigoBarra = fila["codigoBarra"].ToString();
                        objProductos.nomProducto = fila["nomProducto"].ToString();
                        objProductos.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProductos.idProveedores = fila["idProveedores"].ToString();
                        objProductos.nomProveedor = this.ObtenerUnProveedor(objProductos.idProveedores).nomProveedores;
                        objProductos.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objProductos);
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
                throw new Exception("No se pudo obtener la información de los productos");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public List<Productos> ObtenerProductosInactivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from productos where Estatus=false");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Productos> lista = new List<Productos>();
                    Productos objProductos = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProductos = new Productos();
                        objProductos.codigoBarra = fila["codigoBarra"].ToString();
                        objProductos.nomProducto = fila["nomProducto"].ToString();
                        objProductos.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProductos.idProveedores = fila["idProveedores"].ToString();
                        objProductos.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objProductos);
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
                throw new Exception("No se pudo obtener la información de los productos");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public Productos ObtenerUnProducto(string codigo)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from productos where codigoBarra=@codigo");
                    comando.Parameters.AddWithValue("@codigo", codigo);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Productos objProductos = null;
                    if (resultado.Rows.Count > 0)
                    {
                        objProductos = new Productos();
                        DataRow fila = resultado.Rows[0];
                        objProductos = new Productos();

                        objProductos.codigoBarra = fila["codigoBarra"].ToString();
                        objProductos.nomProducto = (fila["nomProducto"].ToString());
                        objProductos.fechaRegistro = fila["fechaRegistro"].ToString();
                        objProductos.idProveedores = fila["idProveedores"].ToString();
                        objProductos.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                    }

                    return objProductos;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la informacion del producto");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<Proveedores> ObtenerProveedoresActivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select idProveedores, nomProveedor from proveedores where Estatus=true");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Proveedores> lista = new List<Proveedores>();
                    Proveedores objProveedores = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objProveedores = new Proveedores();
                        objProveedores.idProveedores = fila["idProveedores"].ToString();
                        objProveedores.nomProveedores = fila["nomProveedor"].ToString();
                        objProveedores.RFC = null;
                        objProveedores.Direccion = null;
                        objProveedores.Telefono = null;
                        objProveedores.Correo = null;
                        objProveedores.fechaRegistro = null;
                        objProveedores.Estatus = true;
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
        public Proveedores ObtenerUnProveedor(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select nomProveedor from proveedores where idProveedores=@id");
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

                        objProveedores.idProveedores = null;
                        objProveedores.nomProveedores = (fila["nomProveedor"].ToString());
                        objProveedores.RFC = null;
                        objProveedores.Direccion = null;
                        objProveedores.Telefono = null;
                        objProveedores.Correo = null;
                        objProveedores.fechaRegistro = null;
                        objProveedores.Estatus = true;
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

        
        public int AgregarProducto(Productos ins)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "INSERT INTO productos VALUES(@codigoBarra, @nomProducto, @fechaRegistro, @idProveedores, @Estatus);");
                    comando.Parameters.AddWithValue("@codigoBarra", ins.codigoBarra);
                    comando.Parameters.AddWithValue("@nomProducto", ins.nomProducto);
                    comando.Parameters.AddWithValue("@fechaRegistro", ins.fechaRegistro);
                    comando.Parameters.AddWithValue("@idProveedores", ins.idProveedores);
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
                    Productos enf = new Productos();
                    enf = this.ObtenerUnProducto(ins.codigoBarra);
                    if (enf.Estatus.Equals(0))
                    {
                        MySqlCommand comando = new MySqlCommand(
                        "update proveedores set nomProducto=@nomProducto,fechaRegistro=@fechaRegistro,idProveedores=@idProveedores,Estatus=1 " +
                        "where codigoBarra=@codigoBarra");
                        comando.Parameters.AddWithValue("@codigoBarra", ins.codigoBarra);
                        comando.Parameters.AddWithValue("@nomProducto", ins.nomProducto);
                        comando.Parameters.AddWithValue("@fechaRegistro", ins.fechaRegistro);
                        comando.Parameters.AddWithValue("@idProveedores", ins.idProveedores);
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
                    throw new Exception("No se ha podido agregar el producto");
                }
            }
            finally
            {
                Conexion.desconectar();
            }

        }
        public bool ModificarProducto(Productos ins)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                   "update productos set nomProducto=@nomProducto,idProveedores=@idProveedores " +
                   "where codigoBarra=@codigoBarra");
                    comando.Parameters.AddWithValue("@codigoBarra", ins.codigoBarra);
                    comando.Parameters.AddWithValue("@nomProducto", ins.nomProducto);
                    comando.Parameters.AddWithValue("@idProveedores", ins.idProveedores);
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
                throw new Exception("No se pudo actualizar wl producto");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public bool EliminarProducto(string codigo)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"delete from productos where codigoBarra=@codigo");
                    comando.Parameters.AddWithValue("@codigo", codigo);
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
                        @"update productos set Estatus=false where codigoBarra=@codigo");
                        comando.Parameters.AddWithValue("@codigo", codigo);
                        comando.Connection = Conexion.conexion;
                        int filasBorradas = comando.ExecuteNonQuery();
                        return (filasBorradas > 0);
                    }
                    catch
                    {
                        throw new Exception("Producto ya eliminado");
                    }
                }
                else
                {
                    throw new Exception("Error al intentar eliminar el producto");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public List<Productos> Buscar(string text)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                        @"select prod.*, prov.nomProveedor from productos prod join proveedores prov on prod.idProveedores = prov.idProveedores
	                    where
	                    codigoBarra like  CONCAT('%', @ref, '%') || 
	                    nomProducto like  CONCAT('%', @ref, '%') ||
	                    nomProveedor like  CONCAT('%', @ref, '%');"
                    );
                    comando.Parameters.AddWithValue("@ref", text);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Productos> lista = new List<Productos>();
                    Productos objProducto = null;

                    foreach (DataRow fila in resultado.Rows)
                    {
                        if (Convert.ToInt32(fila["Estatus"]).Equals(1))
                        {
                            objProducto = new Productos();
                            objProducto.codigoBarra = fila["codigoBarra"].ToString();
                            objProducto.nomProducto = fila["nomProducto"].ToString();
                            objProducto.fechaRegistro = fila["fechaRegistro"].ToString();
                            objProducto.idProveedores = fila["idProveedores"].ToString();
                            objProducto.nomProveedor = fila["nomProveedor"].ToString();
                            objProducto.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);

                            lista.Add(objProducto);
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
                throw new Exception("No se pudo obtener la información de los productos");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
