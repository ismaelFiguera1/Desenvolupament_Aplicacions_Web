using LLibresCatala.Models;

namespace LLibresCatala.ViewModels
{
    public class AutorDetalls
    {
        public Persona Autor { get; set; } = null!;
        public List<Llibre> Llibres { get; set; } = null!;

    }
}
