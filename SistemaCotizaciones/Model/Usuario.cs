using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class Usuario
    {
        public int UsuarioId { get; set; }
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "El nombre de usuario es obligatorio")]
        public string NombreUsuario { get; set; }
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "El apellido es obligatorio")]
        public string Apellido { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string Email { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Contraseña { get; set; }
    }
}
