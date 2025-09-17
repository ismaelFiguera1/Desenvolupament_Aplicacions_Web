namespace Examen.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        public string? Nom { get; set; }
        public string? Cognoms { get; set; }

        public int Edat { get; set; }

        public DateTime DataVisita { get; set; }

        public int DoctorId { get; set; }  // Clave foránea
        public Doctor Doctor { get; set; } // Navegación

        public TargetaSanitaria TargetaSanitaria { get; set; }

        public List<Tractament> Tractaments { get; set; } = new(); // 🔁 molts a molts

        public List<PacientTractament> PacientTractaments { get; set; } //opcional
    }
}
