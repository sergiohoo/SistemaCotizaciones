using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace SistemaCotizaciones.Model
{
    public class Cotizacion
    {
        public int CotizacionId { get; set; }
        [Display(Name ="Version")]
        public int Version { get; set; }
        [Display(Name = "Usuario")]
        [Required(ErrorMessage = "Debe seleccionar un vendedor")]
        public int UsuarioId { get; set; }
        [Display(Name = "Usuario")]
        public Usuario? Usuario { get; set; }
        [Display(Name = "Fabricante")]
        [Required(ErrorMessage = "Debe seleccionar un fabricante")]
        public int FabricanteId { get; set; }
        [Display(Name = "Fabricante")]
        public Fabricante? Fabricante { get; set; }
        [Display(Name = "Quote")]
        [Required(ErrorMessage = "Debe seleccionar un quote")]
        public int QuoteId { get; set; }
        [Display(Name = "Quote")]
        public Quote? Quote { get; set; }
        [Display(Name = "Tipo cotización")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de cotización")]
        public int TipoCotizacionId { get; set; }
        [Display(Name = "Tipo cotización")]
        public TipoCotizacion? TipoCotizacion { get; set; }
        [Display(Name = "Tipo compra")]
        [Required(ErrorMessage = "Debe seleccionar un tipo de compra")]
        public int TipoCompraId { get; set; }
        [Display(Name = "Tipo compra")]
        public TipoCompra? TipoCompra { get; set; }
        [Display(Name = "Canal")]
        [Required(ErrorMessage = "Debe seleccionar un canal")]
        [ForeignKey("Canal")]
        public int CanalId { get; set; }
        [Display(Name = "Canal")]
        public Canal? Canal { get; set; }
        [Display(Name = "Contacto canal")]
        [Required(ErrorMessage = "Debe seleccionar un contacto de canal")]
        [ForeignKey("ContactoCanal")]
        public int ContactoCanalId { get; set; }
        [Display(Name = "Contacto canal")]
        public ContactoCanal? ContactoCanal { get; set; }
        [Display(Name = "Cliente final")]
        [Required(ErrorMessage = "Debe seleccionar un cliente final")]
        [ForeignKey("ClienteFinal")]
        public int ClienteFinalId { get; set; }
        [Display(Name = "Cliente final")]
        public ClienteFinal? ClienteFinal { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un contacto de cliente final")]
        [Display(Name = "Contacto cliente final")]
        [ForeignKey("ContactoClienteFinal")]
        public int ContactoClienteFinalId { get; set; }
        [Display(Name = "Contacto cliente final")]
        public ContactoClienteFinal? ContactoClienteFinal { get; set; }
        [Display(Name = "Margen")]
        [Required(ErrorMessage = "El margen es obligatorio")]
        public decimal Margen { get; set; }
        [Display(Name = "Observaciones")]
        public string Observaciones { get; set; }
        [Display(Name = "Total neto")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal TotalNeto { get; set; }
        [Display(Name = "Total con IVA")]
        [DisplayFormat(DataFormatString = "{N2}")]
        [ModelBinder(BinderType = typeof(DecimalBinder))]
        public decimal TotalIVA { get; set; }

        public List<MaterialCotizacion>? MaterialesCotizacion { get; set; }

        [NotMapped]
        public Material? nuevoMaterial { get; set; }
        [NotMapped]
        public Canal? nuevoCanal { get; set; }
        [NotMapped]
        public ContactoCanal? nuevoContactoCanal { get; set; }
        [NotMapped]
        public ClienteFinal? nuevoClienteFinal { get; set; }
        [NotMapped]
        public ContactoClienteFinal? nuevoContactoClienteFinal { get; set; }

    }
}
