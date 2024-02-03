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
    public class HorarioDAO
    {
        private readonly ConexionBD conexionBD;

        public HorarioDAO()
        {
            conexionBD = new ConexionBD();
        }

        public HorarioDAO(ConexionBD conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public void InsertarHorario(int idSalaCine, int idPelicula, string horaInicio, DateTime fecha)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("usp_InsertarHorario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_SALA_CINE", idSalaCine);
                    command.Parameters.AddWithValue("@ID_PELICULA", idPelicula);
                    command.Parameters.AddWithValue("@HORA_INICIO", horaInicio);
                    command.Parameters.AddWithValue("@FECHA", fecha);

                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Horario> SeleccionarHorarios()
        {
            List<Horario> horarios = new List<Horario>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("usp_SeleccionarHorarios", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Horario horario = new Horario
                            {
                                ID_HORARIO = Convert.ToInt32(reader["ID_HORARIO"]),
                                ID_SALA_CINE = Convert.ToInt32(reader["ID_SALA_CINE"]),
                                ID_PELICULA = Convert.ToInt32(reader["ID_PELICULA"]),
                                FECHA_CREACION_HORARIO = Convert.ToDateTime(reader["FECHA_CREACION_HORARIO"]),
                                ACTIVO_HORARIO = Convert.ToBoolean(reader["ACTIVO_HORARIO"]),
                                HORA_INICIO = Convert.ToString(reader["HORA_INICIO"]),
                                FECHA = Convert.ToDateTime(reader["FECHA"])
                            };

                            horarios.Add(horario);
                        }
                    }
                }
            }

            return horarios;
        }

        public void ActualizarHorario(int idHorario, int idSalaCine, int idPelicula, string horaInicio, DateTime fecha)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("usp_ActualizarHorario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_HORARIO", idHorario);
                    command.Parameters.AddWithValue("@ID_SALA_CINE", idSalaCine);
                    command.Parameters.AddWithValue("@ID_PELICULA", idPelicula);
                    command.Parameters.AddWithValue("@HORA_INICIO", horaInicio);
                    command.Parameters.AddWithValue("@FECHA", fecha);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarHorario(int idHorario)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                using (SqlCommand command = new SqlCommand("usp_EliminarHorario", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_HORARIO", idHorario);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
