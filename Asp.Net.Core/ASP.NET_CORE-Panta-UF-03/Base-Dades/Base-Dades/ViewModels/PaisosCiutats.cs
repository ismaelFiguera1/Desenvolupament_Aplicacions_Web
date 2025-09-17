using Base_Dades.Models;

namespace Base_Dades.ViewModels
{
    public class PaisosCiutats
    {
        public List<Ciutat>? llistaCiutats { get; set; }
        public List<Pais>? llistaPaisos { get; set; }
        public Ciutat? ciutat { get; set; }
        public Pais? pais { get; set; }
    }
}
