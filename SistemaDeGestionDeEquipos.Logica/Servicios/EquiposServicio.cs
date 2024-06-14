using SistemaDeGestionDeEquipos.Data.Entidades;

namespace SistemaDeGestionDeEquipos.Logica.Servicios
{
    public interface IEquiposServicio
    {
        List<Equipo> ListarEquiposParticipantesDelTorneo();
    }

    public class EquiposServicio : IEquiposServicio
    {
        private SistemaDeGestionDeEquiposContext _context;
        public EquiposServicio(SistemaDeGestionDeEquiposContext context)
        {
            _context = context;
        }

        public List<Equipo> ListarEquiposParticipantesDelTorneo()
        {
            return _context.Equipos
                .Where(e => e.ParticipaEnTorneo)
                .OrderBy(e => e.NombreEquipo)
                .ToList();
        }
    }
}
