using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaCotizaciones.Model;
using SistemaCotizaciones.Models;

namespace SistemaCotizaciones.Controllers
{
    public class CotizacionesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CotizacionesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public JsonResult GetContactosCanal(int canalId)
        {
            var contactos = _context.ContactosCanales.Where(c => c.CanalId == canalId).ToList();
            var result = new JsonResult(contactos);
            return result;
        }

        [HttpGet]
        public JsonResult GetContactosClienteFinal(int clienteId)
        {
            var contactos = _context.ContactosClientesFinales.Where(c => c.ClienteFinalId == clienteId).ToList();
            var result = new JsonResult(contactos);
            return result;
        }

        // GET: Cotizaciones
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cotizaciones.Include(c => c.Canal).Include(c => c.ClienteFinal).Include(c => c.ContactoCanal).Include(c => c.ContactoClienteFinal).Include(c => c.Fabricante).Include(c => c.Quote).Include(c => c.TipoCompra).Include(c => c.TipoCotizacion).Include(c => c.Usuario);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Cotizaciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.Canal)
                .Include(c => c.ClienteFinal)
                .Include(c => c.ContactoCanal)
                .Include(c => c.ContactoClienteFinal)
                .Include(c => c.Fabricante)
                .Include(c => c.Quote)
                .Include(c => c.TipoCompra)
                .Include(c => c.TipoCotizacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CotizacionId == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial));
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial));
            //ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales, "ContactoCanalId", nameof(ContactoCanal.Nombre));
            //ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales, "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre));
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre));
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote));
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre));
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre));
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario));

            ViewData["Materiales"] = new SelectList(_context.Materiales.OrderBy(m => m.Nombre), nameof(Material.MaterialId), nameof(Material.Nombre));

            var cotizacion = new Cotizacion();
            var materiales = new List<MaterialCotizacion>();
            for (int i = 0; i < 100; i++)
            {
                var material = new MaterialCotizacion
                {
                    FechaInicio = DateTime.Now,
                    FechaTermino = DateTime.Now.AddDays(30)
                };
                materiales.Add(material);
            }
            cotizacion.MaterialesCotizacion = materiales;

            return View(cotizacion);
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cotizacion cotizacion)
        {
            if (ModelState.IsValid)
            {
                var materialesCotizacion = new List<MaterialCotizacion>();

                foreach (var material in cotizacion.MaterialesCotizacion)
                {
                    if (material.Cantidad != null && material.Cantidad > 0)
                    {
                        material.CotizacionId = cotizacion.CotizacionId;
                        materialesCotizacion.Add(material);
                    }
                }

                cotizacion.MaterialesCotizacion = materialesCotizacion;

                _context.Add(cotizacion);
                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);
            return View(cotizacion);
        }

        // GET: Cotizaciones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones.FindAsync(id);
            if (cotizacion == null)
            {
                return NotFound();
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);
            return View(cotizacion);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CotizacionId,UsuarioId,FabricanteId,QuoteId,TipoCotizacionId,TipoCompraId,CanalId,ContactoCanalId,ClienteFinalId,ContactoClienteFinalId,Duty,Impuesto,Margen,Observaciones")] Cotizacion cotizacion)
        {
            if (id != cotizacion.CotizacionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cotizacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.CotizacionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);
            return View(cotizacion);
        }

        // GET: Cotizaciones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Cotizaciones == null)
            {
                return NotFound();
            }

            var cotizacion = await _context.Cotizaciones
                .Include(c => c.Canal)
                .Include(c => c.ClienteFinal)
                .Include(c => c.ContactoCanal)
                .Include(c => c.ContactoClienteFinal)
                .Include(c => c.Fabricante)
                .Include(c => c.Quote)
                .Include(c => c.TipoCompra)
                .Include(c => c.TipoCotizacion)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CotizacionId == id);
            if (cotizacion == null)
            {
                return NotFound();
            }

            return View(cotizacion);
        }

        // POST: Cotizaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Cotizaciones == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Cotizaciones'  is null.");
            }
            var cotizacion = await _context.Cotizaciones.FindAsync(id);
            if (cotizacion != null)
            {
                _context.Cotizaciones.Remove(cotizacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CotizacionExists(int id)
        {
            return (_context.Cotizaciones?.Any(e => e.CotizacionId == id)).GetValueOrDefault();
        }
    }
}
