using SistemaDeGestionDeEquipos.Data.Entidades;
using Jugador = SistemaDeGestionDeEquipos.Data.Entidades.Jugador;


namespace SistemaDeGestionDeEquipos.Logica.Servicios
{
    public interface IJugadoresServicio
    {
        void CrearJugador(Jugador jugador);
        List<Jugador> ListarJugadoresQueParticipanEnElTorneo();
        List<Jugador> ListarJugadoresPorEquipo(int idEquipo);
    }

    public class JugadoresServicio : IJugadoresServicio
    {
        private SistemaDeGestionDeEquiposContext _context;

        public JugadoresServicio(SistemaDeGestionDeEquiposContext context)
        {
            _context = context;
        }

        public void CrearJugador(Jugador jugador)
        {
            _context.Jugadors.Add(jugador);
            _context.SaveChanges();
        }

        public List<Jugador> ListarJugadoresQueParticipanEnElTorneo()
        {
            return _context.Jugadors
                .Where(e => e.IdEquipoNavigation.ParticipaEnTorneo)
                .ToList();
        }

        public List<Jugador> ListarJugadoresPorEquipo(int idEquipo)
        {
            return _context.Jugadors
                .Where(j => j.IdEquipo == idEquipo)
                .ToList();
        }

    }

}