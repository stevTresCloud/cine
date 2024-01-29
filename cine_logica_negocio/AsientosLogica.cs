using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cine_acceso_datos.DAO;
using cine_acceso_datos.Entidades;


namespace cinema_logica_negocio
{
    public class AsientosLogica
    {
        private AsientoDAO asientosDao;

        public AsientosLogica()
        {
            asientosDao = new AsientoDAO();
        }

        public int InsertarAsiento(Asiento asientos)
        {
            asientosDao.InsertarAsiento(asientos);
            List<Asiento> resultado = asientosDao.ObtenerAsientos();
            return resultado.Count > 0 ? resultado[0].ID_ASIENTOS : -1;
        }

        public List<Asiento> ListarAsiento()
        {
            return asientosDao.ObtenerAsientos();
        }

        public Asiento ObtenerAsiento(int idAsiento)
        {
            List<Asiento> asientos = asientosDao.ObtenerAsientos();
            return asientos.Find(a => a.ID_ASIENTOS == idAsiento);
        }

        public void ActualizarAsiento(Asiento asiento)
        {
            asientosDao.ActualizarAsiento(asiento);
        }

        public void EliminarAsiento(int idAsiento)
        {
            asientosDao.EliminarAsiento(idAsiento);
        }
    }

}
