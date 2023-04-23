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
     public class DAOEmpleados
    {
        public Empleados IniciarSeccion(string usuario, string password)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("SELECT * FROM empleados WHERE idEmpleado=@Usuario AND pas=sha1(@Password) and Estatus=1");
                    comando.Parameters.AddWithValue("@Usuario", usuario);
                    comando.Parameters.AddWithValue("@Password", password);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Empleados objUsuario = null;
                    if (resultado.Rows.Count > 0 && resultado.Rows.Count == 1)
                    {
                        objUsuario = new Empleados(
                            resultado.Rows[0]["idEmpleado"].ToString(),
                            resultado.Rows[0]["nomEmpleados"].ToString()
                            );
                    }
                    return objUsuario;
                }
                else
                {
                    throw new Exception("No se a podido conectar con el servidor");
                }
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<Empleados> ObtenerEmpleados()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from empleados");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Empleados> lista = new List<Empleados>();
                    Empleados objEmpleado = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objEmpleado = new Empleados();
                        objEmpleado.Idempleado = (fila["idEmpleado"].ToString());
                        objEmpleado.Nombrecompleto = fila["nomEmpleados"].ToString();
                        objEmpleado.RFC = fila["RFC"].ToString();
                        objEmpleado.CURP = fila["CURP"].ToString();
                        objEmpleado.Direccion = fila["Direccion"].ToString();
                        objEmpleado.Telefono = fila["Telefono"].ToString();
                        objEmpleado.Correo = fila["Correo"].ToString();
                        objEmpleado.fechaContratacion = fila["fechaContratacion"].ToString();
                        objEmpleado.Rol = fila["Rol"].ToString();
                        objEmpleado.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objEmpleado);
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
                throw new Exception("No se pudo obtener la información de los empleados");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public List<Empleados> ObtenerEmpleado(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from empleados where idEmpleado=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Empleados> lista = new List<Empleados>();
                    Empleados objEmpleado = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objEmpleado = new Empleados();
                        objEmpleado.Idempleado = (fila["idEmpleado"].ToString());
                        objEmpleado.Nombrecompleto = fila["nomEmpleados"].ToString();
                        objEmpleado.RFC = fila["RFC"].ToString();
                        objEmpleado.CURP = fila["CURP"].ToString();
                        objEmpleado.Direccion = fila["Direccion"].ToString();
                        objEmpleado.Telefono = fila["Telefono"].ToString();
                        objEmpleado.Correo = fila["Correo"].ToString();
                        objEmpleado.fechaContratacion = fila["fechaContratacion"].ToString();
                        objEmpleado.Rol = fila["Rol"].ToString();
                        objEmpleado.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objEmpleado);
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
                throw new Exception("No se pudo obtener la información de los empleados");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public List<Empleados> ObtenerEmpleadosActivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from empleados where Estatus=true");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Empleados> lista = new List<Empleados>();
                    Empleados objEmpleado = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objEmpleado = new Empleados();
                        objEmpleado.Idempleado = (fila["idEmpleado"].ToString());
                        objEmpleado.Nombrecompleto = fila["nomEmpleados"].ToString();
                        objEmpleado.RFC = fila["RFC"].ToString();
                        objEmpleado.CURP = fila["CURP"].ToString();
                        objEmpleado.Direccion = fila["Direccion"].ToString();
                        objEmpleado.Telefono = fila["Telefono"].ToString();
                        objEmpleado.Correo = fila["Correo"].ToString();
                        objEmpleado.fechaContratacion = fila["fechaContratacion"].ToString();
                        objEmpleado.Rol = fila["Rol"].ToString();
                        objEmpleado.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objEmpleado);
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
                throw new Exception("No se pudo obtener la información de los empleados");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        public List<Empleados> ObtenerEmpleadosInactivos()
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from empleados where Estatus=false");
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    List<Empleados> lista = new List<Empleados>();
                    Empleados objEmpleado = null;
                    foreach (DataRow fila in resultado.Rows)
                    {
                        objEmpleado = new Empleados();
                        objEmpleado.Idempleado = (fila["idEmpleado"].ToString());
                        objEmpleado.Nombrecompleto = fila["nomEmpleados"].ToString();
                        objEmpleado.RFC = fila["RFC"].ToString();
                        objEmpleado.CURP = fila["CURP"].ToString();
                        objEmpleado.Direccion = fila["Direccion"].ToString();
                        objEmpleado.Telefono = fila["Telefono"].ToString();
                        objEmpleado.Correo = fila["Correo"].ToString();
                        objEmpleado.fechaContratacion = fila["fechaContratacion"].ToString();
                        objEmpleado.Rol = fila["Rol"].ToString();
                        objEmpleado.Estatus = (Convert.ToInt32(fila["Estatus"]) == 1 ? true : false);
                        lista.Add(objEmpleado);
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
                throw new Exception("No se pudo obtener la información de los empleados");
            }
            finally
            {
                Conexion.desconectar();
            }
        }

        public Empleados ObtenerUnEmpleado(string id)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand("select * from empleados where idEmpleado=@id");
                    comando.Parameters.AddWithValue("@id", id);
                    comando.Connection = Conexion.conexion;
                    MySqlDataAdapter adapter = new MySqlDataAdapter(comando);
                    DataTable resultado = new DataTable();
                    adapter.Fill(resultado);
                    Empleados objEmpleado = null;
                    if (resultado.Rows.Count > 0)
                    {
                        objEmpleado = new Empleados();
                        DataRow fila = resultado.Rows[0];
                        objEmpleado.Idempleado = fila["idEmpleado"].ToString();
                        objEmpleado.Nombrecompleto = fila["nomEmpleados"].ToString();
                        objEmpleado.RFC = fila["RFC"].ToString();
                        objEmpleado.CURP = fila["CURP"].ToString();
                        objEmpleado.Edad = Convert.ToInt32(fila["Edad"]);
                        objEmpleado.Direccion = fila["Direccion"].ToString();
                        objEmpleado.Telefono = fila["Telefono"].ToString();
                        objEmpleado.Correo = fila["Correo"].ToString();
                        objEmpleado.fechaContratacion = fila["fechaContratacion"].ToString();
                        objEmpleado.Rol = fila["Rol"].ToString();
                    }

                    return objEmpleado;
                }
                else
                {
                    throw new Exception("No se ha podido conectar con el servidor");
                }
            }
            catch (MySqlException ex)
            {
                throw new Exception("No se pudo obtener la informacion del empleado");
            }
            finally
            {
                Conexion.desconectar();
            }
        }
        // metodo para agregar a un empleado
        public int AgregarEmpleado(Empleados emp)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "INSERT INTO empleados VALUES(@idEmpleado,@name,@RFC,@CURP,@Edad,@direccion,@telefono,@correo,@fechacontratacion,@rol,sha1(@password),@State);");
                    comando.Parameters.AddWithValue("@idEmpleado", emp.Idempleado);
                    comando.Parameters.AddWithValue("@name", emp.Nombrecompleto);
                    comando.Parameters.AddWithValue("@RFC", emp.RFC);
                    comando.Parameters.AddWithValue("@CURP", emp.CURP);
                    comando.Parameters.AddWithValue("@Edad", Convert.ToInt32(emp.Edad));
                    comando.Parameters.AddWithValue("@direccion", emp.Direccion);
                    comando.Parameters.AddWithValue("@telefono", emp.Telefono);
                    comando.Parameters.AddWithValue("@correo", emp.Correo);
                    comando.Parameters.AddWithValue("@fechacontratacion", emp.fechaContratacion);
                    comando.Parameters.AddWithValue("@rol", emp.Rol);
                    comando.Parameters.AddWithValue("@password", emp.Password);
                    comando.Parameters.AddWithValue("@State", Convert.ToInt32(emp.Estatus));
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
                        @"update Empleados set Estatus=true where idEmpleado=@idEmpleado and Estatus=false");
                    comando.Parameters.AddWithValue("@idEmpeado", emp.Idempleado);
                    comando.Connection = Conexion.conexion;
                    comando.Connection = Conexion.conexion;
                    return comando.ExecuteNonQuery();
                }
                else
                {
                    throw new Exception("No se ha podido agregar el empleado");
                }
            }
            finally
            {
                Conexion.desconectar();
            }

        }

        public bool ModificarEmpleado(Empleados emp)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "update empleados set nomEmpleados=@name,RFC=@RFC,CURP=@CURP,Edad=@Edad,Direccion=@direccion,Telefono=@telefono," +
                    "Correo=@correo,Rol=@rol, Estatus=true where idEmpleado=@idEmpleado");
                    comando.Parameters.AddWithValue("@idEmpleado", emp.Idempleado);
                    comando.Parameters.AddWithValue("@name", emp.Nombrecompleto);
                    comando.Parameters.AddWithValue("@RFC", emp.RFC);
                    comando.Parameters.AddWithValue("@CURP", emp.CURP);
                    comando.Parameters.AddWithValue("@Edad", Convert.ToInt32(emp.Edad));
                    comando.Parameters.AddWithValue("@direccion", emp.Direccion);
                    comando.Parameters.AddWithValue("@telefono", emp.Telefono);
                    comando.Parameters.AddWithValue("@correo", emp.Correo);
                    comando.Parameters.AddWithValue("@rol", emp.Rol);
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
                throw new Exception("No se pudo actualizar la información del empleado");
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
                        @"delete from empleados where idEmpleado=@Id");
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
                        @"update empleados set Estatus=false where idEmpleado=@Id");
                        comando.Parameters.AddWithValue("@id", id);
                        comando.Connection = Conexion.conexion;
                        int filasBorradas = comando.ExecuteNonQuery();
                        return (filasBorradas > 0);
                    }
                    catch
                    {
                        throw new Exception("Usuario ya eliminado");
                    }
                }
                else
                {
                    throw new Exception("Error al intentar eliminar el empleado");
                }

            }
            finally
            {
                Conexion.desconectar();
            }
        }
    }
}
