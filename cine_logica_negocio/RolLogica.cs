using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_logica_negocio
{
    public class RolLogica
    {
        private RolDAO rolDao;

        public RolLogica()
        {
            rolDao = new RolDAO();
        }

        public void InsertarRol(Rol rol)
        {
            rolDao.InsertarRol(rol);
        }

        public List<Rol> ObtenerTodosLosRoles()
        {
            return rolDao.ObtenerTodosLosRoles();
        }

        public Rol ObtenerRolPorID(int idRol)
        {
            return rolDao.ObtenerRolPorID(idRol);
        }

        public void ActualizarRol(Rol rol)
        {
            rolDao.ActualizarRol(rol);
        }

        public void EliminarRol(int idRol)
        {
            rolDao.EliminarRol(idRol);
        }
    }

}
