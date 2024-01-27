using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Horario
    {
        public int IdHorario { get; set; }
        public int IdSalaCine { get; set; }
        public int IdPelicula { get; set; }
        public DateTime FechaCreacionHorario { get; set; }
        public bool ActivoHorario { get; set; }
        public string HoraInicio { get; set; }
        public DateTime Fecha { get; set; }

        public Horario()
        {
        }

        public Horario(int idSalaCine, int idPelicula, bool activoHorario, string horaInicio, DateTime fecha)
        {
            IdSalaCine = idSalaCine;
            IdPelicula = idPelicula;
            FechaCreacionHorario = DateTime.Now;
            ActivoHorario = activoHorario;
            HoraInicio = horaInicio;
            Fecha = fecha;
        }
    }
}
