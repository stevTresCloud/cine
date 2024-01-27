using Microsoft.Data.SqlClient;

public class ConexionBD
{
    private string cadenaConexion;
    private SqlConnection conexion;
    private string connectionString;

    public ConexionBD()
    {
        cadenaConexion = "Server=STEVEN-LUNA\\SQLEXPRESS;DataBase=extremCinema;User Id=usuarioCinema;Password=uisrael1309";
        conexion = new SqlConnection(cadenaConexion);
    }

    public ConexionBD(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public SqlConnection ObtenerConexion()
    {
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
