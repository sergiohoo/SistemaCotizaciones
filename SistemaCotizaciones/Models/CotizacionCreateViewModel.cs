using SistemaCotizaciones.Model;

namespace SistemaCotizaciones.Models
{
    public class CotizacionCreateViewModel
    {
        public Cotizacion Cotizacion { get; set; }
        public List<Material> Materiales { get; set; }
    }
}
