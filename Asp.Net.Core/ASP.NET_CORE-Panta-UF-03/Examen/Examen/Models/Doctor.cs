namespace Examen.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<Pacient>? Pacients { get; set; } = new();
    }
}
