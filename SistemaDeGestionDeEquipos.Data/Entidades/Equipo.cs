using System;
using System.Collections.Generic;

namespace SistemaDeGestionDeEquipos.Data.Entidades
{
    public partial class Equipo
    {
        public Equipo()
        {
            Jugadors = new HashSet<Jugador>();
        }

        public int IdEquipo { get; set; }
        public string NombreEquipo { get; set; } = null!;
        public bool ParticipaEnTorneo { get; set; }

        public virtual ICollection<Jugador> Jugadors { get; set; }
    }
}
