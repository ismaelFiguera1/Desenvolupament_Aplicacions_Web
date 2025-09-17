using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json.Serialization;

namespace TaskAplication.Models
{
    public class Tasca
    {
        [Required (ErrorMessage ="La descripcio es obligatoria")]
        [StringLength (20)]
        [MaxLength(20)]
        [MinLength(5, ErrorMessage ="No pot ser menys de 5 caracters")]
        public string Description { get; set; }

        public DateTime CrearModificar { get; set; }

        public bool TascaFeta { get; set; }

        public int Id { get; set; }

        public Persona Persona { get; set; }

        public string PersonaDNI { get; set; }

        public Tasca(string des)
        {
            this.Description = des;
            this.CrearModificar = DateTime.Now;
            this.TascaFeta = false;
        }

        public Tasca()
        {
            this.CrearModificar = DateTime.Now;
            this.TascaFeta = false;
            this.Description = "";
        }
    }
}
