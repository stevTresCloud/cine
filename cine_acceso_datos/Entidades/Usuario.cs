using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_acceso_datos.Entidades
{
    public class Usuario
    {
        public int ID_USUARIO { get; set; }
        public int? ID_ROL { get; set; }
        public string LOGIN { get; set; }
        public string CONTRASENA { get; set; }
        public DateTime FECHA_CREACION_USUARIO { get; set; }
        public bool ACTIVO_USUARIO { get; set; }
        public string NOMBRE_USUARIO { get; set; }
        public string APELLIDO_USUARIO { get; set; }
        public string IDENTIFICACION_USUARIO { get; set; }
        public string DIRECCION_USUARIO { get; set; }
        public string TELEFONO_USUARIO { get; set; }
        public string CORREO_USUARIO { get; set; }

        public Usuario()
        {
        }

        public Usuario(int idUsuario, int? idRol, string login, string contrasena, DateTime fechaCreacion,
                       bool activoUsuario, string nombreUsuario, string apellidoUsuario,
                       string identificacionUsuario, string direccionUsuario, string telefonoUsuario, string correoUsuario)
        {
            ID_USUARIO = idUsuario;
            ID_ROL = idRol;
            LOGIN = login;
            CONTRASENA = contrasena;
            FECHA_CREACION_USUARIO = fechaCreacion;
            ACTIVO_USUARIO = activoUsuario;
            NOMBRE_USUARIO = nombreUsuario;
            APELLIDO_USUARIO = apellidoUsuario;
            IDENTIFICACION_USUARIO = identificacionUsuario;
            DIRECCION_USUARIO = direccionUsuario;
            TELEFONO_USUARIO = telefonoUsuario;
            CORREO_USUARIO = correoUsuario;
        }
    }
}
