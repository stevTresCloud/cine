using cine_acceso_datos.Entidades;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class ProveedorDAO
    {
        private readonly ConexionBD conexionBD;

        public ProveedorDAO()
        {
            conexionBD = new ConexionBD();
        }

        public void InsertarProveedor(string nombre, string apellido, string identificacion, string correo, string direccion = null, string telefono = null)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("InsertarProveedor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NOMBRE_PROVEEDOR", nombre);
                        cmd.Parameters.AddWithValue("@APELLIDO_PROVEEDOR", apellido);
                        cmd.Parameters.AddWithValue("@IDENTIFICACION_PROVEEDOR", identificacion);
                        cmd.Parameters.AddWithValue("@DIRECCION_PROVEEDOR", (object)direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TELEFONO_PROVEEDOR", (object)telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CORREO_PROVEEDOR", correo);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar proveedor", ex);
                }
            }
        }

        public List<Proveedor> ObtenerProveedores()
        {
            List<Proveedor> proveedores = new List<Proveedor>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("ObtenerProveedores", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Proveedor proveedor = MapRowToProveedor(reader);
                                proveedores.Add(proveedor);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener proveedores", ex);
                }
            }

            return proveedores;
        }

        public Proveedor ObtenerProveedorPorID(int idProveedor)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("ObtenerProveedorPorID", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return MapRowToProveedor(reader);
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener proveedor por ID {idProveedor}", ex);
                }
            }
        }

        public void ActualizarProveedor(int idProveedor, string nombre, string apellido, string identificacion, string correo, string direccion = null, string telefono = null)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("ActualizarProveedor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
                        cmd.Parameters.AddWithValue("@NOMBRE_PROVEEDOR", nombre);
                        cmd.Parameters.AddWithValue("@APELLIDO_PROVEEDOR", apellido);
                        cmd.Parameters.AddWithValue("@IDENTIFICACION_PROVEEDOR", identificacion);
                        cmd.Parameters.AddWithValue("@DIRECCION_PROVEEDOR", (object)direccion ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@TELEFONO_PROVEEDOR", (object)telefono ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@CORREO_PROVEEDOR", correo);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al actualizar proveedor con ID {idProveedor}", ex);
                }
            }
        }

        public void EliminarProveedor(int idProveedor)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand("EliminarProveedor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);

                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar proveedor con ID {idProveedor}", ex);
                }
            }
        }

        private Proveedor MapRowToProveedor(SqlDataReader reader)
        {
            return new Proveedor
            {
                ID_PROVEEDOR = (int)reader["ID_PROVEEDOR"],
                NOMBRE_PROVEEDOR = (string)reader["NOMBRE_PROVEEDOR"],
                APELLIDO_PROVEEDOR = (string)reader["APELLIDO_PROVEEDOR"],
                IDENTIFICACION_PROVEEDOR = (string)reader["IDENTIFICACION_PROVEEDOR"],
                DIRECCION_PROVEEDOR = reader["DIRECCION_PROVEEDOR"] is DBNull ? null : (string)reader["DIRECCION_PROVEEDOR"],
                TELEFONO_PROVEEDOR = reader["TELEFONO_PROVEEDOR"] is DBNull ? null : (string)reader["TELEFONO_PROVEEDOR"],
                CORREO_PROVEEDOR = (string)reader["CORREO_PROVEEDOR"],
                FECHA_CREACION_PROVEEDOR = (DateTime)reader["FECHA_CREACION_PROVEEDOR"],
                ACTIVO_PROVEEDOR = (bool)reader["ACTIVO_PROVEEDOR"]
            };
        }
    }
}
