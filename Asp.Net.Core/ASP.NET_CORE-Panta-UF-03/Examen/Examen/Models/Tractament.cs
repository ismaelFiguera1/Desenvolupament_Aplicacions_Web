using Examen.Models;

public class Tractament
{
    public int Id { get; set; }
    public string Nom { get; set; }

    public List<Pacient> Pacients { get; set; } = new();

    public List<PacientTractament> PacientTractaments { get; set; } // opcional
}
