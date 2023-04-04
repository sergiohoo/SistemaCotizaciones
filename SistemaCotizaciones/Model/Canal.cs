using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class Canal
    {
        public int CanalId { get; set; }
        [Display(Name = "RUT")]
        [Required(ErrorMessage ="El RUT es obligatorio")]
        public string Rut { get; set; }
        [Display(Name = "Razón social")]
        [Required(ErrorMessage = "La razón social es obligatoria")]
        public string RazonSocial { get; set; }
        [Display(Name = "Teléfono")]
        [Required(ErrorMessage = "El teléfono es obligatorio")]
        public string Telefono { get; set; }
        [Display(Name = "Dirección")]
        [Required(ErrorMessage = "La dirección es obligatoria")]
        public string Direccion { get; set; }
        [Display(Name = "Correo electrónico")]
        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        public string Email { get; set; }
        [Display(Name = "Número cliente Ingram")]
        [Required(ErrorMessage = "El número de cliente es obligatorio")]
        public string NumeroClienteIngram { get; set; }
        public List<ContactoCanal>? Contactos { get; set; }
    }
}
