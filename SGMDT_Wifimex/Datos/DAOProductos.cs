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
    /// <summary>
    /// Clase DAOProductos que contiene los metodos para realizar consultas, inserciones, actulizaciones y eliminacion
    /// de registros de la tabla Empleados de la base de datos del programa.   
    /// </summary>
    public class DAOProductos
    {
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Productos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Productos con todos los registros de la tabla Prodcutos
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
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

        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Productos que estan activos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Productos con todos los registros de la tabla Productos que esten
        /// en estado activo
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
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
        /// <summary>
        /// Metodo que obtiene un lista con todos los registros de la tabla de Productos que estan inactivos.
        /// </summary>
        /// <returns>
        /// Regresa una lista de Tipo Productos con todos los registros de la tabla Productos que esten
        /// en estado inactivo
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
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

        /// <summary>
        /// Metodo que obtiene un objeto con el registros de la tabla de Productos que concidan con
        /// el ID propocionado.
        /// </summary>
        /// <param name="id">
        /// Parametro que recive un String con ID para buscar un registro en la tabla de Proveedores
        /// </param>
        /// <returns>
        /// Regresa una objeto de Tipo Productos con todos los registros de la tabla Productos que concidan
        /// con el ID propocionado.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de no poder conectarse al sistem mostrara un mensaje donde indique que no se pudo
        /// conectar al servidor.
        /// En caso de no encontrar ningun registro regresa un mensaje que indicaque no se encontraron
        /// registros en la tabla
        /// </exception>
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

        /// <summary>
        /// Metodo para realiar un nuevo registro en la tabla de Productos.
        /// </summary>
        /// <param name="ins">
        /// objeto de tipo Productos que recibira todos los datos para el nuevo registro
        /// de la tabla Producots.
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

        /// <summary>
        /// Metodo para actualizar un registro de la tabla de Productos
        /// </summary>
        /// <param name="ins">
        /// objeto de tipo Productos que recibira todos los datos para la actulizacion
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

        /// <summary>
        /// Metodo que elimna un registro de la tabla de Producots
        /// </summary>
        /// <param name="codigo">
        /// Parametro que recive un String con un Codigo proporcionado para buscar un registro
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
        /// <summary>
        /// Metodo que Realiza consultas para obtener registros de la tabla Prodcutos.
        /// </summary>
        /// <param name="text">
        /// Parametro de entrada que recive una variable de tipo String que contiene una cadena
        /// de texto que se utilizara para buscar concidencias con los registros de la tabla Productos.
        /// </param>
        /// <returns>
        /// Regresa una lista de registros de la tabla Productos que concidan con la cadena de texto que
        /// se proporciono.
        /// </returns>
        /// <exception cref="Exception">
        /// En caso de que no se pudo realizar la conexion se mandara un mensaje donde indica que la
        /// conexion no se logro realizar.
        /// En caso de que no se encuentren datos en la tabla de Productos mandara un mensaje que 
        /// indica que no se pudieron obtener dato de la tabla.
        /// </exception>
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
