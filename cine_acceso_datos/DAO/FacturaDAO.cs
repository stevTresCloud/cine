using cine_acceso_datos.Entidades;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.DAO
{
    public class FacturaDAO
    {
        private ConexionBD conexionBD;

        public FacturaDAO()
        {
            conexionBD = new ConexionBD();
        }

        public FacturaDAO(ConexionBD conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public void InsertarFactura(int pedidoFactura, string numeroFactura, DateTime fechaExpedicion, string estadoPago)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("InsertarFactura", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", pedidoFactura);
                    cmd.Parameters.AddWithValue("@NUMERO_FACTURA", numeroFactura);
                    cmd.Parameters.AddWithValue("@FECHA_EXPEDICION", fechaExpedicion);
                    cmd.Parameters.AddWithValue("@ESTADO_PAGO", estadoPago);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Factura> ObtenerTodasFacturas()
        {
            List<Factura> facturas = new List<Factura>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerTodasFacturas", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Factura factura = new Factura
                            {
                                ID_PEDIDO_COMPRA = Convert.ToInt32(reader["ID_PEDIDO_COMPRA"]),
                                ID_FACTURA = Convert.ToInt32(reader["ID_FACTURA"]),
                                NUMERO_FACTURA = Convert.ToString(reader["NUMERO_FACTURA"]),
                                FECHA_EXPEDICION = Convert.ToDateTime(reader["FECHA_EXPEDICION"]),
                                ESTADO_PAGO = Convert.ToString(reader["ESTADO_PAGO"])
                            };

                            facturas.Add(factura);
                        }
                    }
                }
            }

            return facturas;
        }

        public Factura ObtenerFacturaPorID(int idFactura)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerFacturaPorID", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Factura factura = new Factura
                            {
                                ID_PEDIDO_COMPRA = Convert.ToInt32(reader["ID_PEDIDO_COMPRA"]),
                                ID_FACTURA = Convert.ToInt32(reader["ID_FACTURA"]),
                                NUMERO_FACTURA = Convert.ToString(reader["NUMERO_FACTURA"]),
                                FECHA_EXPEDICION = Convert.ToDateTime(reader["FECHA_EXPEDICION"]),
                                ESTADO_PAGO = Convert.ToString(reader["ESTADO_PAGO"])
                            };

                            return factura;
                        }
                    }
                }
            }

            return null;
        }

        public void ActualizarFactura(int idPedidoCompra, int idFactura, string numeroFactura, DateTime fechaExpedicion, string estadoPago)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("ActualizarFactura", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_PEDIDO_COMPRA", idPedidoCompra);
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);
                    cmd.Parameters.AddWithValue("@NUMERO_FACTURA", numeroFactura);
                    cmd.Parameters.AddWithValue("@FECHA_EXPEDICION", fechaExpedicion);
                    cmd.Parameters.AddWithValue("@ESTADO_PAGO", estadoPago);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarFactura(int idFactura)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand cmd = new SqlCommand("EliminarFactura", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID_FACTURA", idFactura);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
