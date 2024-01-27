using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Boletos
    {
        public int ID_SALA_CINE { get; set; }
        public int ID_BOLETOS { get; set; }
        public DateTime FECHA_CREACION_BOLETOS { get; set; }
        public bool ACTIVO_BOLETOS { get; set; }
        public string CODIGO_TICKET { get; set; }

        public Boletos()
        {
        }

        public Boletos(int idBoletos, DateTime fechaCreacionBoletos, bool activoBoletos, string codigoTicket)
        {
            ID_BOLETOS = idBoletos;
            FECHA_CREACION_BOLETOS = fechaCreacionBoletos;
            ACTIVO_BOLETOS = activoBoletos;
            CODIGO_TICKET = codigoTicket;
        }
    }
}
