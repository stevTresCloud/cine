using cine_acceso_datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace cine_acceso_datos.DAO
{
    public class UsuarioDAO
    {
        private readonly ConexionBD conexion;

        public UsuarioDAO()
        {
            conexion = new ConexionBD();
        }

        public UsuarioDAO(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public void InsertarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("InsertarUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@LOGIN", usuario.LOGIN);
                    cmd.Parameters.AddWithValue("@CONTRASENA", usuario.CONTRASENA);
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", usuario.NOMBRE_USUARIO);
                    cmd.Parameters.AddWithValue("@APELLIDO_USUARIO", usuario.APELLIDO_USUARIO);
                    cmd.Parameters.AddWithValue("@IDENTIFICACION_USUARIO", usuario.IDENTIFICACION_USUARIO);
                    cmd.Parameters.AddWithValue("@DIRECCION_USUARIO", usuario.DIRECCION_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TELEFONO_USUARIO", usuario.TELEFONO_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CORREO_USUARIO", usuario.CORREO_USUARIO);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Usuario> ObtenerTodosLosUsuarios()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerUsuarios", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Usuario usuario = MapUsuarioFromReader(reader);
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }

        public Usuario ObtenerUsuarioPorID(int idUsuario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerUsuarioPorID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_USUARIO", idUsuario);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapUsuarioFromReader(reader);
                        }
                    }
                }
            }

            return null;
        }

        public void ActualizarUsuario(Usuario usuario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros
                    cmd.Parameters.AddWithValue("@ID_USUARIO", usuario.ID_USUARIO);
                    cmd.Parameters.AddWithValue("@ID_ROL", usuario.ID_ROL ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LOGIN", usuario.LOGIN);
                    cmd.Parameters.AddWithValue("@CONTRASENA", usuario.CONTRASENA);
                    cmd.Parameters.AddWithValue("@NOMBRE_USUARIO", usuario.NOMBRE_USUARIO);
                    cmd.Parameters.AddWithValue("@APELLIDO_USUARIO", usuario.APELLIDO_USUARIO);
                    cmd.Parameters.AddWithValue("@IDENTIFICACION_USUARIO", usuario.IDENTIFICACION_USUARIO);
                    cmd.Parameters.AddWithValue("@DIRECCION_USUARIO", usuario.DIRECCION_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TELEFONO_USUARIO", usuario.TELEFONO_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CORREO_USUARIO", usuario.CORREO_USUARIO);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("EliminarUsuario", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_USUARIO", idUsuario);

                    // Ejecutar el comando
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private Usuario MapUsuarioFromReader(SqlDataReader reader)
        {
            return new Usuario
            {
                ID_USUARIO = (int)reader["ID_USUARIO"],
                ID_ROL = reader["ID_ROL"] != DBNull.Value ? (int?)reader["ID_ROL"] : null,
                LOGIN = (string)reader["LOGIN"],
                CONTRASENA = (string)reader["CONTRASENA"],
                FECHA_CREACION_USUARIO = (DateTime)reader["FECHA_CREACION_USUARIO"],
                ACTIVO_USUARIO = (bool)reader["ACTIVO_USUARIO"],
                NOMBRE_USUARIO = (string)reader["NOMBRE_USUARIO"],
                APELLIDO_USUARIO = (string)reader["APELLIDO_USUARIO"],
                IDENTIFICACION_USUARIO = (string)reader["IDENTIFICACION_USUARIO"],
                DIRECCION_USUARIO = reader["DIRECCION_USUARIO"] != DBNull.Value ? (string)reader["DIRECCION_USUARIO"] : null,
                TELEFONO_USUARIO = reader["TELEFONO_USUARIO"] != DBNull.Value ? (string)reader["TELEFONO_USUARIO"] : null,
                CORREO_USUARIO = (string)reader["CORREO_USUARIO"]
            };
        }
    }
}
