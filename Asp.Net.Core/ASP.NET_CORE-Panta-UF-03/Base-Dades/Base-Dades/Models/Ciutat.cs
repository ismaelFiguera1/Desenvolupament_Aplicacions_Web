using System.ComponentModel.DataAnnotations;

namespace Base_Dades.Models
{
    public class Ciutat
    {
        [Required(ErrorMessage ="El id no pot estar buit")]
        public int id {  get; set; }
        [Required(ErrorMessage = "El nom no pot estar buit")]
        public string name { get; set; } = "";
        [Required(ErrorMessage = "El codi-ciutat no pot estar buit")]
        public string countrycode { get; set; } = "";
        [Required(ErrorMessage = "El districte no pot estar buit")]
        public string district { get; set; } = "";
        [Required(ErrorMessage = "La poblacio no pot estar buit")]
        [Range(1, int.MaxValue, ErrorMessage ="La poblacio no pot ser mes petita que 1")]
        public int population { get; set; }
    }
}
