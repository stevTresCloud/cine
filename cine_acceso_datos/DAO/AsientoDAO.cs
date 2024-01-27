﻿using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.DAO
{
    public class AsientoDAO
    {
        private string connectionString;

        public AsientoDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertarAsiento(Asiento asiento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("InsertarAsiento", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", asiento.ID_SALA_CINE);
                    cmd.Parameters.AddWithValue("@FILA", asiento.FILA);
                    cmd.Parameters.AddWithValue("@COLUMNA", asiento.COLUMNA);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<Asiento> ObtenerAsientos()
        {
            List<Asiento> asientos = new List<Asiento>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ObtenerAsientos", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Asiento asiento = new Asiento
                            {
                                ID_ASIENTOS = Convert.ToInt32(reader["ID_ASIENTOS"]),
                                ID_SALA_CINE = Convert.ToInt32(reader["ID_SALA_CINE"]),
                                FECHA_CREACION_ASIENTOS = Convert.ToDateTime(reader["FECHA_CREACION_ASIENTOS"]),
                                ACTIVO_ASIENTOS = Convert.ToBoolean(reader["ACTIVO_ASIENTOS"]),
                                FILA = reader["FILA"].ToString(),
                                COLUMNA = reader["COLUMNA"].ToString(),
                                DISPONIBILIDAD = Convert.ToBoolean(reader["DISPONIBILIDAD"])
                            };

                            asientos.Add(asiento);
                        }
                    }
                }
            }

            return asientos;
        }

        public void ActualizarAsiento(Asiento asiento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("ActualizarAsiento", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_ASIENTOS", asiento.ID_ASIENTOS);
                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", asiento.ID_SALA_CINE);
                    cmd.Parameters.AddWithValue("@FILA", asiento.FILA);
                    cmd.Parameters.AddWithValue("@COLUMNA", asiento.COLUMNA);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarAsiento(int idAsiento)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand cmd = new SqlCommand("EliminarAsiento", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_ASIENTOS", idAsiento);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
