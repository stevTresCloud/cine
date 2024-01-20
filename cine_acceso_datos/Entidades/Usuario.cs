using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Usuario
    {
        private int id { get; set; }
        private string nombre { get; set; }
        private string clave { get; set; }
        private string correo { get; set; }
        private string tipo { get; set; }
    }
}
