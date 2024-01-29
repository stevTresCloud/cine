using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cine_acceso_datos.Entidades;
using cine_acceso_datos.DAO;

namespace cine_logica_negocio
{
    public class HorarioLogica
    {
        private HorarioDAO horarioDao = new HorarioDAO();

        public HorarioLogica()
        {
        }

        public int InsertarHorario(int idSalaCine, int idPelicula, string horaInicio, DateTime fecha)
        {
            horarioDao.InsertarHorario(idSalaCine, idPelicula, horaInicio, fecha);
            List<Horario> horarios = horarioDao.SeleccionarHorarios();
            return horarios.Last().ID_HORARIO;
        }

        public List<Horario> SeleccionarHorarios()
        {
            return horarioDao.SeleccionarHorarios();
        }

        public Horario SeleccionarHorarioPorID(int idHorario)
        {
            return horarioDao.SeleccionarHorarios().FirstOrDefault(h => h.ID_HORARIO == idHorario);
        }

        public void ActualizarHorario(int idHorario, int idSalaCine, int idPelicula, string horaInicio, DateTime fecha)
        {
            horarioDao.ActualizarHorario(idHorario, idSalaCine, idPelicula, horaInicio, fecha);
        }

        public void EliminarHorario(int idHorario)
        {
            horarioDao.EliminarHorario(idHorario);
        }
    }
}
