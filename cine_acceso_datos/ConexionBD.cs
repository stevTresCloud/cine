using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos
{
    public class ConexionBD
    {
        private static readonly string cadenaConexion = "Data Source=STEVEN-LUNA;Initial Catalog=extrem_cinema;Persist Security Info=True;User ID=sa;Password=uisrael1309;TrustServerCertificate=True";
        private SqlConnection conexion;

        public ConexionBD()
        {
            conexion = new SqlConnection(cadenaConexion);
        }

        public SqlConnection ObtenerConexion()
        {
            if (conexion.ConnectionString == string.Empty)
            {
                conexion.ConnectionString = cadenaConexion;
            }
            try
            {
                if (conexion.State == System.Data.ConnectionState.Closed)
                {
                    conexion.Open();
                }
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al abrir la conexión a la base de datos", ex);
            }
        }

        public void CerrarConexion()
        {
            try
            {
                if (conexion.State == System.Data.ConnectionState.Open)
                {
                    conexion.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cerrar la conexión a la base de datos", ex);
            }
        }
    }

}