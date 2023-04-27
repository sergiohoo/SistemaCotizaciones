using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaCotizaciones.Model
{
    public class Material
    {
        public int MaterialId { get; set; }
        [Display(Name = "SKU")]
        [Required(ErrorMessage = "El SKU es obligatorio")]
        public string Sku { get; set; }
        [Display(Name ="Descripción")]
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string? Descripcion { get; set; }
        [Display(Name = "Material SAP")]
        public string? MaterialSap { get; set; }
        [Display(Name = "Precio unitario")]
        public int? PrecioUnitario { get; set; }
    }
}
