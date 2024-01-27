using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class SalaCine
    {
        public int ID_SALA_CINE { get; set; }
        public DateTime FECHA_CREACION_SALA_CINE { get; set; }
        public bool ACTIVO_SALA_CINE { get; set; }
        public string NUMERO { get; set; }
        public int CAPACIDAD { get; set; }

        public SalaCine()
        {
        }

        public SalaCine(int idSalaCine, DateTime fechaCreacion, bool activo, string numero, int capacidad)
        {
            ID_SALA_CINE = idSalaCine;
            FECHA_CREACION_SALA_CINE = fechaCreacion;
            ACTIVO_SALA_CINE = activo;
            NUMERO = numero;
            CAPACIDAD = capacidad;
        }
    }
}
