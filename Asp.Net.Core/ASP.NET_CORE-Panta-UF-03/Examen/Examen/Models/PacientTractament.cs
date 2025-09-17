namespace Examen.Models
{
    //opcional
    public class PacientTractament
    {

        public int Id { get; set; }
        public int PacientId { get; set; }
        public int TractamentId { get; set; }

        public Pacient Pacient { get; set; }
        public Tractament Tractament { get; set; }
    }
}
