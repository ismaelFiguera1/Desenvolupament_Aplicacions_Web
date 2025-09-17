using Examen.Models;
using Microsoft.EntityFrameworkCore;


namespace Examen.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        public DbSet<Pacient> Pacients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<TargetaSanitaria> TargetesSanitaries { get; set; }

        public DbSet<Tractament> Tractaments { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*
             *             // DateTime fechaManual = new DateTime(2025, 5, 9, 14, 30, 0);

            // DateTime(año, mes, día, hora, minuto, segundo)
             */

            // 1 a Molts

            modelBuilder.Entity<Pacient>()
    .HasOne(p => p.Doctor)
    .WithMany(d => d.Pacients)
    .HasForeignKey(p => p.DoctorId);

            // 1 a 1

            /*
             * modelBuilder.Entity<TargetaSanitaria>()
    .HasOne(t => t.Pacient)
    .WithOne(p => p.TargetaSanitaria)
    .HasForeignKey<TargetaSanitaria>(t => t.PacientId);
             */

            modelBuilder.Entity<TargetaSanitaria>()
    .HasOne(t => t.Pacient)
    .WithOne(p => p.TargetaSanitaria)
    .HasForeignKey<TargetaSanitaria>(t => t.PacientId);



            // molts : molts
            //opcional
            
            modelBuilder.Entity<Pacient>()
    .HasMany(p => p.Tractaments)
    .WithMany(t => t.Pacients)
    .UsingEntity(j => j.ToTable("PacientTractaments"));
            


            modelBuilder.Entity<Pacient>().ToTable("Pacients");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Pacient>().HasData(
                new Pacient { Id = 01, Nom = "Ismael", Cognoms = "Figuera Farré", Edat = 21, DataVisita = new DateTime(2025, 05, 09), DoctorId = 1 },
                new Pacient { Id = 02, Nom = "Yostin", Cognoms = "Garcia", Edat = 21, DataVisita = new DateTime(2025, 03, 09), DoctorId = 1 },
                new Pacient { Id = 03, Nom = "Eric", Cognoms = "Gallart", Edat = 21, DataVisita = new DateTime(2025, 01, 25), DoctorId = 1 },
                new Pacient { Id = 04, Nom = "Aissam", Cognoms = "Gracia", Edat = 21, DataVisita = new DateTime(2023, 05, 21), DoctorId = 1 },
                new Pacient { Id = 05, Nom = "Pau", Cognoms = "Nikita", Edat = 21, DataVisita = new DateTime(2025, 05, 09, 10, 30, 00), DoctorId = 1 }
            );

            modelBuilder.Entity<Doctor>().HasData(
                new Doctor { Id = 1, Name = "Dra. López"}
            );

            modelBuilder.Entity<TargetaSanitaria>().HasData(
    new TargetaSanitaria { Id = 134, Codi = "TAR001", PacientId = 1 },
    new TargetaSanitaria { Id = 221, Codi = "TAR002", PacientId = 2 },
    new TargetaSanitaria { Id = 311, Codi = "TAR003", PacientId = 3 }
);

            // Tractaments
            modelBuilder.Entity<Tractament>().HasData(
                new Tractament { Id = 1, Nom = "Fisioteràpia" },
                new Tractament { Id = 2, Nom = "Psicologia" }
            );

            // Relacions Pacient-Tractament
            modelBuilder.Entity<PacientTractament>().HasData(
                new PacientTractament { PacientId = 1, TractamentId = 1, Id = 1 },
                new PacientTractament { PacientId = 1, TractamentId = 2, Id = 2 },
                new PacientTractament { PacientId = 2, TractamentId = 2, Id = 3 }
            );
        }
        public DbSet<Examen.Models.PacientTractament> PacientTractament { get; set; } = default!;
    }

}
