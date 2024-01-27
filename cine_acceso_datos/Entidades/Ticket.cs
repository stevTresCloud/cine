using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Ticket
    {
        public int ID_SALA_CINE { get; set; }
        public int? ID_USUARIO { get; set; }
        public int ID_TICKET { get; set; }
        public string CODIGO_COMPRA { get; set; }
        public DateTime FECHA_CREACION_TICKET { get; set; }
        public bool ACTIVO_TICKET { get; set; }

        public Ticket()
        {
        }

        public Ticket(int idSalaCine, int? idUsuario, int idTicket, string codigoCompra, DateTime fechaCreacionTicket, bool activoTicket)
        {
            ID_SALA_CINE = idSalaCine;
            ID_USUARIO = idUsuario;
            ID_TICKET = idTicket;
            CODIGO_COMPRA = codigoCompra;
            FECHA_CREACION_TICKET = fechaCreacionTicket;
            ACTIVO_TICKET = activoTicket;
        }
    }
}
