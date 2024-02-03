using cine_acceso_datos.Entidades;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class LineaPedidoDAO
    {
        private ConexionBD conexionBD;

        public LineaPedidoDAO()
        {
            conexionBD = new ConexionBD();
        }

        public List<LineaPedido> ObtenerTodasLineasPedido()
        {
            List<LineaPedido> lineasPedido = new List<LineaPedido>();

            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("ObtenerLineasPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LineaPedido lineaPedido = MapRowToLineaPedido(reader);
                            lineasPedido.Add(lineaPedido);
                        }
                    }
                }
            }

            return lineasPedido;
        }

        public LineaPedido ObtenerLineaPedidoPorID(int idLineaPedido)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("ObtenerLineaPedidoPorID", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ID_LINEAS_PEDIDO", idLineaPedido);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapRowToLineaPedido(reader);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public void InsertarLineaPedido(LineaPedido lineaPedido)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("InsertarLineaPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", lineaPedido.ID_PEDIDO_COMPRA);
                    comando.Parameters.AddWithValue("@CANTIDAD", lineaPedido.CANTIDAD);
                    comando.Parameters.AddWithValue("@PRECIO", lineaPedido.PRECIO);

                    SqlParameter parametroSubtotal = new SqlParameter("@SUBTOTAL", SqlDbType.Float);
                    parametroSubtotal.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(parametroSubtotal);

                    comando.ExecuteNonQuery();

                    lineaPedido.SUBTOTAL = Convert.ToSingle(parametroSubtotal.Value);
                }
            }
        }

        public void ActualizarLineaPedido(LineaPedido lineaPedido)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("ActualizarLineaPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ID_LINEAS_PEDIDO", lineaPedido.ID_LINEA_PEDIDO);
                    comando.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", lineaPedido.ID_PEDIDO_COMPRA);
                    comando.Parameters.AddWithValue("@CANTIDAD", lineaPedido.CANTIDAD);
                    comando.Parameters.AddWithValue("@PRECIO", lineaPedido.PRECIO);

                    SqlParameter parametroSubtotal = new SqlParameter("@SUBTOTAL", SqlDbType.Float);
                    parametroSubtotal.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(parametroSubtotal);

                    comando.ExecuteNonQuery();

                    lineaPedido.SUBTOTAL = Convert.ToSingle(parametroSubtotal.Value);
                }
            }
        }

        public void EliminarLineaPedido(int idLineaPedido)
        {
            using (SqlConnection conexion = conexionBD.ObtenerConexion())
            {
                using (SqlCommand comando = new SqlCommand("EliminarLineaPedido", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;
                    comando.Parameters.AddWithValue("@ID_LINEAS_PEDIDO", idLineaPedido);

                    comando.ExecuteNonQuery();
                }
            }
        }

        private LineaPedido MapRowToLineaPedido(SqlDataReader reader)
        {
            LineaPedido lineaPedido = new LineaPedido();
            lineaPedido.ID_LINEA_PEDIDO = Convert.ToInt32(reader["ID_LINEAS_PEDIDO"]);
            lineaPedido.ID_PEDIDO_COMPRA = Convert.ToInt32(reader["ID_PEDIDO_COMPRA"]);
            lineaPedido.FECHA_CREACION_LINEA_PEDIDO = Convert.ToDateTime(reader["FECHA_CREACION_LINEA_PEDIDO"]);
            lineaPedido.ACTIVO_LINEA_PEDIDO = Convert.ToBoolean(reader["ACTIVO_LINEA_PEDIDO"]);
            lineaPedido.CANTIDAD = Convert.ToInt32(reader["CANTIDAD"]);
            lineaPedido.PRECIO = Convert.ToSingle(reader["PRECIO"]);
            lineaPedido.SUBTOTAL = Convert.ToSingle(reader["SUBTOTAL"]);

            return lineaPedido;
        }
    }
}
