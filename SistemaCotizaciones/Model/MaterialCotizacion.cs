using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

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
        [Display(Name = "Tipo de material")]
        public string? TipoMaterial { get; set; }
        [Display(Name = "Número de serie")]
        public string? NumeroSerie { get; set; }
        [Display(Name = "Cantidad")]
        public int? Cantidad { get; set; }

        [Display(Name = "Precio unitario")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? PrecioUnitario { get; set; }
        [Display(Name = "Precio cliente")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? PrecioCliente { get; set; }
        [Display(Name = "Total neto")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? TotalNeto { get; set; }
        [Display(Name = "Total compra")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? TotalCompra { get; set; }
        [Display(Name = "Descuento [%]")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? DescuentoPorcentaje { get; set; }
        [Display(Name = "Descuento [$]")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? DescuentoAbsoluto { get; set; }
        [Display(Name = "Impuesto/Duty")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal? ImpuestoDuty { get; set; }
        [Display(Name = "Fecha inicio")]
        public DateTime? FechaInicio { get; set; }
        [Display(Name = "Fecha término")]
        public DateTime? FechaTermino { get; set; }
        public string? CodigoImpulse { get; set; }
        public decimal? PrecioFob { get; set; }
        public decimal? Intercompany { get; set; }
        public decimal? MontoInternacion { get; set; }
        public decimal? UnoPorcientoFinanciero { get; set; }
        public decimal? CostoTotal { get; set; }
        public decimal? CostoFinalTotal { get; set; }
        public decimal? Margen { get; set; }
    }
}
