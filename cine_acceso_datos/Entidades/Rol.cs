using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Rol
    {
        public int ID_ROL { get; set; }
        public int? ID_USUARIO { get; set; }
        public string TIPO_ROL { get; set; }
        public string DESCRIPCION { get; set; }
        public DateTime FECHA_CREACION_ROL { get; set; }
        public bool ACTIVO_ROL { get; set; }

        public Rol()
        {
        }

        public Rol(int idRol, int? idUsuario, string tipoRol, string descripcion, DateTime fechaCreacionRol, bool activoRol)
        {
            ID_ROL = idRol;
            ID_USUARIO = idUsuario;
            TIPO_ROL = tipoRol;
            DESCRIPCION = descripcion;
            FECHA_CREACION_ROL = fechaCreacionRol;
            ACTIVO_ROL = activoRol;
        }
    }
}
