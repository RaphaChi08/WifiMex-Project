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

        public int AgregarEmpleado(Empleados emp)
        {
            try
            {
                if (Conexion.conectar())
                {
                    MySqlCommand comando = new MySqlCommand(
                    "INSERT INTO empleados VALUES(@idEmpleado,@name,@RFC,@Edad,@direccion,@correo,@rol,sha1(@password),@State);");
                    comando.Parameters.AddWithValue("@idEmpleado", emp.Idempleado);
                    comando.Parameters.AddWithValue("@name", emp.Nombrecompleto);
                    comando.Parameters.AddWithValue("@RFC", emp.RFC);
                    comando.Parameters.AddWithValue("@Edad", emp.Edad);
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
                        @"update Employees set Estatus=1 where idEmpleado=@idEmpleado and Estatus=0");
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
    }
}
