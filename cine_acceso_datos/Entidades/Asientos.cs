using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Asiento
    {
        public int ID_ASIENTOS { get; set; }
        public int ID_SALA_CINE { get; set; }
        public DateTime FECHA_CREACION_ASIENTOS { get; set; }
        public bool ACTIVO_ASIENTOS { get; set; }
        public string FILA { get; set; }
        public string COLUMNA { get; set; }
        public bool DISPONIBILIDAD { get; set; }

        // Constructor vacío
        public Asiento()
        {
        }

        // Constructor sobrecargado
        public Asiento(int idAsientos, int idSalaCine, DateTime fechaCreacion, bool activoAsientos,
                       string fila, string columna, bool disponibilidad)
        {
            ID_ASIENTOS = idAsientos;
            ID_SALA_CINE = idSalaCine;
            FECHA_CREACION_ASIENTOS = fechaCreacion;
            ACTIVO_ASIENTOS = activoAsientos;
            FILA = fila;
            COLUMNA = columna;
            DISPONIBILIDAD = disponibilidad;
        }
    }
}
