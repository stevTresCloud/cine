using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cine_acceso_datos.DAO
{
    public class RepartoDAO
    {
        private readonly string connectionString;

        public RepartoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertarReparto(Reparto reparto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("InsertarReparto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@NOMBRE", reparto.NOMBRE);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Reparto> ObtenerRepartos()
        {
            List<Reparto> repartos = new List<Reparto>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ObtenerRepartos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Reparto reparto = new Reparto
                            {
                                ID_REPARTO = Convert.ToInt32(reader["ID_REPARTO"]),
                                NOMBRE = Convert.ToString(reader["NOMBRE"]),
                                FECHA_CREACION_REPARTO = Convert.ToDateTime(reader["FECHA_CREACION_REPARTO"]),
                                ACTIVO_REPARTO = Convert.ToBoolean(reader["ACTIVO_REPARTO"])
                            };

                            repartos.Add(reparto);
                        }
                    }
                }
            }

            return repartos;
        }

        public Reparto ObtenerRepartoPorID(int idReparto)
        {
            Reparto reparto = null;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ObtenerRepartoPorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_REPARTO", idReparto);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            reparto = new Reparto
                            {
                                ID_REPARTO = Convert.ToInt32(reader["ID_REPARTO"]),
                                NOMBRE = Convert.ToString(reader["NOMBRE"]),
                                FECHA_CREACION_REPARTO = Convert.ToDateTime(reader["FECHA_CREACION_REPARTO"]),
                                ACTIVO_REPARTO = Convert.ToBoolean(reader["ACTIVO_REPARTO"])
                            };
                        }
                    }
                }
            }

            return reparto;
        }

        public void ActualizarReparto(Reparto reparto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("ActualizarReparto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_REPARTO", reparto.ID_REPARTO);
                    command.Parameters.AddWithValue("@NOMBRE", reparto.NOMBRE);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarReparto(int idReparto)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("EliminarReparto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_REPARTO", idReparto);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
