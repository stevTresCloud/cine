using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class PedidoCompraDAO
    {
        private ConexionBD conexionBD;

        public PedidoCompraDAO()
        {
            conexionBD = new ConexionBD();
        }

        // Método para insertar un nuevo pedido de compra
        public void InsertarPedidoCompra(PedidoCompra pedido)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("InsertarPedidoCompra", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@ID_PROVEEDOR", pedido.ID_PROVEEDOR);
                        comando.Parameters.AddWithValue("@ID_ESTADO_PEDIDO", pedido.ID_ESTADO_PROVEEDOR);
                        comando.Parameters.AddWithValue("@NUMERO_PEDIDO_COMPRA", pedido.NUMERO_PEDIDO_COMPRA);
                        comando.Parameters.AddWithValue("@FECHA_ENTREGA", pedido.FECHA_ENTREGA);
                        comando.Parameters.AddWithValue("@TOTAL", pedido.TOTAL);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el pedido de compra", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        // Método para obtener todos los pedidos de compra
        public DataTable ObtenerPedidosCompra()
        {
            DataTable dataTable = new DataTable();

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ObtenerPedidosCompra", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        using (SqlDataAdapter adaptador = new SqlDataAdapter(comando))
                        {
                            adaptador.Fill(dataTable);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los pedidos de compra", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return dataTable;
        }

        // Método para obtener un pedido de compra por su ID
        public PedidoCompra ObtenerPedidoCompraPorID(int idPedidoCompra)
        {
            PedidoCompra pedido = null;

            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ObtenerPedidoCompraPorID", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", idPedidoCompra);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pedido = MapReaderToPedido(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pedido de compra por ID", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return pedido;
        }

        // Método para actualizar un pedido de compra
        public void ActualizarPedidoCompra(PedidoCompra pedido)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("ActualizarPedidoCompra", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;

                        comando.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", pedido.ID_PEDIDO_COMPRA);
                        comando.Parameters.AddWithValue("@ID_PROVEEDOR", pedido.ID_PROVEEDOR);
                        comando.Parameters.AddWithValue("@ID_ESTADO_PEDIDO", pedido.ID_ESTADO_PROVEEDOR);
                        comando.Parameters.AddWithValue("@NUMERO_PEDIDO_COMPRA", pedido.NUMERO_PEDIDO_COMPRA);
                        comando.Parameters.AddWithValue("@FECHA_ENTREGA", pedido.FECHA_ENTREGA);
                        comando.Parameters.AddWithValue("@TOTAL", pedido.TOTAL);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pedido de compra", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        // Método para eliminar un pedido de compra
        public void EliminarPedidoCompra(int idPedidoCompra)
        {
            try
            {
                using (SqlConnection conexion = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand comando = new SqlCommand("EliminarPedidoCompra", conexion))
                    {
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", idPedidoCompra);

                        comando.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el pedido de compra", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        // Método privado para mapear un SqlDataReader a un objeto PedidoCompra
        private PedidoCompra MapReaderToPedido(SqlDataReader reader)
        {
            return new PedidoCompra
            {
                ID_PEDIDO_COMPRA = Convert.ToInt32(reader["ID_PEDIDO_COMPRA"]),
                ID_PROVEEDOR = Convert.ToInt32(reader["ID_PROVEEDOR"]),
                ID_ESTADO_PROVEEDOR = Convert.ToInt32(reader["ID_ESTADO_PEDIDO"]),
                NUMERO_PEDIDO_COMPRA = reader["NUMERO_PEDIDO_COMPRA"].ToString(),
                ACTIVO_PEDIDO_COMPRA = Convert.ToBoolean(reader["ACTIVO_PEDIDO_COMPRA"]),
                FECHA_ENTREGA = Convert.ToDateTime(reader["FECHA_ENTREGA"]),
                TOTAL = Convert.ToSingle(reader["TOTAL"]),
                FECHA_CREACION_PEDIDO_COMPRA = Convert.ToDateTime(reader["FECHA_CREACION_PEDIDO_COMPRA"])
            };
        }
    }
}
