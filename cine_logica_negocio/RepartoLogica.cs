using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cine_logica_negocio
{
    public class RepartoLogica
    {
        private RepartoDAO repartoDao;

        public RepartoLogica()
        {
            repartoDao = new RepartoDAO();
        }

        public void InsertarReparto(Reparto reparto)
        {
            repartoDao.InsertarReparto(reparto);
        }

        public List<Reparto> ObtenerTodosRepartos()
        {
            return repartoDao.ObtenerRepartos();
        }

        public Reparto ObtenerRepartoPorID(int idReparto)
        {
            return repartoDao.ObtenerRepartoPorID(idReparto);
        }

        public void ActualizarReparto(Reparto reparto)
        {
            repartoDao.ActualizarReparto(reparto);
        }

        public void EliminarReparto(int idReparto)
        {
            repartoDao.EliminarReparto(idReparto);
        }
    }
}
