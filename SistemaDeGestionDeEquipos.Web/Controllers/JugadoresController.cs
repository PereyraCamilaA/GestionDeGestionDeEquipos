using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEquipos.Data.Entidades;
using SistemaDeGestionDeEquipos.Logica.Servicios;

namespace SistemaDeGestionDeEquipos.Web.Controllers
{
    public class JugadoresController : Controller
    {
            IJugadoresServicio _jugadoresServicio;
            IEquiposServicio _equiposServicio;

        public JugadoresController(IJugadoresServicio jugadoresServicio, IEquiposServicio equiposServicio)
        {
            _jugadoresServicio = jugadoresServicio;
            _equiposServicio = equiposServicio;
        }
        public IActionResult Index(int? idEquipo)
        {
            ViewBag.Equipos = _equiposServicio.ListarEquiposParticipantesDelTorneo();
            ViewBag.IdEquipoSeleccionado = idEquipo;

            if (idEquipo.HasValue)
            {
                var jugadores = _jugadoresServicio.ListarJugadoresPorEquipo(idEquipo.Value);
                return View(jugadores);
            }
            else
            {
                var jugadores = _jugadoresServicio.ListarJugadoresQueParticipanEnElTorneo();
                return View(jugadores);
            }
        }

        //crear empleados

        [HttpGet]
        public IActionResult Crear()
        {
            ViewBag.Equipos = _equiposServicio.ListarEquiposParticipantesDelTorneo();
            return View();
        }

        [HttpPost]
        public IActionResult Crear(Jugador jugador)
        {
            ViewBag.Equipos = _equiposServicio.ListarEquiposParticipantesDelTorneo();

            if (!ModelState.IsValid)
                return View(jugador);

            _jugadoresServicio.CrearJugador(jugador);

            return RedirectToAction("Index");
        }


    }
}

