using System.ComponentModel.DataAnnotations;

namespace TaskAplication.Models
{
    public class Persona
    {
        [Key]
        [Required(ErrorMessage ="Te que estar ple")]
        [MaxLength(9)]
        [StringLength(9)]
        public string DNI { get; set; }

        [Required(ErrorMessage = "Nom obligatori")]
        [MaxLength(20)]
        [StringLength(20)]
        public string Name { get; set; }

        [Required(ErrorMessage ="Edat obligatoria")]
        public int Edat { get; set; }

        public List<Tasca> Tasca { get; set; } = new List<Tasca>();

        public Persona(string dni, string nom, int edat)
        {
            this.Edat = edat;
            this.Name = nom;
            this.DNI = dni;
        }

        public Persona() { }


    }
}
