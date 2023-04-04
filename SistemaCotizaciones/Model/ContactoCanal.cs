using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class ContactoCanal
    {
        public int ContactoCanalId { get; set; }
        [Display(Name = "Canal")]
        [Required(ErrorMessage = "Debe seleccionar un canal")]
        public int CanalId { get; set; }
        [Display(Name = "Canal")]
        public Canal? Canal { get; set; }
        [Display(Name = "RUT")]
        [Required(ErrorMessage = "El RUT es obligatorio")]
        public string Rut { get; set; }
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
    }
}
