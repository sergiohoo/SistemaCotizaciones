namespace SistemaCotizaciones.Model
{
    public class Pocc
    {
        public int PoccId { get; set;}
        public int CotizacionId { get; set; }
        public Cotizacion Cotizacion { get; set; }
        public string Origen { get; set; }
        public string Incoterm { get; set; }
        public string TipoDespacho { get; set; }
    }
}
