using SistemaCotizaciones.Model;

namespace SistemaCotizaciones.Models
{
    public class CotizacionCreateViewModel
    {
        public Cotizacion Cotizacion { get; set; }
        public Quote Quote { get; set; }

        public ContactoClienteFinal nuevoCCF { get; set; }
        public ClienteFinal nuevoCF { get; set; }
        public Canal nuevoC { get; set; }
        public ContactoCanal nuevoCC { get; set; }
        public Material nuevoM { get; set; }
    }
}
