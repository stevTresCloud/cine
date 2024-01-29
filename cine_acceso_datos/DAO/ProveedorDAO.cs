using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class ProveedorDAO
    {
        private ConexionBD conexionBD;

        public ProveedorDAO(string connectionString)
        {
            conexionBD = new ConexionBD(connectionString);
        }

        public void InsertarProveedor(string nombre, string apellido, string identificacion, string direccion, string telefono, string correo)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("InsertarProveedor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@NOMBRE_PROVEEDOR", nombre);
                    cmd.Parameters.AddWithValue("@APELLIDO_PROVEEDOR", apellido);
                    cmd.Parameters.AddWithValue("@IDENTIFICACION_PROVEEDOR", identificacion);
                    cmd.Parameters.AddWithValue("@DIRECCION_PROVEEDOR", direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO_PROVEEDOR", telefono);
                    cmd.Parameters.AddWithValue("@CORREO_PROVEEDOR", correo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerProveedor(int idProveedor)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerProveedor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        return dt;
                    }
                }
            }
        }

        public void ActualizarProveedor(int idProveedor, string nombre, string apellido, string identificacion, string direccion, string telefono, string correo)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarProveedor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);
                    cmd.Parameters.AddWithValue("@NOMBRE_PROVEEDOR", nombre);
                    cmd.Parameters.AddWithValue("@APELLIDO_PROVEEDOR", apellido);
                    cmd.Parameters.AddWithValue("@IDENTIFICACION_PROVEEDOR", identificacion);
                    cmd.Parameters.AddWithValue("@DIRECCION_PROVEEDOR", direccion);
                    cmd.Parameters.AddWithValue("@TELEFONO_PROVEEDOR", telefono);
                    cmd.Parameters.AddWithValue("@CORREO_PROVEEDOR", correo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProveedor(int idProveedor)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("EliminarProveedor", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PROVEEDOR", idProveedor);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
