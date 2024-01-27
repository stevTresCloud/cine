using System;
using System.Collections.Generic;
using System;
using Microsoft.Data.SqlClient;
using System.Data;

namespace cinema_acceso_datos
{
    public class ConexionDB
    {
        //1.- escibir la conexion de DB
        private SqlConnection connection = new SqlConnection("Server=STEVEN-LUNA\\SQLEXPRESS;DataBase=extremCinema;User Id=usuarioCinema;Password=uisrael1309");

        //2.- método para abrir la conexion

        public SqlConnection AbrirConexion()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
            return connection;
        }

        //3.- método para cerrar la conexion
        public SqlConnection CerrarConexion()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
            return connection;
        }


    }
}
