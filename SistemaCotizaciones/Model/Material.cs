using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCotizaciones.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Display(Name = "PN")]
        [Required(ErrorMessage = "El PN es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name ="Descripción")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Descripcion { get; set; }
        [Display(Name = "SKU")]
        [Required(ErrorMessage = "El SKU es obligatorio")]
        public string? Sku { get; set; }
        [Display(Name = "Número de serie")]
        [Required(ErrorMessage = "El número de serie es obligatorio")]
        public string? NumeroSerie { get; set; }
        [Display(Name = "Código impulse")]
        public string? CodigoImpulse { get; set; }
        [Display(Name = "Precio unitario")]
        public int? PrecioUnitario { get; set; }        
    }
}
