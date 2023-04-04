using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class Fabricante
    {
        public int FabricanteId { get; set; }
        [Display(Name = "Nombre del fabricante")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }
        public List<ContactoFabricante>? Contactos { get; set; }
        public List<Quote>? Quotes { get; set; }
    }
}
