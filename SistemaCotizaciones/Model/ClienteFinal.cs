using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class ClienteFinal
    {
        public int ClienteFinalId { get; set; }
        [Display(Name = "RUT")]
        [Required(ErrorMessage = "El RUT es obligatorio")]
        public string Rut { get; set; }
        [Display(Name = "Razón social")]
        [Required(ErrorMessage = "La razón social es obligatorio")]
        public string RazonSocial { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string Email { get; set; }
        public List<ContactoClienteFinal>? Contactos { get; set; }
    }
}
