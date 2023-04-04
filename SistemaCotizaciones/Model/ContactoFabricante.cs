using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCotizaciones.Model
{
    public class ContactoFabricante
    {
        public int ContactoFabricanteId { get; set; }
        [Display(Name = "Fabricante")]
        [Required(ErrorMessage ="Debe seleccionar un fabricante")]
        public int FabricanteId { get; set; }
        [Display(Name = "Fabricante")]
        public Fabricante? Fabricante { get; set; }
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
        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "El cargo es obligatorio")]
        public string Cargo { get; set; }
        public List<Quote>? Quotes { get; set; }
    }
}
