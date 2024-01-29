using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;

namespace cine_logica_negocio
{
    public class PeliculaLogica
    {
        private PeliculaDAO peliculaDao = new PeliculaDAO();

        public int InsertarPelicula(int idLineasPedido, string titulo, string categoria, string restriccion, string sinopsis,
            string trailerUrl, int calificacion, int cantidadPelicula)
        {
            peliculaDao.InsertarPelicula(idLineasPedido, titulo, categoria, restriccion, sinopsis, trailerUrl, calificacion, cantidadPelicula);
            List<Pelicula> peliculas = peliculaDao.SeleccionarPeliculas();
            return peliculas.Last().ID_PELICULA;
        }

        public List<Pelicula> SeleccionarPeliculas()
        {
            return peliculaDao.SeleccionarPeliculas();
        }

        public Pelicula SeleccionarPeliculaPorID(int idPelicula)
        {
            return peliculaDao.SeleccionarPeliculaPorID(idPelicula);
        }

        public void ActualizarPelicula(int idPelicula, int idLineasPedido, string titulo, string categoria, string restriccion, string sinopsis,
            string trailerUrl, int calificacion, int cantidadPelicula)
        {
            peliculaDao.ActualizarPelicula(idPelicula, idLineasPedido, titulo, categoria, restriccion, sinopsis, trailerUrl, calificacion, cantidadPelicula);
        }

        public void EliminarPelicula(int idPelicula)
        {
            peliculaDao.EliminarPelicula(idPelicula);
        }
    }

}
