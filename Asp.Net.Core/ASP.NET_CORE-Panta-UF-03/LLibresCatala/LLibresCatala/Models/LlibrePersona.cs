using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace LLibresCatala.Models
{
    public enum Rol
    {
        NoEspecificat = 0,
        Autor = 1,
        Corrector = 2,
        Traductor = 3
    }


    public class LlibrePersona
    {
        public int Id { get; set; }

        public Rol rol {  get; set; } //Especifica el rol que aquesta persona ha tingut en la publicació del llibre

        public bool primari { get; set; }   //Quan hi ha més d'un especifica el autor primari, traductor primari, etc....

        public int PersonaId { get; set; }  // Clave foránea
        public Persona Persona { get; set; } // Navegación


        public string LlibreISBN { get; set; }  // Clave foránea
        public Llibre Llibre { get; set; } // Navegación
    }
}
