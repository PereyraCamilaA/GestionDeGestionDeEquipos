using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SistemaDeGestionDeEquipos.Data.Entidades
{
    public partial class SistemaDeGestionDeEquiposContext : DbContext
    {
        public SistemaDeGestionDeEquiposContext()
        {
        }

        public SistemaDeGestionDeEquiposContext(DbContextOptions<SistemaDeGestionDeEquiposContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Equipo> Equipos { get; set; } = null!;
        public virtual DbSet<Jugador> Jugadors { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SistemaDeGestionDeEquipos;Trusted_Connection=True;Encrypt=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Equipo>(entity =>
            {
                entity.HasKey(e => e.IdEquipo);

                entity.ToTable("Equipo");

                entity.Property(e => e.NombreEquipo).HasMaxLength(100);
            });

            modelBuilder.Entity<Jugador>(entity =>
            {
                entity.HasKey(e => e.IdJugador);

                entity.ToTable("Jugador");

                entity.Property(e => e.NombreCompleto).HasMaxLength(100);

                entity.HasOne(d => d.IdEquipoNavigation)
                    .WithMany(p => p.Jugadors)
                    .HasForeignKey(d => d.IdEquipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Jugador_Equipo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
