using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Pelicula
    {
        public int ID_PELICULA { get; set; }
        public string TITULO { get; set; }
        public string CATEGORIA { get; set; }
        public string RESTRICCION { get; set; }
        public string SINOPSIS { get; set; }
        public string TRAILER_URL { get; set; }
        public int CALIFICACION { get; set; }
        public DateTime FECHA_CREACION_PELICULA { get; set; }
        public bool ACTIVO_PELICULA { get; set; }
        public int CANTIDAD_PELICULA { get; set; }

        public Pelicula()
        {
        }

        public Pelicula(int idPelicula, string titulo, string categoria,
                        string restriccion, string sinopsis, string trailerUrl, int calificacion,
                        DateTime fechaCreacion, bool activo, int cantidad)
        {
            ID_PELICULA = idPelicula;
            TITULO = titulo;
            CATEGORIA = categoria;
            RESTRICCION = restriccion;
            SINOPSIS = sinopsis;
            TRAILER_URL = trailerUrl;
            CALIFICACION = calificacion;
            FECHA_CREACION_PELICULA = fechaCreacion;
            ACTIVO_PELICULA = activo;
            CANTIDAD_PELICULA = cantidad;
        }
    }
}
