using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class ContactoClienteFinal
    {
        public int ContactoClienteFinalId { get; set; }
        [Display(Name = "Cliente final")]
        public int ClienteFinalId { get; set; }
        [Display(Name = "Cliente final")]
        public ClienteFinal? ClienteFinal { get; set; }
        [Display(Name = "RUT")]
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
