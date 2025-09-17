using System.ComponentModel.DataAnnotations;

namespace Cistell_de_la_compra.Models
{

    public class Usuari
    {
        /// <summary>email. Serveix com a login. Ha de ser únic.</summary>
        [Required(ErrorMessage = "El e-mail no pot estar en blanc")]
        [EmailAddress(ErrorMessage = "Te que ser un e-mail valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El nif no pot estar en blanc")]
        public string Nif { get; set; }

        [Required(ErrorMessage = "El nom no pot estar buit")]
        public string Nom { get; set; }

        [Required(ErrorMessage = "El cognom no pot estar buit")]
        public string Cognom { get; set; }

        [Required(ErrorMessage ="El telefon no pot estar buit")]
        public string Telefon { get; set; }


        [Required(ErrorMessage ="La data de naixement es te que ficar")]
        public DateTime DataNaixement {  get; set; }



        public Usuari()
        {
        }

        public Usuari(string email, string nif, string nom, string cognom, string telefon, DateTime dataNaixement)
        {
            Email = email;
            Nif = nif;
            Nom = nom;
            Cognom = cognom;
            Telefon = telefon;
            DataNaixement = dataNaixement;
        }
    }
}
