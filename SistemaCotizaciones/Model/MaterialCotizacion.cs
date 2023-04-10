using System.ComponentModel.DataAnnotations;

namespace SistemaCotizaciones.Model
{
    public class MaterialCotizacion
    {
        public int MaterialCotizacionId { get; set; }
        [Display(Name ="Cotización")]
        public int? CotizacionId { get; set; }
        [Display(Name = "Cotización")]
        public Cotizacion? Cotizacion { get; set; }
        [Display(Name = "Material")]
        public int? MaterialId { get; set; }
        [Display(Name = "Material")]
        public Material? Material { get; set; }
        [Display(Name = "Cantidad")]
        public int? Cantidad { get; set; }

        [Display(Name = "Precio unitario")]
        public int? PrecioUnitario { get; set; }
        [Display(Name = "Precio cliente")]
        public int? PrecioCliente { get; set; }
        [Display(Name = "Total neto")]
        public int? TotalNeto { get; set; }
        [Display(Name = "Descuento [%]")]
        public double? DescuentoPorcentaje { get; set; }
        [Display(Name = "Descuento [$]")]
        public int? DescuentoAbsoluto { get; set; }
        [Display(Name = "Impuesto/Duty")]
        public double? ImpuestoDuty { get; set; }
        [Display(Name = "Fecha inicio")]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Fecha término")]
        public DateTime? FechaTermino { get; set; }
    }
}
