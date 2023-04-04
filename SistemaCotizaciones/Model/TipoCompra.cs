using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class TipoCompra
    {
        public int TipoCompraId { get; set; }
        [Display(Name = "Tipo de compra")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Nombre { get; set; }
    }
}
