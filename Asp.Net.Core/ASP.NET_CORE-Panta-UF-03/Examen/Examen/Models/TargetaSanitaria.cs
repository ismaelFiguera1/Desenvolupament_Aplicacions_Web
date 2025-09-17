using System.ComponentModel.DataAnnotations;

namespace Examen.Models
{
    public class TargetaSanitaria
    {
        /*      [Key]
              public int PacientId { get; set; }  // Clave primaria y foránea al mismo tiempo
      */
        public int Id { get; set; }
        public string Codi { get; set; }  // Ej: "TAR123456"

        public Pacient Pacient { get; set; }


        public int PacientId { get; set; }     // ✅ Clau forània
    }
}
