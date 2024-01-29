using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class PagosDAO
    {
        private readonly ConexionBD conexionBD;

        public PagosDAO()
        {
            conexionBD = new ConexionBD();
        }

        public PagosDAO(string connectionString)
        {
            conexionBD = new ConexionBD(connectionString);
        }

        public void InsertarPago(Pagos pago)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertarPago", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", pago.ID_PEDIDO_COMPRA ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", pago.ID_FACTURA ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MONTO", pago.MONTO);
                    cmd.Parameters.AddWithValue("@ACTIVO_PAGOS", pago.ACTIVO_PAGOS);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el pago", ex);
                }
            }
        }

        public List<Pagos> ObtenerTodosLosPagos()
        {
            List<Pagos> pagosList = new List<Pagos>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerPagos", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Pagos pago = MapReaderToPagos(reader);
                            pagosList.Add(pago);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener todos los pagos", ex);
                }
            }

            return pagosList;
        }

        public Pagos ObtenerPagoPorID(int idPago)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerPagoPorID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PAGOS", idPago);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToPagos(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener el pago con ID {idPago}", ex);
                }

                return null;
            }
        }

        public void ActualizarPago(Pagos pago)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ActualizarPago", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PAGOS", pago.ID_PAGOS);
                    cmd.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", pago.ID_PEDIDO_COMPRA ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", pago.ID_FACTURA ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@MONTO", pago.MONTO);
                    cmd.Parameters.AddWithValue("@ACTIVO_PAGOS", pago.ACTIVO_PAGOS);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al actualizar el pago con ID {pago.ID_PAGOS}", ex);
                }
            }
        }

        public void EliminarPago(int idPago)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EliminarPago", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_PAGOS", idPago);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar el pago con ID {idPago}", ex);
                }
            }
        }

        private Pagos MapReaderToPagos(SqlDataReader reader)
        {
            return new Pagos
            {
                ID_PAGOS = Convert.ToInt32(reader["ID_PAGOS"]),
                ID_PEDIDO_COMPRA = reader["ID_PEDIDO_COMPRA"] != DBNull.Value ? Convert.ToInt32(reader["ID_PEDIDO_COMPRA"]) : (int?)null,
                ID_FACTURA = reader["ID_FACTURA"] != DBNull.Value ? Convert.ToInt32(reader["ID_FACTURA"]) : (int?)null,
                MONTO = Convert.ToSingle(reader["MONTO"]),
                FECHA_CREACION_PAGOS = Convert.ToDateTime(reader["FECHA_CREACION_PAGOS"]),
                ACTIVO_PAGOS = Convert.ToBoolean(reader["ACTIVO_PAGOS"])
            };
        }
    }
}
