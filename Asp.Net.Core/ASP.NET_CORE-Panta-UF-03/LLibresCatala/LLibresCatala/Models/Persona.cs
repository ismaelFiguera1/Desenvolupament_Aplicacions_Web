using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace LLibresCatala.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public DateTime? DataNaixement { get; set; }


        public List<LlibrePersona>? LlibresPersona { get; set; } = new();

    }
}
