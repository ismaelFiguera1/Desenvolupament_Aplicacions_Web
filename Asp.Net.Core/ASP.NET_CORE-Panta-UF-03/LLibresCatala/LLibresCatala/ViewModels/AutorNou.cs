using LLibresCatala.Models;

namespace LLibresCatala.ViewModels
{
    public class AutorNou
    {
        public Persona Autor { get; set; } = new Persona();
        public Llibre Llibre { get; set; } = new Llibre();
    }
}
