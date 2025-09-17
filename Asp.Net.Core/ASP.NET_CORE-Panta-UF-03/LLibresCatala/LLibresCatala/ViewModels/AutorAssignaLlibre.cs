using LLibresCatala.Models;

namespace LLibresCatala.ViewModels
{
    public class AutorAssignaLlibre
    {
        public Persona Autor { get; set; } = null!;

        public List<Llibre> Llibres { get; set; } = null!;
    }
}
