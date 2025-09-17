using System.ComponentModel.DataAnnotations;

namespace Cistell_de_la_compra.Models
{
    public class UsuariLogin
    {
        public UsuariLogin()
        {
        }

        [Required(ErrorMessage ="Email Obligatori")]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool Locked { get; set; }

        public DateTime LastUpdate { get; set; }

        public UsuariLogin(string email, string password, bool isAdmin, bool locked, DateTime lastUpdate)
        {
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
            Locked = locked;
            LastUpdate = lastUpdate;
        }
    }
}
