using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Boletos
    {
        public int IdSalaCine { get; set; }
        public int IdBoletos { get; set; }
        public DateTime FechaCreacionBoletos { get; set; }
        public bool ActivoBoletos { get; set; }
        public string CodigoTicket { get; set; }

        public Boletos()
        {
        }

        public Boletos(int idBoletos, DateTime fechaCreacionBoletos, bool activoBoletos, string codigoTicket)
        {
            IdBoletos = idBoletos;
            FechaCreacionBoletos = fechaCreacionBoletos;
            ActivoBoletos = activoBoletos;
            CodigoTicket = codigoTicket;
        }
    }
}
