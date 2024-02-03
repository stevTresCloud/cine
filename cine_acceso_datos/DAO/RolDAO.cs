using cine_acceso_datos.Entidades;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class RolDAO
    {
        private readonly ConexionBD conexionBD;

        public RolDAO()
        {
            conexionBD = new ConexionBD();
        }

        public void InsertarRol(Rol rol)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertarRol", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_USUARIO", rol.ID_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TIPO_ROL", rol.TIPO_ROL);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", rol.DESCRIPCION);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el rol", ex);
                }
            }
        }

        public List<Rol> ObtenerTodosLosRoles()
        {
            List<Rol> rolesList = new List<Rol>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerRoles", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Rol rol = MapReaderToRol(reader);
                            rolesList.Add(rol);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener todos los roles", ex);
                }
            }

            return rolesList;
        }

        public Rol ObtenerRolPorID(int idRol)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerRolPorID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_ROL", idRol);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToRol(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener el rol con ID {idRol}", ex);
                }

                return null;
            }
        }

        public void ActualizarRol(Rol rol)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ActualizarRol", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_ROL", rol.ID_ROL);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", rol.ID_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TIPO_ROL", rol.TIPO_ROL);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", rol.DESCRIPCION);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al actualizar el rol con ID {rol.ID_ROL}", ex);
                }
            }
        }

        public void EliminarRol(int idRol)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EliminarRol", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_ROL", idRol);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar el rol con ID {idRol}", ex);
                }
            }
        }

        private Rol MapReaderToRol(SqlDataReader reader)
        {
            return new Rol
            {
                ID_ROL = Convert.ToInt32(reader["ID_ROL"]),
                ID_USUARIO = reader["ID_USUARIO"] != DBNull.Value ? Convert.ToInt32(reader["ID_USUARIO"]) : (int?)null,
                TIPO_ROL = Convert.ToString(reader["TIPO_ROL"]),
                DESCRIPCION = Convert.ToString(reader["DESCRIPCION"]),
                FECHA_CREACION_ROL = Convert.ToDateTime(reader["FECHA_CREACION_ROL"]),
                ACTIVO_ROL = Convert.ToBoolean(reader["ACTIVO_ROL"])
            };
        }
    }
}
