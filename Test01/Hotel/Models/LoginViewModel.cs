using System.ComponentModel.DataAnnotations;

namespace Hotel.WebApp.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "El usuario es obligatorio.")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "La contraseña es obligatorio.")]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }
}
