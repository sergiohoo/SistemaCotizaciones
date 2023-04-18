using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCotizaciones.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Display(Name = "SKU")]
        [Required(ErrorMessage = "El SKU es obligatorio")]
        public string Nombre { get; set; }
        [Display(Name ="Descripción")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Descripcion { get; set; }
        [Display(Name = "Código impulse")]
        public string? CodigoImpulse { get; set; }
        [Display(Name = "Precio unitario")]
        public int? PrecioUnitario { get; set; }
    }
}
