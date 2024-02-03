using cine_acceso_datos.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace cine_acceso_datos.DAO
{
    public class SalaCineDAO
    {
        private readonly ConexionBD conexionBD;

        public SalaCineDAO()
        {
            conexionBD = new ConexionBD();
        }

        public void InsertarSalaCine(SalaCine salaCine)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("InsertarSalaCine", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@NUMERO", salaCine.NUMERO);
                    cmd.Parameters.AddWithValue("@CAPACIDAD", salaCine.CAPACIDAD);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al insertar la sala de cine", ex);
                }
            }
        }

        public List<SalaCine> ObtenerTodasLasSalasCine()
        {
            List<SalaCine> salasCineList = new List<SalaCine>();

            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerSalasCine", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SalaCine salaCine = MapReaderToSalaCine(reader);
                            salasCineList.Add(salaCine);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al obtener todas las salas de cine", ex);
                }
            }

            return salasCineList;
        }

        public SalaCine ObtenerSalaCinePorID(int idSalaCine)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ObtenerSalaCinePorID", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", idSalaCine);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return MapReaderToSalaCine(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al obtener la sala de cine con ID {idSalaCine}", ex);
                }

                return null;
            }
        }

        public void ActualizarSalaCine(SalaCine salaCine)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("ActualizarSalaCine", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", salaCine.ID_SALA_CINE);
                    cmd.Parameters.AddWithValue("@NUMERO", salaCine.NUMERO);
                    cmd.Parameters.AddWithValue("@CAPACIDAD", salaCine.CAPACIDAD);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al actualizar la sala de cine con ID {salaCine.ID_SALA_CINE}", ex);
                }
            }
        }

        public void EliminarSalaCine(int idSalaCine)
        {
            using (SqlConnection connection = conexionBD.ObtenerConexion())
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("EliminarSalaCine", connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ID_SALA_CINE", idSalaCine);

                    cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error al eliminar la sala de cine con ID {idSalaCine}", ex);
                }
            }
        }

        private SalaCine MapReaderToSalaCine(SqlDataReader reader)
        {
            return new SalaCine
            {
                ID_SALA_CINE = Convert.ToInt32(reader["ID_SALA_CINE"]),
                FECHA_CREACION_SALA_CINE = Convert.ToDateTime(reader["FECHA_CREACION_SALA_CINE"]),
                ACTIVO_SALA_CINE = Convert.ToBoolean(reader["ACTIVO_SALA_CINE"]),
                NUMERO = Convert.ToString(reader["NUMERO"]),
                CAPACIDAD = Convert.ToInt32(reader["CAPACIDAD"])
            };
        }
    }

}
