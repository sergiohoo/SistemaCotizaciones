using Microsoft.EntityFrameworkCore;

namespace SistemaCotizaciones.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
            
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Constants.ConnectionString, options =>
            {

            });
        }

        public DbSet<Fabricante> Fabricantes { get; set;}
        public DbSet<ContactoFabricante> ContactosFabricantes { get; set;}
        public DbSet<Canal> Canales { get; set; }
        public DbSet<ContactoCanal> ContactosCanales { get; set; }
        public DbSet<ClienteFinal> ClientesFinales { get; set; }
        public DbSet<ContactoClienteFinal> ContactosClientesFinales { get; set; }
        public DbSet<Material> Materiales { get; set; }
        public DbSet<TipoCotizacion> TiposCotizacion { get; set; }
        public DbSet<TipoCompra> TiposCompra { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Cotizacion> Cotizaciones { get; set; }
        public DbSet<MaterialCotizacion> MaterialesCotizacion { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Pocc> Pocc { get; set; }

    }
}
