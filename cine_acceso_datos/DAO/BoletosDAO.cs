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
    public class BoletosDAO
    {
        private readonly string connectionString;

        public BoletosDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertarBoleto(int idBoletos, string codigoTicket)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("InsertarBoleto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_BOLETOS", idBoletos);
                    command.Parameters.AddWithValue("@CODIGO_TICKET", codigoTicket);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Boletos> ObtenerBoletos()
        {
            List<Boletos> boletos = new List<Boletos>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ObtenerBoletos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Boletos boleto = new Boletos
                            {
                                ID_SALA_CINE = (int)reader["ID_SALA_CINE"],
                                ID_BOLETOS = (int)reader["ID_BOLETOS"],
                                FECHA_CREACION_BOLETOS = (DateTime)reader["FECHA_CREACION_BOLETOS"],
                                ACTIVO_BOLETOS = (bool)reader["ACTIVO_BOLETOS"],
                                CODIGO_TICKET = reader["CODIGO_TICKET"].ToString()
                            };
                            boletos.Add(boleto);
                        }
                    }
                }
            }
            return boletos;
        }

        public void ActualizarBoleto(int idSalaCine, int idBoletos, string codigoTicket)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("ActualizarBoleto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_SALA_CINE", idSalaCine);
                    command.Parameters.AddWithValue("@ID_BOLETOS", idBoletos);
                    command.Parameters.AddWithValue("@CODIGO_TICKET", codigoTicket);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void EliminarBoleto(int ID_SALA_CINE)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("EliminarBoleto", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID_SALA_CINE", ID_SALA_CINE);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
