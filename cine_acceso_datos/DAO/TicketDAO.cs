using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class TicketDAO
    {
        private readonly ConexionBD conexionBD;

        public TicketDAO()
        {
            conexionBD = new ConexionBD();
        }

        public TicketDAO(string connectionString)
        {
            conexionBD = new ConexionBD(connectionString);
        }

        public void InsertarTicket(Ticket ticket)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertarTicket", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_USUARIO", ticket.ID_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CODIGO_COMPRA", ticket.CODIGO_COMPRA);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar el ticket", ex);
                }
            }
        }

        public List<Ticket> ObtenerTodosLosTickets()
        {
            List<Ticket> ticketsList = new List<Ticket>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerTickets", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Ticket ticket = MapReaderToTicket(reader);
                            ticketsList.Add(ticket);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener todos los tickets", ex);
                }
            }

            return ticketsList;
        }

        public Ticket ObtenerTicketPorID(int idTicket)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerTicketPorID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_TICKET", idTicket);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToTicket(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener el ticket con ID {idTicket}", ex);
                }

                return null;
            }
        }

        public void ActualizarTicket(Ticket ticket)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ActualizarTicket", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", ticket.ID_SALA_CINE);
                    cmd.Parameters.AddWithValue("@ID_USUARIO", ticket.ID_USUARIO ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@CODIGO_COMPRA", ticket.CODIGO_COMPRA);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al actualizar el ticket con ID {ticket.ID_TICKET}", ex);
                }
            }
        }

        public void EliminarTicket(int idTicket)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EliminarTicket", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", idTicket);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar el ticket con ID {idTicket}", ex);
                }
            }
        }

        private Ticket MapReaderToTicket(SqlDataReader reader)
        {
            return new Ticket
            {
                ID_SALA_CINE = Convert.ToInt32(reader["ID_SALA_CINE"]),
                ID_USUARIO = reader["ID_USUARIO"] != DBNull.Value ? Convert.ToInt32(reader["ID_USUARIO"]) : (int?)null,
                ID_TICKET = Convert.ToInt32(reader["ID_TICKET"]),
                CODIGO_COMPRA = Convert.ToString(reader["CODIGO_COMPRA"]),
                FECHA_CREACION_TICKET = Convert.ToDateTime(reader["FECHA_CREACION_TICKET"]),
                ACTIVO_TICKET = Convert.ToBoolean(reader["ACTIVO_TICKET"])
            };
        }
    }
}
