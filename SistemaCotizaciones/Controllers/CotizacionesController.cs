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

        public IActionResult Excel(int id)
        {
            var cotizacion = _context.Cotizaciones.Where(c => c.CotizacionId == id).Include(c => c.Usuario).Include(c => c.MaterialesCotizacion).ThenInclude(m => m.Material).Include(c => c.ClienteFinal).Include(c => c.Canal).FirstOrDefault();
            var model = new CotizacionExcelViewModel
            {
                cotizacion = cotizacion
            };

            return View(model);
        }

        [HttpGet]
        public JsonResult GetContactosFabricante(int fabricanteId)
        {
            var contactos = _context.ContactosFabricantes.Where(c => c.FabricanteId == fabricanteId).ToList();
            var result = new JsonResult(contactos);
            return result;
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

        // GET: Cotizaciones/Create
        public IActionResult Create()
        {
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial));
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial));
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre));
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre));
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre));
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario));

            var listaMateriales = _context.Materiales.OrderBy(m => m.Nombre).ToList();
            var selectListMateriales = new List<SelectListItem>();
            foreach (var material in listaMateriales)
            {
                var texto = material.TipoMaterial + " | " + material.Nombre + " | " + material.NumeroSerie + " | " + material.Descripcion;

                var itemMaterial = new SelectListItem
                {
                    Text = texto,
                    Value = material.MaterialId.ToString()
                };

                selectListMateriales.Add(itemMaterial);
            }


            ViewData["Materiales"] = new SelectList(selectListMateriales, "Value", "Text");

            var cotizacion = new Cotizacion();
            var materiales = new List<MaterialCotizacion>();
            for (int i = 0; i < 100; i++)
            {
                var material = new MaterialCotizacion
                {
                    FechaInicio = DateTime.Now,
                    FechaTermino = DateTime.Now.AddDays(30),
                    Cantidad = 0,
                    ImpuestoDuty = 0,
                    PrecioUnitario = 0,
                    DescuentoPorcentaje = 0
                };
                materiales.Add(material);
            }
            cotizacion.MaterialesCotizacion = materiales;

            var model = new CotizacionCreateViewModel
            {
                Cotizacion = cotizacion,
                Quote = new Quote
                {
                    FechaEmision = DateTime.Now.Date
                }
            };

            return View(model);
        }

        // POST: Cotizaciones/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cotizacion cotizacion, Quote quote)
        {
            if(cotizacion != null && quote != null)
            {
                _context.Add(quote);
                await _context.SaveChangesAsync();

                cotizacion.QuoteId = quote.QuoteId;
                cotizacion.FabricanteId = quote.FabricanteId;

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
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
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

            var cotizacion = await _context.Cotizaciones.Where(c => c.CotizacionId == id).Include(c => c.MaterialesCotizacion).FirstOrDefaultAsync();
            var quote = await _context.Quotes.Where(q => q.QuoteId == cotizacion.QuoteId).FirstOrDefaultAsync();
            if (cotizacion == null || quote == null)
            {
                return NotFound();
            }
            ViewData["CanalId"] = new SelectList(_context.Canales, "CanalId", nameof(Canal.RazonSocial), cotizacion.CanalId);
            ViewData["ClienteFinalId"] = new SelectList(_context.ClientesFinales, "ClienteFinalId", nameof(ClienteFinal.RazonSocial), cotizacion.ClienteFinalId);
            ViewData["ContactoCanalId"] = new SelectList(_context.ContactosCanales.Where(c => c.CanalId == cotizacion.CanalId), "ContactoCanalId", nameof(ContactoCanal.Nombre), cotizacion.ContactoCanalId);
            ViewData["ContactoClienteFinalId"] = new SelectList(_context.ContactosClientesFinales.Where(c => c.ClienteFinalId == cotizacion.ClienteFinalId), "ContactoClienteFinalId", nameof(ContactoClienteFinal.Nombre), cotizacion.ContactoClienteFinalId);
            ViewData["FabricanteId"] = new SelectList(_context.Fabricantes, "FabricanteId", nameof(Fabricante.Nombre), cotizacion.FabricanteId);
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes.Where(f => f.FabricanteId == cotizacion.FabricanteId), "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);

            var listaMateriales = _context.Materiales.OrderBy(m => m.Nombre).ToList();
            var selectListMateriales = new List<SelectListItem>();
            foreach (var material in listaMateriales)
            {
                var texto = material.TipoMaterial + " | " + material.Nombre + " | " + material.NumeroSerie + " | " + material.Descripcion;

                var itemMaterial = new SelectListItem
                {
                    Text = texto,
                    Value = material.MaterialId.ToString()
                };

                selectListMateriales.Add(itemMaterial);
            }


            ViewData["Materiales"] = new SelectList(selectListMateriales, "Value", "Text");

            var materiales = new List<MaterialCotizacion>();
            foreach(var material in cotizacion.MaterialesCotizacion)
            {
                materiales.Add(material);
            }

            for (int i = 0; i < 100 - cotizacion.MaterialesCotizacion.Count; i++)
            {
                var material = new MaterialCotizacion
                {
                    FechaInicio = DateTime.Now,
                    FechaTermino = DateTime.Now.AddDays(30),
                    Cantidad = 0,
                    ImpuestoDuty = 0,
                    PrecioUnitario = 0,
                    DescuentoPorcentaje = 0
                };
                materiales.Add(material);
            }
            cotizacion.MaterialesCotizacion = materiales;

            var model = new CotizacionCreateViewModel
            {
                Cotizacion = cotizacion,
                Quote = quote
            };

            return View(model);
        }

        // POST: Cotizaciones/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cotizacion cotizacion, Quote quote)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quote);

                    cotizacion.QuoteId = quote.QuoteId;
                    cotizacion.FabricanteId = quote.FabricanteId;

                    var materialesCotizacion = new List<MaterialCotizacion>();

                    foreach (var material in cotizacion.MaterialesCotizacion)
                    {
                        if (material.TotalNeto != null && material.TotalNeto > 0)
                        {
                            material.CotizacionId = cotizacion.CotizacionId;
                            materialesCotizacion.Add(material);
                        }
                    }
                    cotizacion.MaterialesCotizacion = materialesCotizacion;

                    _context.Update(cotizacion);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CotizacionExists(cotizacion.CotizacionId) || !QuoteExists(quote.QuoteId))
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
            ViewData["ContactoFabricanteId"] = new SelectList(_context.ContactosFabricantes.Where(f => f.FabricanteId == cotizacion.FabricanteId), "ContactoFabricanteId", nameof(ContactoFabricante.Nombre), quote.ContactoFabricanteId);
            ViewData["QuoteId"] = new SelectList(_context.Quotes, "QuoteId", nameof(Quote.NumeroQuote), cotizacion.QuoteId);
            ViewData["TipoCompraId"] = new SelectList(_context.TiposCompra, "TipoCompraId", nameof(TipoCompra.Nombre), cotizacion.TipoCompraId);
            ViewData["TipoCotizacionId"] = new SelectList(_context.TiposCotizacion, "TipoCotizacionId", nameof(TipoCotizacion.Nombre), cotizacion.TipoCotizacionId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuarios, "UsuarioId", nameof(Usuario.NombreUsuario), cotizacion.UsuarioId);

            var listaMateriales = _context.Materiales.OrderBy(m => m.Nombre).ToList();
            var selectListMateriales = new List<SelectListItem>();
            foreach (var material in listaMateriales)
            {
                var texto = material.TipoMaterial + " | " + material.Nombre + " | " + material.NumeroSerie + " | " + material.Descripcion;

                var itemMaterial = new SelectListItem
                {
                    Text = texto,
                    Value = material.MaterialId.ToString()
                };

                selectListMateriales.Add(itemMaterial);
            }


            ViewData["Materiales"] = new SelectList(selectListMateriales, "Value", "Text");

            var materiales = new List<MaterialCotizacion>();
            foreach (var material in cotizacion.MaterialesCotizacion)
            {
                materiales.Add(material);
            }

            for (int i = 0; i < 100 - cotizacion.MaterialesCotizacion.Count; i++)
            {
                var material = new MaterialCotizacion
                {
                    FechaInicio = DateTime.Now,
                    FechaTermino = DateTime.Now.AddDays(30),
                    Cantidad = 0,
                    ImpuestoDuty = 0,
                    PrecioUnitario = 0,
                    DescuentoPorcentaje = 0
                };
                materiales.Add(material);
            }
            cotizacion.MaterialesCotizacion = materiales;

            var model = new CotizacionCreateViewModel
            {
                Cotizacion = cotizacion,
                Quote = quote
            };

            return View(model);
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

        private bool QuoteExists(int id)
        {
            return (_context.Quotes?.Any(e => e.QuoteId == id)).GetValueOrDefault();
        }
    }
}
