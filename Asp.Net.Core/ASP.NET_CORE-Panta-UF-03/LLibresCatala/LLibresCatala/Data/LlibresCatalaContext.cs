using System.Numerics;
using LLibresCatala.Models;
using Microsoft.EntityFrameworkCore;

namespace LLibresCatala.Data
{
    public class LlibresCatalaContext : DbContext
    {
        public LlibresCatalaContext(DbContextOptions<LlibresCatalaContext> options)
    : base(options)
        {        }

        public DbSet<Llibre> llibre { get; set; }
        public DbSet<Persona> persona { get; set; }
        public DbSet<LlibrePersona> llibrepersona { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Llibre>().ToTable("llibre");
            modelBuilder.Entity<Persona>().ToTable("persona");
            modelBuilder.Entity<LlibrePersona>().ToTable("llibrepersona");

            modelBuilder.Entity<LlibrePersona>()
    .HasOne(p => p.Persona)
    .WithMany(d => d.LlibresPersona)
    .HasForeignKey(p => p.PersonaId);

            modelBuilder.Entity<Llibre>()
        .HasKey(l => l.ISBN);


            modelBuilder.Entity<LlibrePersona>()
    .HasOne(p => p.Llibre)
    .WithMany(d => d.LlibresPersona)
    .HasForeignKey(p => p.LlibreISBN);







            modelBuilder.Entity<Persona>().HasData(
                new Persona { Id = 1, Nom = "Ismael" },
               new Persona { Id = 2, Nom = "Pau" }
            );

                        modelBuilder.Entity<Llibre>().HasData(
                new Llibre { ISBN = "abcd", Titol="Alicia", NumPag=56 }
            );

            modelBuilder.Entity<LlibrePersona>().HasData(
                new LlibrePersona
                {
                    Id = 1,
                    PersonaId = 1,         
                    LlibreISBN = "abcd",   
                    rol = Rol.Autor,
                    primari = true
                }
            );
        }

    }
}
