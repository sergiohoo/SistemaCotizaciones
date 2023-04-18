using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class Quote
    {
        public int QuoteId { get; set; }
        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "Debe seleccionar un fabricante")]
        public int FabricanteId { get; set; }
        [Display(Name = "Fabricante")]
        public Fabricante? Fabricante { get; set; }
        [Display(Name = "Contacto fabricante")]
        [Required(ErrorMessage = "Debe seleccionar un contacto de fabricante")]
        public int ContactoFabricanteId { get; set; }
        [Display(Name = "Contacto fabricante")]
        public ContactoFabricante? ContactoFabricante { get; set; }
        [Display(Name = "Número de quote")]
        [Required(ErrorMessage = "El número de quote es obligatorio")]
        public string NumeroQuote { get; set; }
        [Display(Name = "Nombre oportunidad")]
        [Required(ErrorMessage = "El nombre de oportunidad es obligatorio")]
        public string? NombreOportunidad { get; set; }
        [Display(Name = "Vigencia")]
        public bool Vigencia { get; set; }
        [Display(Name = "Fecha de emisión")]
        [Required(ErrorMessage = "La fecha de emisión es obligatoria")]
        public DateTime FechaEmision { get; set; }
        public List<Cotizacion> Cotizaciones { get; set; }
    }
}
