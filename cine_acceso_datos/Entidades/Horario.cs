using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Horario
    {
        public int ID_HORARIO { get; set; }
        public int ID_SALA_CINE { get; set; }
        public int ID_PELICULA { get; set; }
        public DateTime FECHA_CREACION_HORARIO { get; set; }
        public bool ACTIVO_HORARIO { get; set; }
        public string HORA_INICIO { get; set; }
        public DateTime FECHA { get; set; }

        public Horario()
        {
        }

        public Horario(int idSalaCine, int idPelicula, bool activoHorario, string horaInicio, DateTime fecha)
        {
            ID_SALA_CINE = idSalaCine;
            ID_PELICULA = idPelicula;
            FECHA_CREACION_HORARIO = DateTime.Now;
            ACTIVO_HORARIO = activoHorario;
            HORA_INICIO = horaInicio;
            FECHA = fecha;
        }
    }
}
