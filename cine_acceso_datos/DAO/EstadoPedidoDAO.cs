using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.DAO
{
    public class EstadoPedidoDAO
    {
        private ConexionBD conexion;

        public EstadoPedidoDAO()
        {
            conexion = new ConexionBD();
        }

        public EstadoPedidoDAO(ConexionBD conexion)
        {
            this.conexion = conexion;
        }

        public void InsertarEstadoPedido(string tipoEstadoPedido, bool activoEstadoPedido)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("InsertarEstadoPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@TIPO_ESTADO_PEDIDO", tipoEstadoPedido);
                    command.Parameters.AddWithValue("@ACTIVO_ESTADO_PEDIDO", activoEstadoPedido);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<EstadoPedido> ObtenerTodosEstadosPedido()
        {
            List<EstadoPedido> estadosPedido = new List<EstadoPedido>();

            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("ObtenerTodosEstadosPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            EstadoPedido estadoPedido = new EstadoPedido
                            {
                                ID_ESTADO_PEDIDO = Convert.ToInt32(reader["ID_ESTADO_PEDIDO"]),
                                TIPO_ESTADO_PEDIDO = Convert.ToString(reader["TIPO_ESTADO_PEDIDO"]),
                                FECHA_CREACION_ESTADO_PEDIDO = Convert.ToDateTime(reader["FECHA_CREACION_ESTADO_PEDIDO"]),
                                ACTIVO_ESTADO_PEDIDO = Convert.ToBoolean(reader["ACTIVO_ESTADO_PEDIDO"])
                            };

                            estadosPedido.Add(estadoPedido);
                        }
                    }
                }
            }

            return estadosPedido;
        }

        public EstadoPedido ObtenerEstadoPedidoPorID(int idEstadoPedido)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("ObtenerEstadoPedidoPorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_ESTADO_PEDIDO", idEstadoPedido);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            EstadoPedido estadoPedido = new EstadoPedido
                            {
                                ID_ESTADO_PEDIDO = Convert.ToInt32(reader["ID_ESTADO_PEDIDO"]),
                                TIPO_ESTADO_PEDIDO = Convert.ToString(reader["TIPO_ESTADO_PEDIDO"]),
                                FECHA_CREACION_ESTADO_PEDIDO = Convert.ToDateTime(reader["FECHA_CREACION_ESTADO_PEDIDO"]),
                                ACTIVO_ESTADO_PEDIDO = Convert.ToBoolean(reader["ACTIVO_ESTADO_PEDIDO"])
                            };

                            return estadoPedido;
                        }
                    }
                }
            }

            return null;
        }

        public void ActualizarEstadoPedido(int idEstadoPedido, string tipoEstadoPedido, bool activoEstadoPedido)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("ActualizarEstadoPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_ESTADO_PEDIDO", idEstadoPedido);
                    command.Parameters.AddWithValue("@TIPO_ESTADO_PEDIDO", tipoEstadoPedido);
                    command.Parameters.AddWithValue("@ACTIVO_ESTADO_PEDIDO", activoEstadoPedido);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarEstadoPedido(int idEstadoPedido)
        {
            using (SqlConnection connection = conexion.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("EliminarEstadoPedido", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_ESTADO_PEDIDO", idEstadoPedido);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
