using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LLibresCatala.Models
{
    public class Llibre
    {

        
        public string ISBN { get; set; }

        public string Titol { get; set; }

        public short? NumPag {  get; set; }

        public decimal? Preu { get; set; }

        public List<LlibrePersona>? LlibresPersona { get; set; } = new();
    }
}
