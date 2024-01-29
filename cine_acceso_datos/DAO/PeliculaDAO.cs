using cine_acceso_datos.Entidades;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.DAO
{
    public class PeliculaDAO
    {
        private readonly ConexionBD conexionBD;

        public PeliculaDAO()
        {
            conexionBD = new ConexionBD();
        }

        public PeliculaDAO(ConexionBD conexionBD)
        {
            this.conexionBD = conexionBD;
        }

        public void InsertarPelicula(int idLineasPedido, string titulo, string categoria, string restriccion, string sinopsis,
            string trailerUrl, int calificacion, int cantidadPelicula)
        {
            try
            {
                using (SqlConnection connection = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("usp_InsertarPelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_LINEAS_PEDIDO", idLineasPedido);
                        command.Parameters.AddWithValue("@TITULO", titulo);
                        command.Parameters.AddWithValue("@CATEGORIA", categoria);
                        command.Parameters.AddWithValue("@RESTRICCION", restriccion);
                        command.Parameters.AddWithValue("@SINOPSIS", sinopsis);
                        command.Parameters.AddWithValue("@TRAILER_URL", trailerUrl);
                        command.Parameters.AddWithValue("@CALIFICACION", calificacion);
                        command.Parameters.AddWithValue("@CANTIDAD_PELICULA", cantidadPelicula);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar película", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public List<Pelicula> SeleccionarPeliculas()
        {
            List<Pelicula> peliculas = new List<Pelicula>();

            try
            {
                using (SqlConnection connection = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("usp_SeleccionarPeliculas", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Pelicula pelicula = MapPeliculaFromReader(reader);
                                peliculas.Add(pelicula);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar películas", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return peliculas;
        }

        public Pelicula SeleccionarPeliculaPorID(int idPelicula)
        {
            Pelicula pelicula = new Pelicula();

            try
            {
                using (SqlConnection connection = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("usp_SeleccionarPeliculaPorID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_PELICULA", idPelicula);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                pelicula = MapPeliculaFromReader(reader);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al seleccionar película por ID", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }

            return pelicula;
        }

        public void ActualizarPelicula(int idPelicula, int idLineasPedido, string titulo, string categoria, string restriccion, string sinopsis,
                       string trailerUrl, int calificacion, int cantidadPelicula)
        {
            try
            {
                using (SqlConnection connection = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("usp_ActualizarPelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_PELICULA", idPelicula);
                        command.Parameters.AddWithValue("@ID_LINEAS_PEDIDO", idLineasPedido);
                        command.Parameters.AddWithValue("@TITULO", titulo);
                        command.Parameters.AddWithValue("@CATEGORIA", categoria);
                        command.Parameters.AddWithValue("@RESTRICCION", restriccion);
                        command.Parameters.AddWithValue("@SINOPSIS", sinopsis);
                        command.Parameters.AddWithValue("@TRAILER_URL", trailerUrl);
                        command.Parameters.AddWithValue("@CALIFICACION", calificacion);
                        command.Parameters.AddWithValue("@CANTIDAD_PELICULA", cantidadPelicula);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar película", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        public void EliminarPelicula(int idPelicula)
        {
            try
            {
                using (SqlConnection connection = conexionBD.ObtenerConexion())
                {
                    using (SqlCommand command = new SqlCommand("usp_EliminarPelicula", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@ID_PELICULA", idPelicula);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar película", ex);
            }
            finally
            {
                conexionBD.CerrarConexion();
            }
        }

        private Pelicula MapPeliculaFromReader(SqlDataReader reader)
        {
            return new Pelicula
            {
                ID_PELICULA = (int)reader["ID_PELICULA"],
                ID_LINEAS_PEDIDO = reader["ID_LINEAS_PEDIDO"] as int?,
                TITULO = reader["TITULO"].ToString(),
                CATEGORIA = reader["CATEGORIA"].ToString(),
                RESTRICCION = reader["RESTRICCION"].ToString(),
                SINOPSIS = reader["SINOPSIS"] as string,
                TRAILER_URL = reader["TRAILER_URL"] as string,
                CALIFICACION = reader["CALIFICACION"] as int?,
                FECHA_CREACION_PELICULA = (DateTime)reader["FECHA_CREACION_PELICULA"],
                ACTIVO_PELICULA = (bool)reader["ACTIVO_PELICULA"],
                CANTIDAD_PELICULA = (int)reader["CANTIDAD_PELICULA"]
            };
        }
    }
}
