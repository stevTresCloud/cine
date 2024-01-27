using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Reparto
    {
        public int ID_REPARTO { get; set; }
        public string NOMBRE { get; set; }
        public DateTime FECHA_CREACION_REPARTO { get; set; }
        public bool ACTIVO_REPARTO { get; set; }

        public Reparto()
        {
        }

        public Reparto(int idReparto, string nombre, DateTime fechaCreacionReparto, bool activoReparto)
        {
            ID_REPARTO = idReparto;
            NOMBRE = nombre;
            FECHA_CREACION_REPARTO = fechaCreacionReparto;
            ACTIVO_REPARTO = activoReparto;
        }
    }
}
