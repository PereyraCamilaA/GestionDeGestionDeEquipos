using System;
using System.Collections.Generic;

namespace SistemaDeGestionDeEquipos.Data.Entidades
{
    public partial class Jugador
    {
        public int IdJugador { get; set; }
        public string NombreCompleto { get; set; } = null!;
        public int IdEquipo { get; set; }

        public virtual Equipo? IdEquipoNavigation { get; set; } = null!;
    }
}
