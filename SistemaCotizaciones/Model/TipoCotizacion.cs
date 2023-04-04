using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class TipoCotizacion
    {
        public int TipoCotizacionId { get; set; }
        [Display(Name = "Tipo de cotización")]
        [Required(ErrorMessage = "El tipo es obligatorio")]
        public string Nombre { get; set; }
    }
}
